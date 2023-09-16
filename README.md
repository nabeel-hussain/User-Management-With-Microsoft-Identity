# User Management With Microsoft Identity

This project is a User Management System built on .NET Core 7, featuring role-based authentication using JWT (JSON Web Tokens) and Microsoft Identity.

## Overview

The User Management Project provides a robust foundation for managing user accounts with granular access control through roles. It leverages JWT for secure authentication and authorization, ensuring that users have appropriate access to system resources.

## Key Features

- **User Registration**: New users can easily register with the system.
- **User Login**: Secure authentication using JWT for access to protected resources.
- **Role-Based Access Control**: Assign roles to users, granting them specific permissions.
- **User Profile Management**: Users can update their profiles and passwords.
- **Admin Dashboard**: Administrators have access to a dashboard for managing users and roles.
- **Security**: Built-in security measures, including password hashing, to protect user data.

## Getting Started

Follow these steps to set up and run the project:

1. **Prerequisites**: Ensure you have .NET Core 7 installed.

2. **Clone the Repository**: Clone this repository to your local machine.

3. **Configuration**: Configure your database connection and other settings in the `appsettings.json` file.

4. **Database Migration**: Run database migrations to create the necessary tables.

5. **Run the Application**: Use `dotnet run` to start the application.

6. **Access the Application**: Visit `http://localhost:PORT` in your browser to access the application.

## Usage

- Register new users and assign roles.
- Log in using registered credentials to access protected resources.
- Admins can manage users and roles through the admin dashboard.
# UM.Api REST API Documentation

This documentation provides an overview of the endpoints and usage of the UM.Api REST API.

## Table of Contents

1. [Introduction](#introduction)
2. [Authentication](#authentication)
3. [Role Controller](#role-controller)
   - [Add Role](#1-add-role)
   - [Update Role](#2-update-role)
   - [Delete Role](#3-delete-role)
4. [Security Controller](#security-controller)
   - [User Login](#4-user-login)
   - [Change Password](#5-change-password)
5. [User Controller](#user-controller)
   - [Add User](#6-add-user)
   - [Update User](#7-update-user)
   - [Delete User](#8-delete-user)
   - [Get User by ID](#10-get-user-by-id)
6. [Schemas](#schemas)
7. [Authentication](#authentication)
8. [Security](#security)

## Introduction

The UM.Api is a RESTful API that provides functionality related to roles, users, and security. This documentation outlines the available endpoints, request/response schemas, and authentication requirements.

## Authentication

This API uses JWT (JSON Web Token) for authentication. To access protected endpoints, include a valid JWT token in the `Authorization` header using the Bearer scheme.

## Role Controller

### 1. Add Role

**Endpoint:** `/api/Role/AddRole`

**Method:** POST

Description: Add a new role with the specified parameters.

Request Body Schema: [CreateRoleCommand](#createrolecommand)

Response Schema: [CreateRoleResponse](#createroleresponse)

### 2. Update Role

**Endpoint:** `/api/Role/UpdateRole`

**Method:** POST

Description: Update an existing role with the specified parameters.

Request Body Schema: [UpdateRoleCommand](#updaterolecommand)

### 3. Delete Role

**Endpoint:** `/api/Role/DeleteRole`

**Method:** POST

Description: Delete a role by its ID.

Request Body Schema: [DeleteRoleCommand](#deleterolecommand)

## Security Controller

### 4. User Login

**Endpoint:** `/api/Security/Login`

**Method:** POST

Description: User login with email and password.

Request Body Schema: [LoginCommand](#logincommand)

Response Schema: [LoginCommandResponse](#logincommandresponse)

### 5. Change Password

**Endpoint:** `/api/Security/ChangePassword`

**Method:** PUT

Description: Change the password for a user.

Request Body Schema: [ChangePasswordCommand](#changepasswordcommand)

## User Controller

### 6. Add User

**Endpoint:** `/api/User/AddUser`

**Method:** POST

Description: Add a new user with the specified parameters.

Request Body Schema: [CreateUserCommand](#createusercommand)

Response Schema: [CreateUserResponse](#createuserresponse)

### 7. Update User

**Endpoint:** `/api/User/UpdateUser`

**Method:** PUT

Description: Update an existing user with the specified parameters.

Request Body Schema: [UpdateUserCommand](#updateusercommand)

Response Schema: [UpdateUserCommandResponse](#updateusercommandresponse)

### 8. Delete User

**Endpoint:** `/api/User/DeleteUser`

**Method:** DELETE

Description: Delete a user by its ID.

Request Body Schema: [CreateUserCommand](#createusercommand)

### 9. Get User by ID

**Endpoint:** `/api/User/GetUserById`

**Method:** GET

Description: Get a user by their ID.

## Schemas

- [ChangePasswordCommand](#changepasswordcommand)
- [CreateRoleCommand](#createrolecommand)
- [CreateRoleResponse](#createroleresponse)
- [CreateUserCommand](#createusercommand)
- [CreateUserResponse](#createuserresponse)
- [DeleteRoleCommand](#deleterolecommand)
- [LoginCommand](#logincommand)
- [LoginCommandResponse](#logincommandresponse)
- [Role](#role)
- [RoleStatus](#rolestatus)
- [SlimUser](#slimuser)
- [UpdateRoleCommand](#updaterolecommand)
- [UpdateUserCommand](#updateusercommand)
- [UpdateUserCommandResponse](#updateusercommandresponse)
- [User](#user)
- [UserRole](#userrole)
- [UserStatus](#userstatus)

## Authentication

Authentication for this API is based on JWT (JSON Web Tokens). To access protected endpoints, you must include a valid JWT token in the `Authorization` header using the Bearer scheme.

## Security

The API utilizes JWT Authorization Header with the Bearer Scheme for authentication. Ensure that you obtain a valid JWT token before accessing protected endpoints.

For more details on each endpoint, request/response schemas, and authentication, please refer to the relevant sections above.




## Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow the guidelines in the `CONTRIBUTING.md` file.


## Contact

For any questions or issues, please contact Nabeel Hussain at nabeel.hussain1602@gmail.com.
