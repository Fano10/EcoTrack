import { Link } from "react-router-dom";
import "./App.css";
import Register from "./Register";
import { useEffect, useRef, useState } from "react";
import { Route, Routes, Router, useNavigate } from "react-router-dom";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [validation, setValidation] = useState(false);
    
    const navigate = useNavigate();
    const handleSubmitRef = useRef();
    
    useEffect(() => {
        handleSubmitRef.current = function handleSubmit(e) {
            e.preventDefault();
    
            fetch("https://localhost:6002/Login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ Email: email, Password: password }),
            })
                .then((response) => {
                    if (response.ok) {
                        setValidation(false); // Utilise la valeur précédente
                        navigate('/suivi')
                    } else {
                        setValidation(true); // Utilise la valeur précédente
                        
                    }
                })
                .catch((error) => {
                    console.error("Erreur lors de la requête :", error);
                });
        };
    }, [email, password]); // Pas besoin d'ajouter `validate` dans les dépendances
    



    return (
        <>
        <form onSubmit={(e) => handleSubmitRef.current(e)}>
            <fieldset>
                <div>
                    <label>Courriel</label>
                    <input
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        type="text"
                        placeholder="Email"
                    />
                </div>
                <div>
                    <label>Mot de passe</label>
                    <input
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        type="password"
                        placeholder="Password"
                    />
                </div>
                <button type="submit">Se connecter</button>
            </fieldset>
        {validation ? <p>Email ou mot de passe incorrect</p> : null}
        </form>
        <Link to="/register">S'inscrire</Link>
        </>
    );
}

export default Login;
