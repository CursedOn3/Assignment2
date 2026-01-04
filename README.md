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

## ??? Project 2: Windows Forms Application with SQLite Database

**Location:** `WeAreCarsRentalSystemWinForms/`

### ? Key Feature: **ZERO SETUP REQUIRED!**

This version uses **SQLite** - a local, file-based database:
- ? No account creation
- ? No internet connection
- ? No configuration
- ? **Just run and it works!**

### Features
? Professional Windows Forms GUI  
? Welcome splash screen  
? Staff login form  
? Main booking form with grouped sections  
? Real-time cost calculation  
? **SQLite local database** (auto-created)  
? Parameterized SQL queries  
? Comprehensive input validation  
? Error handling with user feedback  
? Booking confirmation dialogs  
? Data persistence (local file)  
? **No external services required**  

### Technology Stack
- C# Windows Forms
- .NET 10.0
- Microsoft.Data.Sqlite 8.0.0
- SQLite 3 (local database)
- Single-file database

### Database Schema
```sql
CREATE TABLE bookings (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    first_name TEXT NOT NULL,
    surname TEXT NOT NULL,
    address TEXT NOT NULL,
    age INTEGER NOT NULL CHECK (age >= 18),
    rental_days INTEGER NOT NULL CHECK (rental_days >= 1 AND rental_days <= 28),
    car_type TEXT NOT NULL,
    fuel_type TEXT NOT NULL,
    extras TEXT,
    total_cost REAL NOT NULL CHECK (total_cost >= 0),
    created_at TEXT DEFAULT (datetime('now'))
);
```

### How to Run (NO SETUP!)

```bash
cd WeAreCarsRentalSystemWinForms
dotnet run
```

**That's it!** Database is created automatically on first run.

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
| Database | ? No | ? SQLite (local) |
| Data Persistence | ? No | ? Yes (local file) |
| Error Messages | ? Console | ? MessageBox |
| Setup Required | ? None | ? **None!** |
| Internet Required | ? No | ? **No!** |

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
?   ??? DatabaseHelper.cs               # SQLite database operations
?   ??? WelcomeForm.cs                  # Splash screen
?   ??? WelcomeForm.Designer.cs         # Splash screen UI
?   ??? LoginForm.cs                    # Login logic
?   ??? LoginForm.Designer.cs           # Login UI
?   ??? BookingForm.cs                  # Booking logic
?   ??? BookingForm.Designer.cs         # Booking UI
?   ??? database_setup.sql              # SQLite schema (reference)
?   ??? DATABASE_CONFIG.md              # Database info (no config needed!)
?   ??? README.md                       # WinForms app documentation
?   ??? WeAreCarsRentalSystemWinForms.csproj
?   ??? bin/Debug/net10.0-windows/
?       ??? WeAreCarsRental.db         # SQLite database (auto-created)
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

**NO SETUP REQUIRED!**

```bash
cd WeAreCarsRentalSystemWinForms
dotnet run
```

- Database created automatically on first run
- All data saved to local `WeAreCarsRental.db` file
- Works offline - no internet needed
- **Login:** sta001 / givemethekeys123

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
- ? Shows database integration (SQLite)
- ? **Zero configuration** - perfect for assessors
- ? Uses secure database practices
- ? Professional error handling
- ? Real-world application structure
- ? **Self-contained** - database included
- ? **Portable** - single file database

---

## ?? Documentation

Each project includes comprehensive documentation:

- **Console App:** `WeAreCarsRentalSystem/README.md`
- **Windows Forms:** `WeAreCarsRentalSystemWinForms/README.md`
- **Database Info:** `WeAreCarsRentalSystemWinForms/DATABASE_CONFIG.md`
- **Quick Start:** `WeAreCarsRentalSystemWinForms/QUICK_START.md`
- **SQL Schema:** `WeAreCarsRentalSystemWinForms/database_setup.sql`

---

## ?? Security Features (Windows Forms)

- ? Parameterized SQL queries (prevents SQL injection)
- ? Password input masking
- ? Input validation and sanitization
- ? Database constraint checks
- ? Error handling without exposing sensitive data
- ? Local data storage (no cloud security concerns)

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
6. ? **Database auto-creates**
7. ? Data saves correctly
8. ? Error messages display
9. ? Form resets after booking
10. ? Confirmation dialog shows
11. ? **Data persists between runs**

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
- **Local database connectivity (SQLite)**
- Error handling strategies
- User interface design
- Data persistence
- Security best practices
- **Self-contained application design**

---

## ??? Prerequisites

### For Both Applications
- Windows OS (Windows Forms requirement)
- .NET SDK (6.0+ for console, 10.0+ for WinForms)
- Visual Studio 2022 or VS Code (recommended)

### Additional for Windows Forms
- ? **NO additional requirements!**
- ? No internet connection needed
- ? No account creation
- ? No database server setup
- ? **Just run!**

---

## ?? Viewing Database Data

### Option 1: DB Browser for SQLite (Recommended)
1. Download from https://sqlitebrowser.org/
2. Open `bin/Debug/net10.0-windows/WeAreCarsRental.db`
3. View all bookings in the `bookings` table

### Option 2: VS Code Extension
1. Install "SQLite Viewer" extension
2. Right-click on `WeAreCarsRental.db`
3. Select "Open Database"

---

## ?? Support & Troubleshooting

### Console Application
- Check .NET SDK is installed: `dotnet --version`
- Ensure terminal supports ANSI colors
- Verify correct working directory

### Windows Forms Application
- **No configuration needed!**
- If database errors occur, delete `WeAreCarsRental.db` and restart
- Database will recreate automatically
- Check .NET 10.0 is installed

---

## ?? Why SQLite is Perfect for This Project

| Advantage | Benefit |
|-----------|---------|
| **Zero Setup** | Runs immediately - perfect for assessors |
| **Portable** | Single file database - easy to backup/move |
| **Offline** | No internet required - works anywhere |
| **Transparent** | Database file can be easily viewed |
| **Professional** | Used by Android, iOS, browsers, etc. |
| **Fast** | Excellent performance for this use case |
| **Self-Contained** | Everything in one project |
| **Academic** | Perfect complexity level for CET131 |

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
2. **Windows Forms Application** - Shows real-world application development with database

### Windows Forms Advantages:
- ? Professional user interface
- ? Local database persistence
- ? **Zero setup** - no configuration
- ? Enterprise-level error handling
- ? **Perfect for assessment** - assessors can run immediately
- ? **Self-contained** - all data in one file

### Best for Academic Submission:
**Windows Forms + SQLite** is ideal because:
- Assessor can clone and run immediately
- No accounts, passwords, or configuration
- Database included with submission
- All data visible and accessible
- Professional yet appropriate complexity

---

**Both implementations are ready for CET131 Assessment 2!**

Choose based on your needs:
- **Simple demonstration:** Use Console
- **Full-featured with database:** Use Windows Forms ? **Recommended**

---

**Last Updated:** January 2025 (SQLite Version)