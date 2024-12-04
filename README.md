# RideOut App

**RideOut** is a web application designed to connect enthusiasts of motorcycles, mini bikes, go karts, bicycles, scooters, e-bikes, and similar vehicles. The app allows users to create accounts, discover local events, and securely join private meet-ups. Events are only accessible to approved participants, with location data protected by time-sensitive authentication tokens to ensure privacy and security.

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Installation](#installation)
- [Usage](#usage)
- [Database Schema](#database-schema)
- [API](#api)
- [Authentication](#authentication)
- [Deployment](#deployment)
- [Contributing](#contributing)
- [License](#license)

---

## Overview

The **RideOut** app provides a platform for users to:

- **Create accounts** and customize their profiles.
- **Discover local events** related to motorcycles, mini bikes, go karts, e-bikes, and more.
- **Join private events**, with location details only visible after being confirmed by the event's administrator.
- **Secure access** to event location data via authentication tokens that expire after 30 minutes.

This application prioritizes **privacy** and **security**, ensuring only approved participants have access to sensitive event details.

---

## Features

- **User Authentication**: Secure user registration and login with hashed passwords.
- **Private Events**: Only confirmed participants can access event details.
- **Time-based Token Access**: Event location data is protected by authentication tokens that expire every 30 minutes.
- **Administrator Control**: Event admins can manage participants and control access to event data.
- **Event Management**: Host and join events, manage event details (date, time, location, max participants).

---

## Tech Stack

- **Backend**: .NET 9 Web API
- **Database**: PostgreSQL (for persistent data storage)
- **ORM**: Entity Framework Core (for managing database schema and migrations)
- **Authentication**: JWT (JSON Web Tokens) for secure access control
- **Containerization**: Docker (for creating isolated, reproducible environments)
- **Orchestration**: Kubernetes (for managing containerized deployments)
- **CI/CD**: Azure DevOps (for automated build, test, and deployment pipelines)

---

## Installation

### Prerequisites

Make sure you have the following tools installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet)
- [Docker](https://www.docker.com/get-started)
- [Kubernetes](https://kubernetes.io/docs/tasks/tools/install-kubectl/)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Azure DevOps](https://dev.azure.com/) (for CI/CD pipelines)

### Steps to Set Up Locally

1. **Clone the Service**:
   ```bash
   git clone https://github.com/<your-username>/RideOut-App.git
   cd RideOut-App
   ```

2. **Build the Application**:
   - Run the following command to restore dependencies:
     ```bash
     dotnet restore
     ```
   - Build the application:
     ```bash
     dotnet build
     ```

3. **Run Database Migrations** (if using Entity Framework):
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Start the Application**:
   - Run the application locally:
     ```bash
     dotnet run
     ```

5. **Access the API**: Open your browser or API testing tool (e.g., Postman) and test the endpoints.

---

## Usage

Once the app is running locally, you can:

- Create a user account to join events.
- Admins can approve or reject participants for events.
- Participants will receive an authentication token to access event location details, which will expire after 30 minutes.

---

## Database Schema

The RideOut app utilizes the following key tables:

- **Users**: Stores user information (UserID, Name, Email, PasswordHash, Location, ProfilePicture, etc.)
- **RideOuts**: Stores event details (RideOutID, HostUserID, Title, Description, Location, DateTime, MaxParticipants)
- **Participants**: Tracks user participation in events (ParticipantID, RideOutID, UserID, Status)
- **Messages** (optional enhancement): Allows users to send messages within events (MessageID, SenderUserID, MessageText, SentAt)
- **Reviews** (optional enhancement): Allows users to leave reviews for events (ReviewID, Rating, Comment)

---

## API

The RideOut app provides the following API endpoints:

- **POST** `/api/auth/register` - Register a new user.
- **POST** `/api/auth/login` - Login and get an authentication token.
- **GET** `/api/rideouts` - Get a list of public events.
- **POST** `/api/rideouts` - Create a new event (Admin only).
- **POST** `/api/rideouts/{id}/confirm` - Confirm a participant's attendance (Admin only).
- **GET** `/api/rideouts/{id}/location` - Get event location (requires valid token).

---

## Authentication

The app uses **JWT (JSON Web Tokens)** for secure authentication. Here's how authentication works:

1. **Login**: User logs in to get an access token.
2. **Token Expiry**: Tokens expire every 30 minutes.
3. **Access**: Only users with valid tokens can access event location details.

---

## Deployment

To deploy the application:

1. **Build Docker Images**:
   ```bash
   docker build -t rideout-app .
   ```

2. **Deploy with Kubernetes**:  
   - Use Kubernetes to manage the deployment on your cloud provider (e.g., Azure, AWS).
   - Set up a **Kubernetes cluster** and deploy the app using `kubectl`.

3. **Set up CI/CD Pipelines**:
   - Use **Azure DevOps** for automated build, test, and deployment pipelines.

---

## Contributing

We welcome contributions to RideOut! Here’s how you can help:

1. **Fork the Service** and clone your fork.
2. **Create a branch** for your feature or bug fix.
3. **Make your changes** and test them thoroughly.
4. **Submit a pull request** to the main Service.

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
