# Invoice Management System (Full-Stack API)

This is a comprehensive **Invoice Management System** built as part of a Backend Developer Intern Technical Assignment. It features a robust **.NET 8.0 Web API** backend and a modern **React + Tailwind CSS** frontend.

---

## 🚀 Tech Stack

### Backend
* **Framework:** .NET 8.0 (ASP.NET Core Web API)
* **Database:** SQL Server
* **ORM:** Dapper (Chosen for performance and lightweight data mapping)
* **Authentication:** JWT (JSON Web Token) with Role-based Access Control (Admin/User)
* **Security:** BCrypt.Net for secure password hashing

### Frontend
* **Library:** React.js (Vite)
* **Styling:** Tailwind CSS (Modern, Responsive, and Utility-first)
* **State Management:** React Hooks (`useState`, `useEffect`)
* **API Client:** Axios (Configured with Interceptors for seamless JWT handling)

---

## 📂 Project Structure

The project follows a clean separation of concerns utilizing the **Repository Pattern**:

```plaintext
/Backend
  ├── /Controllers    # API Endpoints
  ├── /Services       # Business Logic & Async Tasks
  ├── /Repositories   # Database Queries (Dapper)
  ├── /Models         # Database Entities
  ├── /DTOs           # Data Transfer Objects
  ├── /Middlewares    # Global Exception Handling & Security
  ├── /Database       # SQL Scripts (.sql files)
/Frontend             # React Application (Vite-based)
```
## ✨ Features

* **Secure Authentication:** Complete Register & Login system.
* **Role-Based Authorization:**
    * **Admin:** Full access, including deletion privileges.
    * **User:** Read/Write access for managing invoices.
* **Invoice CRUD:** Full lifecycle management (Create, Read, Update, Delete).
* **Async Background Tasks:** When an invoice is marked as "Paid", a background task triggers a payment confirmation log without blocking the main UI thread.
* **Responsive UI:** A fully functional dashboard designed for both desktop and mobile views.

---

## 🛠️ Setup Instructions

### 1. Database Setup
1.  Open **SQL Server Management Studio (SSMS)**.
2.  Navigate to the `/Backend/Database` folder in this repository.
3.  Execute the `Schema.sql` script to generate the database schema and required tables.

### 2. Backend Setup
1.  Navigate to the `/Backend` folder.
2.  Open `appsettings.json` and update the `ConnectionStrings:DefaultConnection` with your local SQL Server credentials.
3.  Run the project via Visual Studio or the terminal:
    ```bash
    dotnet run
    ```
4.  **API Documentation:** Access the Swagger UI at `http://localhost:5141/swagger` (verify port in your console output).

### 3. Frontend Setup
1.  Navigate to the `/Frontend` folder.
2.  Install dependencies:
    ```bash
    npm install
    ```
3.  Start the development server:
    ```bash
    npm run dev
    ```
4.  Open `http://localhost:5173` in your browser.



---

## 📝 API Endpoints

### Auth
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `POST` | `/api/Auth/register` | Create a new user account |
| `POST` | `/api/Auth/login` | Authenticate and receive a JWT token |

### Invoices
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/Invoices` | Retrieve all invoices (Authenticated) |
| `GET` | `/api/Invoices/{id}` | Retrieve a specific invoice |
| `POST` | `/api/Invoices` | Create a new invoice |
| `PUT` | `/api/Invoices/{id}` | Update invoice details or status |
| `DELETE` | `/api/Invoices/{id}` | Remove an invoice (**Admin Only**) |

---

## 💡 Implementation Approach

My approach prioritized **Clean Architecture** and **High Performance**:

* **Efficiency:** I opted for **Dapper** over Entity Framework to ensure lightweight, lightning-fast database interactions with manual query control.
* **Security:** Security was integrated at the core using **JWT Bearer Authentication** and **BCrypt** for industry-standard password protection.
* **Asynchrony:** To enhance user experience, the background processing for "Paid" invoices was implemented using `Task.Run`. This simulates an asynchronous notification system, allowing the server to acknowledge the update immediately while handling secondary logging/notifications in the background.
