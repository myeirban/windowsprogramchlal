# POS System

This is a Point of Sale (POS) system with a clean architecture structure.

## Project Structure

The solution is organized into the following projects:

### Core (POS.Core)
Contains the core business logic of the application:
- POSSystem.cs - Main system class
- Cart.cs - Shopping cart implementation

### UI (POS.UI)
Contains all Windows Forms user interface components:
- MainPosForm.cs - Main POS interface
- PayForm.cs - Payment processing form
- BaraaniiManagementForm.cs - Product management form
- BaraaniiAngilaliinManagementForm.cs - Category management form

### Data (POS.Data)
Handles data access and persistence:
- DatabaseRepository.cs - Database connection and operations
- ProductRepository.cs - Product data access
- CategoryRepository.cs - Category data access
- UserRepository.cs - User data access

### Services (POS.Services)
Contains business services:
- OrderService.cs - Order processing
- PaymentService.cs - Payment processing
- PrintingService.cs - Receipt printing
- ProductService.cs - Product management
- AuthService.cs - Authentication

### Models (POS.Models)
Contains data models:
- Product.cs - Product model
- Category.cs - Category model
- User.cs - User model
- Sale.cs - Sale model
- SaleItem.cs - Sale item model

### Utils (POS.Utils)
Contains utility classes and helper functions.

## Dependencies
- .NET 7.0
- Windows Forms
- System.Data.SQLite

## Getting Started
1. Open the solution in Visual Studio
2. Restore NuGet packages
3. Build the solution
4. Run the application 