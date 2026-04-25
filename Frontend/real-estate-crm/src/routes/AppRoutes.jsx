import { Routes, Route } from "react-router-dom";
import Login from "../pages/Login";
import Signup from "../pages/Signup";
import Properties from "../pages/Properties";
import ProtectedRoute from "../components/ProtectedRoute";
import Clients from "../pages/Clients";

export default function AppRoutes() {
  return (
    
    <Routes>
      <Route path="/" element={<Login />} />
      <Route
        path="/signup"
        element={<Signup setIsAuth={Signup} />}
      />
      <Route
        path="/properties"
        element={
          <ProtectedRoute>
            <Properties />
          </ProtectedRoute>
        }
      />
      <Route
        path="/clients"
        element={
          <ProtectedRoute>
            <Clients />
          </ProtectedRoute>
        }
      />
    </Routes>
  );
}