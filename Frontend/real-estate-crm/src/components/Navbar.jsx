import { Link, useNavigate } from "react-router-dom";

export default function Navbar() {
  const navigate = useNavigate();

  const handleLogout = () => {
   
    localStorage.removeItem("token");

 
    navigate("/");
  };

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        padding: "15px 30px",
        background: "#1e293b",
        color: "white",
      }}
    >
      <h2>🏠 Real Estate CRM</h2>

      <div style={{ display: "flex", gap: "15px" }}>
        <Link to="/properties" style={{ color: "white" }}>
          Properties
        </Link>
        <Link to="/clients" style={{ color: "white" }}>
            Clients
        </Link>

        <button
          onClick={handleLogout}
          style={{
            background: "red",
            color: "white",
            border: "none",
            padding: "8px 12px",
            cursor: "pointer",
          }}
        >
          Logout
        </button>
      </div>
    </div>
  );
}