import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import AppRoutes from "./routes/AppRoutes";
import Navbar from "./components/Navbar";
import './App.css'

export default function App() {
  const token = localStorage.getItem("token");

  return (
    <>
      {token && <Navbar />}
      <AppRoutes />
    </>
  );
}