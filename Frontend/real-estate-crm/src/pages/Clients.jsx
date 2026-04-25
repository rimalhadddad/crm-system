import { useEffect, useState } from "react";
import {
  getClients,
  createClient,
  updateClient,
  deleteClient,
  assignProperty,
} from "../services/clientService";
import { getProperties } from "../services/propertyService";

export default function Clients() {
  const [clients, setClients] = useState([]);
  const [properties, setProperties] = useState([]);

  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [propertyId, setPropertyId] = useState("");
  const [editId, setEditId] = useState(null);


  const loadData = async () => {
    try {
      const clientsRes = await getClients();
      const propertiesRes = await getProperties();

      setClients(clientsRes.data.data);
      setProperties(propertiesRes.data.data);
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    loadData();
  }, []);


  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!name || !email || !phone) {
      alert("All fields are required");
      return;
    }

    const data = {
      name,
      email,
      phone
    };

    try {
      if (editId) {
        await updateClient(editId, data);
      } else {
        await createClient(data);
      }

      // reset
      setEditId(null);
      setName("");
      setEmail("");
      setPhone("");


      loadData();
    } catch (err) {
      console.log(err);
    }
  };


  const handleEdit = (c) => {
    setEditId(c.id);
    setName(c.name);
    setEmail(c.email);
    setPhone(c.phone || "");
    setPropertyId(c.propertyId ? String(c.propertyId) : "");
  };


  const handleDelete = async (id) => {
    if (!window.confirm("Delete this client?")) return;

    await deleteClient(id);
    loadData();
  };

  
  const handleAssign = async (clientId, propertyId) => {
    try {
      await assignProperty({
        clientId,
        propertyId: propertyId ? Number(propertyId) : null,
      });

      loadData();
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div style={{ padding: "20px", maxWidth: "1000px", margin: "auto" }}>
      <h1>👥 Clients</h1>

  
      <form
        onSubmit={handleSubmit}
        style={{
          display: "grid",
          gap: "10px",
          marginBottom: "30px",
          padding: "15px",
          border: "1px solid #ddd",
          borderRadius: "10px",
        }}
      >
        <input
          placeholder="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />

        <input
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />

        <input
          placeholder="Phone"
          value={phone}
          onChange={(e) => setPhone(e.target.value)}
        />

        <button type="submit">
          {editId ? "✏️ Update Client" : "➕ Add Client"}
        </button>
      </form>

 
      <div style={{ display: "grid", gap: "15px" }}>
        {clients.map((c) => (
          <div
            key={c.id}
            style={{
              border: "1px solid #ddd",
              borderRadius: "10px",
              padding: "15px",
              boxShadow: "0 2px 6px rgba(0,0,0,0.1)",
            }}
          >
            <h3>{c.name}</h3>
            <p>📧 {c.email}</p>
            <p>📞 {c.phone}</p>

       
            <select
              value={c.propertyId || ""}
              onChange={(e) =>
                handleAssign(c.id, e.target.value)
              }
            >
              <option value="">No Property</option>
              {properties.map((p) => (
                <option key={p.id} value={p.id}>
                  {p.title}
                </option>
              ))}
            </select>

           
            <div style={{ marginTop: "10px", display: "flex", gap: "10px" }}>
              <button onClick={() => handleEdit(c)}>Edit</button>

              <button
                onClick={() => handleDelete(c.id)}
                style={{ color: "red" }}
              >
                Delete
              </button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}