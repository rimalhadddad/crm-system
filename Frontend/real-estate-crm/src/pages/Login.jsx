import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { login } from "../services/authService";

export default function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const res = await login({ email, password });
console.log("LOGIN RESPONSE:", res.data.token);
 
      localStorage.setItem("token", res.data.token);

   
      navigate("/properties");

    } catch (err) {
      setError("Invalid email or password");
    }
  };

  return (
    <div style={{ maxWidth: "400px", margin: "100px auto" }}>
      <h2>Login</h2>

      <form onSubmit={handleLogin}>
        <input
          placeholder="Email"
          onChange={(e) => setEmail(e.target.value)}
          style={{ display: "block", width: "100%", marginBottom: 10 }}
        />

        <input
          type="password"
          placeholder="Password"
          onChange={(e) => setPassword(e.target.value)}
          style={{ display: "block", width: "100%", marginBottom: 10 }}
        />

        <button type="submit">Login</button>
      </form>
      <p
  style={{
    marginTop: "10px",
    cursor: "pointer",
    color: "blue",
    textDecoration: "underline",
  }}
  onClick={() => navigate("/signup")}
>
  Don't have an account? Sign up
</p>
      {error && <p style={{ color: "red" }}>{error}</p>}
    </div>

    
  );
}