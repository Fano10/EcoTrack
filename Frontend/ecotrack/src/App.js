import logo from './logo.svg';
import './App.css';
import Login from './Login';
import React from 'react';
import Register from './Register';
import Suivi from './Suivi';
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";

function App() {
  return (
          <Routes>
              <Route path="/" element={<Login />} />
              <Route path="/register" element={<Register />} />
              <Route path="/suivi" element = {<Suivi/>} />
          </Routes>
  );
}

export default App;
