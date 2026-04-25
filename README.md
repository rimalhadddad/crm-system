#  RM System (Full Stack)

A full-stack **Real Estate CRM System** built with **ASP.NET Core Web API** and **React.js**.
This project allows agents/users to manage properties, clients, and assignments in a structured way.

---

#Features

###  Authentication

* User Registration & Login
* JWT Token Authentication
* Protected API endpoints

###  Properties Management

* Create / Update / Delete properties
* View user-specific properties

### Clients Management

* Create / Update / Delete clients
* Assign clients to properties
* View assigned/unassigned clients

### Security

* User-based data isolation
* Secure API with JWT authorization

---

# Tech Stack

### Backend

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication

### Frontend

* React.js (Vite)
* Axios
* React Router
* JavaScript (ES6+)

---

# Project Structure


crm-system/
│
├── Backend/
│   └── CRM API (.NET Core)
│
├── Frontend/
│   └── real-estate-crm (React App)
│
├── docs/
│   └── diagrams 
```

---

#  Setup Instructions

##  Backend (.NET API)


cd Backend/CRM
dotnet restore
dotnet run
```

### Configure:

* Update `appsettings.json` for database connection
* Run migrations if needed

---

## Frontend (React)


cd Frontend/real-estate-crm
npm install
npm run dev
```

---

#  Environment Variables

### Backend example:


"Jwt": {
  "Key": "your-secret-key"
}
```

---

#  API Overview

### Auth

* `POST /api/auth/signup`
* `POST /api/auth/login`

### Clients

* `GET /api/client`
* `POST /api/client`
* `PUT /api/client/{id}`
* `DELETE /api/client/{id}`
* `POST /api/client/assign-property`

### Properties

* `GET /api/property/my`
* `POST /api/property`
* `PUT /api/property/{id}`
* `DELETE /api/property/{id}`

---

#  Key Architecture

* Clean separation of concerns (Controller → Interface -> Service → DB)
* DTO-based communication
* JWT-based authentication
* Entity relationships:

  * User → Properties (1:N)
  * User → Clients (1:N)
  * Client → Property (Many-to-One optional assignment)

---

# Author

**Reem al Haddad**

Full Stack Developer (.NET / React)

---

# Notes

* `node_modules` is excluded from Git (use `npm install`)
* Backend uses JWT authentication
* Each user only sees their own data
