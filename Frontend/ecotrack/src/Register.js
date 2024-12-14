import "./App.css";
import { useState, useEffect,useRef } from "react";
import { useNavigate } from "react-router-dom";
const PasswordErrorMessage = () => {
  return (
    <p className="FieldError">Password should have at least 8 characters</p>
  );
};

const validateEmail = (email) => {
    return String(email)
      .toLowerCase()
      .match(
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      );
  };
  

function Register() {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState({
    value: "",
    isTouched: false,
  });

  const handleSubmitRef = useRef();

  const navigate  = useNavigate();
  const getIsFormValid = () => {
    let validation = false;
    if(name.length > 0 && password.value.length >=8 && validateEmail(email)){
      validation = true
    }
    return validation;
  };

  const clearForm = () => {
    setName("");
    setEmail("");
    setPassword({value : "", isTouched: false});
  };


  useEffect(() => {
    handleSubmitRef.current = function handleSubmit(event) {
        event.preventDefault();
        console.log(name);
    fetch("https://localhost:6002/Signing", 
        {method: "POST", 
        headers: {"Content-Type":"application/json"}, 
        body: JSON.stringify({"name": name,"email": email, "password":password.value})
    }).then((response) => {
        if(response.ok){
            navigate("/");
        }
        else{
            console.log("No okay boy");
        }
    })
    }
  },[name, email, password]);


  const handlePassword = (event) =>{
      setPassword({value : event.target.value, isTouched : true});
      console.log(password);
  }
  return (
    <div className="App"> 
    <form onSubmit={(e) => handleSubmitRef.current(e)}> 
      <fieldset> 
        <h2>Sign Up</h2> 
        <div className="Field"> 
          <label> 
            Nom <sup>*</sup> 
          </label> 
          <input 
            value={name} 
            onChange={(e) => { 
              setName(e.target.value); 
            }} 
          /> 
        </div> 
        <div className="Field"> 
          <label> 
            Courriel <sup>*</sup> 
          </label> 
          <input 
            value={email} 
            onChange={(e) => { 
              setEmail(e.target.value); 
            }}  
          /> 
        </div> 
        <div className="Field"> 
          <label> 
            Mot de passe <sup>*</sup> 
          </label> 
          <input 
            value={password.value} 
            type="password" 
            onChange={(e) => { 
              setPassword({ ...password, value: e.target.value }); 
            }} 
            onBlur={() => { 
              setPassword({ ...password, isTouched: true }); 
            }}  
          /> 
          {password.isTouched && password.value.length < 8 ? ( 
            <PasswordErrorMessage /> 
          ) : null} 
        </div> 
        <button type="submit" disabled={!getIsFormValid()}> 
          Create account 
        </button> 
      </fieldset> 
    </form> 
  </div> 
  );
}

export default Register;
