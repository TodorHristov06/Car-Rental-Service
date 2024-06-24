# CarPal

## Setup Instructions

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/carpal.git
    cd carpal
    ```

2. Update the database connection string in `appsettings.json`.

3. Apply migrations and update the database:
    ```bash
    dotnet ef database update
    ```

4. Run the application:
    ```bash
    dotnet run
    ```

## User Guide

### Roles

- **Administrator**: Full access to all functionalities.
- **Customer Service Representative**: Manage customers and rentals.
- **Customer**: View and manage their own rentals.

### Features

- **Create Rental**: Allows users to create rental agreements.
- **Edit Rental**: Allows users to modify existing rentals.
- **Delete Rental**: Allows users to delete rentals.
- **Email Notifications**: Sends confirmation and reminder emails for rentals.
