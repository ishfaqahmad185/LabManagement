# Medical Lab Management System

The **Medical Lab Management System** is a web application designed to streamline medical lab operations. It enables administrators to manage patients, medical tests, and results efficiently, while allowing lab staff to handle sample collection, track test statuses, and generate reports. This system is ideal for small to medium-sized medical labs aiming to digitize their workflow.

---

## Key Features

### For Lab Administrators:
- **Patient Management**:
  - Add, edit, and delete patient profiles.
  - Search and view patient history with detailed insights.

- **Test Management**:
  - Categorize and manage tests (e.g., blood tests, imaging, pathology).
  - Define test parameters, reference ranges, and units.

- **Result Management**:
  - Enter or upload test results manually.
  - Generate, preview, and customize test report templates.

- **Sample Tracking**:
  - Log and monitor collected samples.
  - Track test statuses in real time to avoid delays.

### For Lab Technicians:
- **Sample Collection**:
  - Record sample details and associate them with patient test orders.

- **Result Entry**:
  - Input test results and validate data for automated report generation.

---

## Technology Stack

- **Frontend**: HTML, CSS, JavaScript, and Bootstrap (for responsive UI design).
- **Backend**: ASP.NET Core (C#) for scalable and secure server-side logic.
- **Database**: SQL Server for managing lab data.
- **Authentication**: ASP.NET Identity for role-based access control.

---

## Installation Guide

### Prerequisites:
- **.NET Core SDK**: Installed on your development machine.
- **SQL Server**: Set up for database storage.
- **Web Server**: IIS or any preferred hosting server (optional).

### Setup Instructions:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/medical-lab-management.git
   cd medical-lab-management
   ```

2. **Configure the Database**:
   - Open the `appsettings.json` file and update the connection string with your SQL Server details.
   - Run the SQL script located in the `Database/Setup` folder to create the required tables.

3. **Build and Run the Application**:
   ```bash
   dotnet build
   dotnet run
   ```

4. **Access the Application**:
   - Public interface: [http://localhost:5000](http://localhost:5000)
   - Admin portal: [http://localhost:5000/admin](http://localhost:5000/admin)

---

## Usage Instructions

### For Administrators:
- Log in to the admin portal with admin credentials.
- Manage patient records, medical tests, and test results.
- Monitor sample collection and testing progress.

### For Lab Staff:
- Log in using technician credentials.
- Collect samples, associate them with test orders, and input results.
- Generate and share reports securely with patients.

---

## API Documentation

For developers integrating this system with third-party applications, a RESTful API is provided.

- **Base URL**: [http://localhost:5000/api](http://localhost:5000/api)
- **Authentication**: JWT-based authentication.
- **Swagger UI**: Access at [http://localhost:5000/swagger](http://localhost:5000/swagger).

### Testing the API:
- Use tools like **Postman** or **cURL** to test the API endpoints.
- Import the Postman collection available in the `Docs/Postman` folder for predefined requests.

---

## About

The **Medical Lab Management System** is designed to simplify medical lab operations, reduce manual errors, and enhance productivity. It offers an intuitive interface, powerful features, and seamless API integrations.
