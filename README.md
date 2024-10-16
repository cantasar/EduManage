# EduManage

EduManage is a backend solution designed to streamline the management of student records, courses, and enrollment processes. Built with modern web technologies, it ensures efficient data handling and scalability for educational institutions.

## Features

- **Student Management**: Manage student profiles, including personal details, academic records, and enrollment history.
- **Course Management**: Create, update, and manage course information, including schedules, descriptions, and credits.
- **Enrollment System**: Handle student course registrations, track enrollment status, and manage academic schedules.

## Technologies Used

- **ASP.NET Core 8.0**: For building a robust and scalable web backend.
- **Entity Framework Core 8.0**: To manage database operations with Code First approach.
- **SQLite**: A lightweight and portable database solution.
- **MVC Architecture**: To ensure separation of concerns and maintainable code structure.
- **Code First Migrations**: Enable seamless database versioning and updates.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/EduManage.git
    ```
2. Navigate to the project directory:
    ```bash
    cd EduManage
    ```
3. Restore dependencies:
    ```bash
    dotnet restore
    ```
4. Apply migrations to set up the database:
    ```bash
    dotnet ef database update
    ```
5. Run the project:
    ```bash
    dotnet run
    ```

## Project Structure

- `/Controllers`: Handles requests and responses for different resources (students, courses, enrollment).
- `/Models`: Defines the data structures and relationships for the application.
- `/Views`: (If applicable) Provides the user interface templates.
- `/Migrations`: Stores the Code First migration scripts.
- `/Data`: Contains database context and configurations.

## Contributing

Feel free to contribute by submitting pull requests, reporting issues, or suggesting new features.


---

