import React from 'react';
import logo from './logo.svg';
import './App.css';
import Logo from './Components/Logo/Logo';
import ButtonHomeList from './Components/buttonHomeList/buttonHomeList';
import HomePage from './Pages/HomePage/HomePagse';
import { Outlet } from 'react-router';


function App() {
  return (
    <div>
        <Outlet/>
    </div>
  )  
}

export default App;
