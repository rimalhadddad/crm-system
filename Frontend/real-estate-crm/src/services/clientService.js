import api from "../api/api";

export const getClients = () => {
  return api.get("/client");
};

export const createClient = (data) => {
  return api.post("/client", data);
};

export const updateClient = (id, data) =>
  api.put(`/client/${id}`, data);

export const deleteClient = (id) =>
  api.delete(`/client/${id}`);


export const assignProperty = (data) => {
  return api.post("/client/assign-property", data);
};