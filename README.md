
# SealCraft Application - AWS Secrets Manager and PostgreSQL Integration

This project is a Web API application developed using .NET 9. It securely manages application configurations with AWS Secrets Manager and integrates with PostgreSQL for database connectivity.

## Purpose of the Project

The purpose of the SealCraft application is to demonstrate how to securely handle sensitive configuration data, such as database connection strings, without hard-coding them in the application. By using AWS Secrets Manager, the application ensures that secrets are retrieved dynamically and securely at runtime. This setup promotes better security practices and simplifies configuration management, especially in cloud-based or multi-environment deployments.

## Table of Contents

- [SealCraft Application - AWS Secrets Manager and PostgreSQL Integration](#sealcraft-application---aws-secrets-manager-and-postgresql-integration)
  - [Purpose of the Project](#purpose-of-the-project)
  - [Table of Contents](#table-of-contents)
  - [About the Project](#about-the-project)
  - [Technologies Used](#technologies-used)
  - [Prerequisites](#prerequisites)
  - [Setup Instructions](#setup-instructions)
    - [1. Clone the Repository](#1-clone-the-repository)
    - [2. Set AWS Environment Variables](#2-set-aws-environment-variables)
      - [Linux/macOS:](#linuxmacos)
      - [Windows (PowerShell):](#windows-powershell)
    - [3. Define a Secret in AWS Secrets Manager](#3-define-a-secret-in-aws-secrets-manager)
    - [4. Run the Application](#4-run-the-application)
  - [Environment Variables Configuration](#environment-variables-configuration)
  - [Database Connection](#database-connection)

## About the Project

SealCraft securely loads configuration data (e.g., database connection strings) from AWS Secrets Manager. This approach eliminates the need to hard-code sensitive information and ensures seamless integration with PostgreSQL.

## Technologies Used

- **.NET 9**: For Web API development.
- **AWS Secrets Manager**: To securely store and manage sensitive information.
- **PostgreSQL**: Relational database system.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [AWS CLI](https://aws.amazon.com/tr/secrets-manager/) (configured with appropriate credentials)
- PostgreSQL instance (local or remote)

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/emreesahiiinn/SealCraft.git
cd SealCraft
```

### 2. Set AWS Environment Variables

#### Linux/macOS:
Edit your `~/.bashrc` or `~/.zshrc` file:

```bash
export AWS_ACCESS_KEY_ID=yourAccessKeyId
export AWS_SECRET_ACCESS_KEY=yourSecretAccessKey
```

Apply the changes:
```bash
source ~/.bashrc
```

#### Windows (PowerShell):
```powershell
$env:AWS_ACCESS_KEY_ID="yourAccessKeyId"
$env:AWS_SECRET_ACCESS_KEY="yourSecretAccessKey"
```

### 3. Define a Secret in AWS Secrets Manager

Create a secret in AWS Secrets Manager containing the PostgreSQL connection string. Example JSON format:
```json
{
    "ConnectionStrings": {
        "PostgresConnection": "Host=192.168.2.34;Port=5432;Database=SealCraftDataBase;Username=postgres;Password=postgres"
    }
}
```

### 4. Run the Application

```bash
dotnet run
```

## Environment Variables Configuration

AWS credentials are automatically retrieved at runtime using `Environment.GetEnvironmentVariable`. Ensure that the environment variables are correctly set.

## Database Connection

The `SealCraftDbContext` class manages the PostgreSQL database connection using Entity Framework Core. The connection string is loaded from AWS Secrets Manager.