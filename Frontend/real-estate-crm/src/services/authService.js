import api from "../api/api";

export const login = (data) => {
  return api.post("/Auth/login", data);
};

export const signup = (data) => {
  return api.post("/Auth/signup", data);
};