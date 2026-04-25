import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { signup } from "../services/authService";

export default function Signup({ setIsAuth }) {
 const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

const handleSignup = async (e) => {
  e.preventDefault();

  try {
    const res = await signup({ username, email, password });
   const data = res.data;
    console.log("SIGNUP RESPONSE:", data);


    if (!data.success) {
      alert(data.message || "Signup failed");
      return;
    }


    localStorage.setItem("token", data.token || "");

    alert("Account created successfully!");

    navigate("/");

  } catch (err) {
    console.log("Signup error:", err);
    alert("Server error. Please try again.");
  }
};
  return (
    <div style={{ maxWidth: "400px", margin: "100px auto" }}>
      <h2>📝 Signup</h2>

      <form onSubmit={handleSignup}>
         <input
          placeholder="Username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          style={{ display: "block", width: "100%", marginBottom: 10 }}
        />
        <input
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          style={{ display: "block", width: "100%", marginBottom: 10 }}
        />

        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          style={{ display: "block", width: "100%", marginBottom: 10 }}
        />

        <button type="submit">Create Account</button>
      </form>

      <p
        style={{ marginTop: 10, cursor: "pointer", color: "blue" }}
        onClick={() => navigate("/")}
      >
        Already have an account? Login
      </p>
    </div>
  );
}