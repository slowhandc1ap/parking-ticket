# 🎫 Parking Pass Management System

A sleek and modern full-stack web application designed to manage parking passes with ease.  
Built with a powerful combination of **.NET Core Web API** (C#) for the backend and **Vue.js** with **Tailwind CSS** for the frontend. Inspired by real-world parking workflows, this project balances functionality with a touch of artistic flair.

---
https://private-user-images.githubusercontent.com/120072774/430608313-84ce17f8-5768-4f0e-8533-6243bdd1ac67.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NDM4NDUwNDUsIm5iZiI6MTc0Mzg0NDc0NSwicGF0aCI6Ii8xMjAwNzI3NzQvNDMwNjA4MzEzLTg0Y2UxN2Y4LTU3NjgtNGYwZS04NTMzLTYyNDNiZGQxYWM2Ny5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUwNDA1JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MDQwNVQwOTE5MDVaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT0zNDZjZDk2YjQ5YjBmMmU5ZDU2Y2Q4MzJhNjA5NTMwYTk2ODA0MDk0Y2YzNDAyNGUxMTM1NjBkNjBjYWMxMWY1JlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9._L7IFxLnR-MthrHAJZ8XMvTb-c0XRf4Jci6ZdyxlZOQ
## ✨ Key Features

- 🎟️ Generate digital parking passes with just a few clicks.
- 📋 Store detailed vehicle information: license plate, driver name, car color, type, entry/exit time, and calculated fee.
- 🧠 Intuitive UI that mimics real parking tickets for a familiar user experience.
- 📡 Real-time frontend-backend integration via RESTful APIs.
- 🛠️ Built with clean, scalable architecture and maintainable code.

---

## ⚙️ Tech Stack

| Layer     | Technology                             |
|-----------|-----------------------------------------|
| Frontend  | Vue 3, TypeScript, Tailwind CSS, Axios  |
| Backend   | .NET 8 Web API (C#), Entity Framework   |
| Database  | SQL Server                              |
| Tools     | Swagger UI, VSCode, Postman             |

---

## 📁 Project Structure

 <pre>
/parking-pass-system/
├── backend/                 # .NET Core Web API
│   ├── Controllers/
│   ├── Models/
│   ├── Data/
│   └── Program.cs
│
├── frontend/                # Vue.js + Tailwind
│   ├── src/
│   ├── components/
│   └── views/
│
├── README.md
└── .gitignore
</pre>

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/parking-pass-system.git
cd parking-pass-system
```

---

### 2. Backend Setup (.NET Core)

```bash
cd backend

# Restore dependencies
dotnet restore

# Create initial database migration
dotnet ef migrations add InitialCreate

# Apply migration to the database
dotnet ef database update

# Start the API
dotnet run
```

> ⚠️ Configure your connection string in `appsettings.json` to match your SQL Server setup.

---

### 3. Frontend Setup (Vue.js)

```bash
cd frontend

# Install dependencies
npm install

# Start the dev server
npm run dev
```

---

## 📡 API Endpoints

| Method | Endpoint                   | Description              |
|--------|----------------------------|--------------------------|
| GET    | /api/parkingpass           | Get all parking records  |
| POST   | /api/parkingpass           | Create new record        |
| PUT    | /api/parkingpass/{id}      | Update a record          |
| DELETE | /api/parkingpass/{id}      | Delete a record          |

---

## 🎨 UI Sample

The frontend mimics a real-world parking pass layout.  
It uses elegant card components, subtle animations (via Framer Motion), and mobile-friendly layouts styled with Tailwind CSS.

> 📌 Optional enhancements: 
> - Add printing support  
> - Add QR code to each ticket  
> - Export history to CSV/PDF  

---

## 🧾 License

This project is licensed under the [MIT License](LICENSE).

---

## 👨‍🎨 Developer Notes

> "This project started from a curiosity and turned into a practical tool.  
> Built with love, coffee, and an unhealthy obsession with clean UIs."  
> — Korn, Dev & Aesthetic Enthusiast ☕🎨

---

## 🌟 Show some love

If you found this useful or inspiring, consider starring ⭐️ the repo and sharing with others.
