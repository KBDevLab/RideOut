# RideOut App

**RideOut** is a web application designed for enthusiasts of motorcycles, mini bikes, go-karts, bicycles, scooters, e-bikes, and similar vehicles. The app allows users to create accounts, discover local events, and securely join private meet-ups. Event details, including locations, are only accessible to approved participants, with access controlled via time-sensitive authentication tokens for enhanced privacy and security.

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

- **Create accounts** and personalize their profiles.
- **Discover local events** related to rideable vehicles.
- **Join private events**, with event details unlocked upon approval from the event administrator.
- **Secure access** to event locations via authentication tokens that expire every 30 minutes.

This app prioritizes **privacy** and **security**, ensuring only approved participants gain access to sensitive event information.

---

## Features

- **User Authentication**: Secure user registration and login with **Angular**.
- **Responsive UI**: Built with **Angular Material** for a modern, mobile-first design.
- **Private Events**: Only confirmed participants can access event details.
- **Tokenized Access**: Event location data is secured with authentication tokens that expire in 30 minutes.
- **Admin Controls**: Event admins can manage participants and control event access.
- **Event Management**: Users can host, join, and manage events, including setting participant limits and event details.

---

## Tech Stack

- **Frontend**: 
  - **Angular** (dynamic web applications)
  - **Angular Material** (UI components)
- **Backend**: 
  - **.NET 9 Web API** (server-side logic)
- **Database**: 
  - **PostgreSQL** (data storage)
- **ORM**: 
  - **Entity Framework Core** (database schema management)
- **Authentication**: 
  - **JWT** (JSON Web Tokens) for secure access control
- **Containerization**: 
  - **Docker** (isolated environments)
- **Orchestration**: 
  - **Kubernetes** (container management)
- **API Documentation**: 
  - **Swagger** (via **Swashbuckle.AspNetCore**)
- **Version Control**: 
  - **Git**
- **CI/CD**: 
  - **Azure DevOps** (automated build, test, and deployment pipelines)

---

## Installation

### Prerequisites

Ensure the following tools are installed:

- **.NET 9 SDK**
- **Node.js** and **npm** (for Angular)
- **Docker**
- **Kubernetes**
- **PostgreSQL**
- **Azure DevOps** (for CI/CD)

### Steps to Set Up Locally

1. Clone the repository:

   ```bash
   git clone https://github.com/<username>/RideOut-App.git
   cd RideOut-App

	2.	Install Angular dependencies:

npm install


	3.	Restore .NET dependencies:

dotnet restore


	4.	Build the .NET application:

dotnet build


	5.	Run database migrations (if using Entity Framework):

dotnet ef migrations add InitialCreate
dotnet ef database update


	6.	Start the application:
	•	Frontend (Angular):

ng serve


	•	Backend (.NET):

dotnet run


	7.	Test with Postman: Use Postman for testing API endpoints.

Usage

Once the app is running locally, you can:
	•	Create a user account to join events.
	•	Admins can approve or reject participants for events.
	•	Participants will receive authentication tokens to access event location details, valid for 30 minutes.

Database Schema

The RideOut app utilizes the following key tables:
	•	Users: Stores user information (UserID, Name, Email, PasswordHash, Location, ProfilePicture, etc.)
	•	RideOuts: Stores event details (RideOutID, HostUserID, Title, Description, Location, DateTime, MaxParticipants)
	•	Participants: Tracks user participation in events (ParticipantID, RideOutID, UserID, Status)
	•	Messages (optional): Allows users to send messages within events (MessageID, SenderUserID, MessageText, SentAt)
	•	Reviews (optional): Allows users to leave reviews for events (ReviewID, Rating, Comment)

API

The RideOut app provides the following API endpoints:
	•	POST /api/auth/register: Register a new user.
	•	POST /api/auth/login: Login and retrieve an authentication token.
	•	GET /api/rideouts: List public events.
	•	POST /api/rideouts: Create a new event (Admin only).
	•	POST /api/rideouts/{id}/confirm: Confirm a participant (Admin only).
	•	GET /api/rideouts/{id}/location: Get event location (requires valid token).

Authentication

The app uses JWT (JSON Web Tokens) for secure authentication. Here’s how it works:
	1.	Login: Users log in to receive an access token.
	2.	Token Expiry: Tokens expire after 30 minutes.
	3.	Access: Only users with a valid token can access event location details.

Deployment

To deploy the application:
	1.	Build Docker Images:

docker build -t rideout-app .


	2.	Deploy with Kubernetes:
	•	Use Kubernetes to deploy the app on your preferred cloud provider (e.g., Azure, AWS).
	•	Set up a Kubernetes cluster and deploy using kubectl.
	3.	Set up CI/CD Pipelines:
	•	Use Azure DevOps for automated build, test, and deployment pipelines.

Contributing

We welcome contributions to RideOut! Here’s how you can contribute:
	1.	Fork the repository and clone your fork.
	2.	Create a new branch for your feature or bug fix.
	3.	Make changes and test them thoroughly.
	4.	Submit a pull request to the main repository.

License

This project is licensed under the MIT License - see the LICENSE file for details.