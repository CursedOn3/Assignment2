# WeAreCars Rental System - Complete Project Summary

## CET131 Assessment 2 - Dual Implementation

This repository contains **TWO COMPLETE IMPLEMENTATIONS** of the WeAreCars Rental System:

---

## ?? Project 1: Console Application

**Location:** `WeAreCarsRentalSystem/`

### Features
? Text-based console interface  
? Staff login system  
? Customer data collection  
? Rental options selection  
? Cost calculation  
? Booking confirmation  
? Input validation  
? Password masking  
? Color-coded output  

### Technology Stack
- C# Console Application
- .NET 6.0
- No external dependencies
- No database required

### How to Run
```bash
cd WeAreCarsRentalSystem
dotnet run
```

### Credentials
- Username: `sta001`
- Password: `givemethekeys123`

---

## ??? Project 2: Windows Forms Application with Database

**Location:** `WeAreCarsRentalSystemWinForms/`

### Features
? Professional Windows Forms GUI  
? Welcome splash screen  
? Staff login form  
? Main booking form with grouped sections  
? Real-time cost calculation  
? **Supabase PostgreSQL database integration**  
? SSL/TLS encrypted database connection  
? Parameterized SQL queries  
? Comprehensive input validation  
? Error handling with user feedback  
? Booking confirmation dialogs  
? Data persistence  

### Technology Stack
- C# Windows Forms
- .NET 10.0
- Npgsql 8.0.1 (PostgreSQL driver)
- Supabase (Cloud PostgreSQL)
- SSL/TLS encryption

### Database Schema
```sql
bookings (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(100),
    surname VARCHAR(100),
    address TEXT,
    age INTEGER,
    rental_days INTEGER,
    car_type VARCHAR(50),
    fuel_type VARCHAR(50),
    extras TEXT,
    total_cost DECIMAL(10,2),
    created_at TIMESTAMP
)
```

### Setup Required

1. **Configure Database Connection**
   - Open `WeAreCarsRentalSystemWinForms/DatabaseHelper.cs`
   - Update connection string with your Supabase credentials
   - See `WeAreCarsRentalSystemWinForms/DATABASE_CONFIG.md` for detailed instructions

2. **Run the Application**
   ```bash
   cd WeAreCarsRentalSystemWinForms
   dotnet run
   ```

### Credentials
- Username: `sta001`
- Password: `givemethekeys123`

---

## ?? Feature Comparison

| Feature | Console App | Windows Forms App |
|---------|-------------|-------------------|
| Welcome Screen | ? Text | ? GUI Form |
| Staff Login | ? Console | ? GUI Form |
| Password Masking | ? Asterisks | ? Password Field |
| Customer Details | ? Text Input | ? TextBoxes |
| Age Validation | ? Yes | ? Yes |
| Licence Check | ? Yes/No | ? Radio Buttons |
| Rental Days | ? 1-28 | ? NumericUpDown |
| Car Type | ? Menu | ? ComboBox |
| Fuel Type | ? Menu | ? ComboBox |
| Optional Extras | ? Yes/No | ? CheckBoxes |
| Cost Display | ? Summary | ? Real-time |
| Confirmation | ? Yes/No | ? Dialog Box |
| Database | ? No | ? PostgreSQL |
| Data Persistence | ? No | ? Yes |
| Error Messages | ? Console | ? MessageBox |

---

## ?? Business Rules (Both Applications)

### Customer Requirements
- **Age:** Must be 18 or over
- **Driving Licence:** Must have valid licence
- **Name & Address:** Required fields

### Rental Options
- **Duration:** 1-28 days
- **Base Rate:** £25 per day

### Car Types
- City Car: +£0
- Family Car: +£50
- Sports Car: +£75
- SUV: +£65

### Fuel Types
- Petrol: +£0
- Diesel: +£0
- Hybrid: +£30
- Electric: +£50

### Optional Extras
- Unlimited Mileage: +£10 per day
- Breakdown Cover: +£2 per day

---

## ?? Repository Structure

```
Assignment/
??? WeAreCarsRentalSystem/              # Console Application
?   ??? Program.cs                      # Main application logic
?   ??? WeAreCarsRentalSystem.csproj    # Project file
?   ??? README.md                       # Console app documentation
?
??? WeAreCarsRentalSystemWinForms/      # Windows Forms Application
?   ??? Program.cs                      # Application entry point
?   ??? DatabaseHelper.cs               # Database operations
?   ??? WelcomeForm.cs                  # Splash screen
?   ??? WelcomeForm.Designer.cs         # Splash screen UI
?   ??? LoginForm.cs                    # Login logic
?   ??? LoginForm.Designer.cs           # Login UI
?   ??? BookingForm.cs                  # Booking logic
?   ??? BookingForm.Designer.cs         # Booking UI
?   ??? database_setup.sql              # SQL setup script
?   ??? DATABASE_CONFIG.md              # Database configuration guide
?   ??? README.md                       # WinForms app documentation
?   ??? WeAreCarsRentalSystemWinForms.csproj
?
??? LICENSE
??? README.md                           # This file
```

---

## ?? Quick Start Guide

### For Console Application
```bash
cd WeAreCarsRentalSystem
dotnet run
```
**Login:** sta001 / givemethekeys123

### For Windows Forms Application

1. **Setup Database (First Time Only)**
   - Create Supabase account at https://supabase.com
   - Create new project
   - Get database connection details
   - Update `DatabaseHelper.cs` with your credentials
   - See `DATABASE_CONFIG.md` for step-by-step guide

2. **Run Application**
   ```bash
   cd WeAreCarsRentalSystemWinForms
   dotnet run
   ```
   **Login:** sta001 / givemethekeys123

---

## ?? Academic Suitability

Both implementations are suitable for CET131 Assessment 2:

### Console Application
- ? Demonstrates procedural programming
- ? Shows input/output handling
- ? Implements validation logic
- ? Uses structured methods
- ? No dependencies (portable)

### Windows Forms Application
- ? Demonstrates GUI development
- ? Shows database integration
- ? Implements cloud connectivity
- ? Uses secure database practices
- ? Professional error handling
- ? Real-world application structure

---

## ?? Documentation

Each project includes comprehensive documentation:

- **Console App:** `WeAreCarsRentalSystem/README.md`
- **Windows Forms:** `WeAreCarsRentalSystemWinForms/README.md`
- **Database Setup:** `WeAreCarsRentalSystemWinForms/DATABASE_CONFIG.md`
- **SQL Scripts:** `WeAreCarsRentalSystemWinForms/database_setup.sql`

---

## ?? Security Features (Windows Forms)

- ? Parameterized SQL queries (prevents SQL injection)
- ? SSL/TLS encrypted database connection
- ? Password input masking
- ? Input validation and sanitization
- ? Database constraint checks
- ? Error handling without exposing sensitive data

---

## ?? Testing Both Applications

### Console Application Test Cases
1. ? Welcome screen displays
2. ? Correct login succeeds
3. ? Incorrect login fails
4. ? Age < 18 blocks booking
5. ? No licence blocks booking
6. ? Empty fields rejected
7. ? Cost calculation correct
8. ? Summary displays correctly

### Windows Forms Test Cases
1. ? Welcome form displays
2. ? Login validation works
3. ? All customer fields validate
4. ? Age/licence validation
5. ? Real-time cost updates
6. ? Database connection works
7. ? Data saves correctly
8. ? Error messages display
9. ? Form resets after booking
10. ? Confirmation dialog shows

---

## ?? Key Learning Outcomes

### Console Application
- Console I/O operations
- User input validation
- Menu-driven interfaces
- Procedural programming
- Basic authentication

### Windows Forms Application
- Windows Forms development
- Event-driven programming
- Database connectivity
- Cloud service integration
- Error handling strategies
- User interface design
- Data persistence
- Security best practices

---

## ??? Prerequisites

### For Both Applications
- Windows OS (Windows Forms requirement)
- .NET SDK (6.0+ for console, 10.0+ for WinForms)
- Visual Studio 2022 or VS Code (recommended)

### Additional for Windows Forms
- Internet connection (for Supabase)
- Supabase account (free tier available)

---

## ?? Support & Troubleshooting

### Console Application
- Check .NET SDK is installed: `dotnet --version`
- Ensure terminal supports ANSI colors
- Verify correct working directory

### Windows Forms Application
- Verify database connection string in `DatabaseHelper.cs`
- Check Supabase project is active
- Ensure internet connectivity
- Review `DATABASE_CONFIG.md` for setup
- Check Npgsql package is installed

---

## ?? License

Created for CET131 Assessment 2 - Academic Use Only

---

## ????? Author

CET131 Student Submission  
Assessment 2 - WeAreCars Rental System

---

## ? Highlights

### Why Two Implementations?

1. **Console Application** - Demonstrates core programming fundamentals
2. **Windows Forms Application** - Shows real-world application development

Both meet the assignment requirements, but the Windows Forms version provides:
- Professional user interface
- Database persistence
- Cloud integration
- Enterprise-level error handling

Choose the implementation that best suits your assessment requirements!

---

**Last Updated:** January 2025