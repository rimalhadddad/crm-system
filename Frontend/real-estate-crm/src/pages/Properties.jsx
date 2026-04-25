import { useEffect, useState } from "react";
import {
  getProperties,
  createProperty,
  updateProperty,
  deleteProperty,
} from "../services/propertyService";

export default function Properties() {
  const [properties, setProperties] = useState([]);

  const [title, setTitle] = useState("");
  const [price, setPrice] = useState("");
  const [address, setAddress] = useState("");
  const [editId, setEditId] = useState(null);

 
  const loadProperties = async () => {
    try {
      const res = await getProperties();
      setProperties(res.data.data);
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    loadProperties();
  }, []);

  
  const handleSubmit = async (e) => {
    e.preventDefault();

    const data = {
      title,
      address,
      price: Number(price),
    };

    try {
      if (editId) {
        await updateProperty(editId, data);
      } else {
        await createProperty(data);
      }

      
      setEditId(null);
      setTitle("");
      setAddress("");
      setPrice("");

      loadProperties();
    } catch (err) {
      console.log(err);
    }
  };

 
  const handleEdit = (p) => {
    setEditId(p.id);
    setTitle(p.title);
    setAddress(p.address);
    setPrice(p.price);
  };


  const handleDelete = async (id) => {
    if (!window.confirm("Delete this property?")) return;

    await deleteProperty(id);
    loadProperties();
  };

  return (
    <div style={{ padding: "20px", maxWidth: "1000px", margin: "auto" }}>
      <h1>🏠 Properties Dashboard</h1>

   
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
          placeholder="Property Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />

        <input
          placeholder="Address"
          value={address}
          onChange={(e) => setAddress(e.target.value)}
        />

        <input
          placeholder="Price"
          type="number"
          value={price}
          onChange={(e) => setPrice(e.target.value)}
        />

        <button type="submit">
          {editId ? "✏️ Update Property" : "➕ Add Property"}
        </button>
      </form>

    
      <div
        style={{
          display: "grid",
          gridTemplateColumns: "repeat(auto-fit, minmax(250px, 1fr))",
          gap: "15px",
        }}
      >
        {properties.map((p) => (
          <div
            key={p.id}
            style={{
              border: "1px solid #ddd",
              borderRadius: "10px",
              padding: "15px",
              boxShadow: "0 2px 6px rgba(0,0,0,0.1)",
            }}
          >
            <h3>{p.title}</h3>
            <p>📍 {p.address}</p>
            <p>💰 {p.price}</p>

        
            <div style={{ display: "flex", gap: "10px", marginTop: "10px" }}>
              <button onClick={() => handleEdit(p)}>Edit</button>

              <button
                onClick={() => handleDelete(p.id)}
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