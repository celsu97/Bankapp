# BankApp – Blazor WebAssembly
A streamlined and modern bank application built as an educational project to explore the fundamentals of C#, .NET, and Blazor. This project focuses on a clean user interface (UI) and efficient state management.  

## Features
The application provides core functionality for personal financial management:

- Dashboard (Home): A visual overview of all registered accounts and their current balances.

- Account Management: Create and delete accounts with support for different account types (e.g., Checking or Savings).

- Transactions: Perform internal transfers between your own accounts, as well as direct deposits and withdrawals.  

- Activity History: A detailed view of all transactions with support for filtering by date and transaction type, as well as sorting by amount and time.

- Local Persistence: All data is saved in the browser's localStorage, ensuring that information is preserved between sessions without the need for an external database.

## Technical Decisions
- LocalStorage over Database: Since the project is client-focused, the browser's local storage is used to simulate a database.

- State Management: The app uses a service-based architecture where the AccountService communicates changes to the interface via events (StateChanged).

## Getting Started - Prerequisites
- .NET 8 SDK (or later)

- A modern web browser (Chrome, Edge, Firefox, or Safari)

- IDE (e.g., JetBrains Rider or Visual Studio)

- Installation and Running
- Clone the repository: git clone https://github.com/celsu97/Bankapp.git

- Navigate to the project folder: cd BankApp

- Restore dependencies and build: dotnet restore

- Run the application: dotnet run

- Open your browser at the address shown in the console (usually https://localhost:5001).

## Future Improvements
- A natural next step for the application would be to implement a proper authentication system (Identity) and connect an API with a SQL database to allow secure access from multiple devices.
