import api from "../api/api";

export const getProperties = () => {
  return api.get("/Property/my");
};

export const createProperty = (data) => {
  return api.post("/Property", data);
};

export const updateProperty = (id, data) =>
  api.put(`/Property/${id}`, data);

export const deleteProperty = (id) =>
  api.delete(`/Property/${id}`);