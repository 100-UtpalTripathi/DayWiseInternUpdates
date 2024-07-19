# Azure Resource Deployment with ARM Templates

This repository contains Azure Resource Manager (ARM) templates to deploy an Azure SQL Server, SQL Database, and Azure Key Vault using Azure CLI.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Deploying the SQL Server and Database](#deploying-the-sql-server-and-database)
- [Deploying the Key Vault and Secret](#deploying-the-key-vault-and-secret)
- [Parameters](#parameters)
- [Contributing](#contributing)
- [License](#license)

## Prerequisites

Before you begin, ensure you have the following:

- An active Azure subscription
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli) installed on your local machine
- Appropriate permissions to create resources in your Azure subscription

## Getting Started

1. **Clone this repository** to your local machine:

    ```bash
    git clone https://github.com/your-username/azure-arm-templates.git
    cd azure-arm-templates
    ```

2. **Update the parameters** in the ARM template files (`azureTemplateSQLDeployment.json` and `azureTemplateVaultDeployment.json`) as per your requirements.

## Deploying the SQL Server and Database

To deploy the SQL Server and Database, run the following command:

```bash
az deployment group create --resource-group <your-resource-group> \
  --template-file azureTemplateSQLDeployment.json \
  --parameters sqlServerName=<your-sql-server-name> \
              adminLogin=<your-admin-login> \
              adminPassword=<your-admin-password> \
              databaseName=<your-database-name>
```

3. **Update the parameters** in the ARM template file (`azureTemplateVaultDeployment.json`) as per your requirements.

## Deploying the Key Vault and Secret

To deploy the Key Vault and add the SQL connection string as a secret, use the following command:

```bash
az deployment group create --resource-group <your-resource-group> \
  --template-file azureTemplateVaultDeployment.json \
  --parameters keyVaultName=<your-key-vault-name> \
              secretName=<your-secret-name> \
              sqlConnectionString="Server=tcp:<your-sql-server-name>.database.windows.net,1433;Initial Catalog=<your-database-name>;Persist Security Info=False;User ID=<your-admin-login>;Password=<your-admin-password>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

```

