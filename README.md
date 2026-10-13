\# Inventory Management System



An Inventory Management System developed as part of the internship assessment for \*\*Imark Digital\*\*. The project aims to simplify product management, stock tracking, user management, and inventory reporting using modern .NET technologies.



\## Project Overview



The system is being developed to help manage products, monitor stock levels, record stock movements, and control user access through role-based authorization.



\## Objectives



\- Implement user registration and role assignment.

\- Manage user roles and access permissions.

\- Manage products with automatically generated product codes.

\- Record stock-in and stock-out transactions.

\- Generate stock reports.

\- Analyze stock movement history.



\## Planned Features



\### User Management

\- Create and manage user accounts.

\- Assign roles to users.

\- Securely hash passwords before storing them.



\### Role Management

\- Manage user roles.

\- Restrict access to protected operations based on assigned roles.



\### Product Management

Manage product information, including:



\- Product code (automatically generated)

\- Product name

\- Unit

\- Category

\- Maximum Retail Price (MRP)

\- Product image



\### Stock Management

\- Record stock-in and stock-out transactions.

\- Track available stock quantities.

\- Maintain stock movement records.



\### Stock Reports

\- View available stock quantities.

\- Review product stock information.

\- Support inventory monitoring and reporting.



\### Stock Movement Analysis

\- Review stock-in and stock-out history.

\- Analyze stock movements over a selected period.

\- Track changes in inventory quantities.



\*Note: These features represent the project requirements and development goals. Implementation is ongoing.\*



\## Technology Stack



\- \*\*Backend:\*\* ASP.NET Core Web API

\- \*\*Programming Language:\*\* C#

\- \*\*Database:\*\* Microsoft SQL Server

\- \*\*ORM:\*\* Entity Framework Core

\- \*\*API Documentation and Testing:\*\* Swagger / OpenAPI

\- \*\*Frontend:\*\* Angular (optional)

\- \*\*Version Control:\*\* Git and GitHub



\## Prerequisites



To develop and run the project, you may need:



\- .NET SDK compatible with the project

\- Microsoft SQL Server

\- Visual Studio or Visual Studio Code

\- Entity Framework Core tools



\## Getting Started



\### 1. Clone the Repository



```bash

git clone https://github.com/Anil-Chandra-Giri/Inventory-System.git

cd Inventory-System

```



\### 2. Restore Dependencies



```bash

dotnet restore inventorySystem/inventorySystem.csproj

```



\### 3. Configure the Database



Configure the SQL Server connection string in `appsettings.json` according to your local environment. Ensure that passwords and other sensitive credentials are not committed to source control.



\### 4. Run the Application



```bash

dotnet run --project inventorySystem/inventorySystem.csproj

```



If Swagger is enabled, open the Swagger URL displayed in the application console to explore and test the available API endpoints.



\*Database migrations and additional configuration may be required as development progresses.\*



\## Security Considerations



\- Store passwords using a suitable password-hashing algorithm.

\- Protect API endpoints using authentication and role-based authorization.

\- Keep database credentials and API secrets out of source control.

\- Validate user input and handle errors appropriately.



\## Project Status



\*\*In Development\*\*



The project is in its initial development stage. Features will be implemented and tested incrementally according to the internship assignment requirements.



\## Author



\*\*Anil Giri\*\*



Computer Engineering Graduate



\## Internship Assessment



Developed as part of the Inventory System assignment for \*\*Imark Digital\*\*.



\## Repository



\[GitHub – Inventory System](https://github.com/Anil-Chandra-Giri/Inventory-System)

