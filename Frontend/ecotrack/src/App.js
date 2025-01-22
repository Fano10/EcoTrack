import './App.css';
import Login from './Login';
import React from 'react';
import Register from './Register';
import Suivi from './Suivi';
import image from './img/imgEcotrack.jpg'
import {  Routes, Route} from "react-router-dom";

function App() {
  return (
    <div>
          <img src = {image} alt="imageEcoTrack" width={400}/>
          <Routes>
              <Route path="/" element={<Login />} />
              <Route path="/register" element={<Register />} />
              <Route path="/suivi" element = {<Suivi/>} />
          </Routes>
    </div>
  );
}

export default App;
