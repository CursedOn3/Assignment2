# WeAreCars Rental System - Windows Forms Application

A Windows Forms-based car rental management system developed for CET131 Assessment 2 with **SQLite** database integration.

## ? Key Feature: Zero Setup Required!

This application uses **SQLite** - a local, file-based database that requires:
- ? No account creation
- ? No internet connection
- ? No configuration
- ? Just run and it works!

## Features

### 1. Welcome/Splash Screen
- Professional welcome interface
- Application title and brief instructions
- "Proceed to Login" button to continue

### 2. Staff Authentication
- Secure login form with credentials validation
- Fixed credentials:
  - **Username:** `sta001`
  - **Password:** `givemethekeys123`
- Password masking for security
- Error message display for invalid credentials
- Access denial for incorrect login

### 3. Main Booking Form

#### Customer Details Section
- **First Name** (required)
- **Surname** (required)
- **Address** (required)
- **Age** (numeric input, must be 18 or over)
- **Valid Driving Licence** (Yes/No radio buttons)
- Validation prevents booking if age < 18 or no valid licence

#### Rental Details Section
- **Number of Rental Days** (1-28, numeric input)
- **Car Type Selection** (ComboBox):
  - City Car (+£0)
  - Family Car (+£50)
  - Sports Car (+£75)
  - SUV (+£65)
- **Fuel Type Selection** (ComboBox):
  - Petrol (+£0)
  - Diesel (+£0)
  - Hybrid (+£30)
  - Electric (+£50)

#### Optional Extras Section (CheckBoxes)
- Unlimited Mileage (+£10 per day)
- Breakdown Cover (+£2 per day)

### 4. Cost Calculation
- **Base Price:** £25 per day
- **Real-time calculation:** Total cost updates automatically when options change
- **Clear display:** Large, prominent total cost display
- **Itemized breakdown** shown in confirmation dialog

### 5. Database Integration (SQLite)

#### Database Features
- **Local file-based database** - No external services required
- **Automatic creation** - Database and tables created on first run
- **Data persistence** - All bookings saved locally
- **Single file** - Easy to backup and portable
- **Location:** `bin/Debug/net10.0-windows/WeAreCarsRental.db`

#### Database Table: `bookings`
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

#### Security Features
- **Parameterized SQL queries** prevent SQL injection
- **Input validation** before database operations
- **Error handling** with user-friendly messages
- **Database constraints** enforce data integrity

### 6. Booking Confirmation
- Summary dialog showing all booking details
- Customer information
- Rental duration and selections
- Total cost
- Yes/No confirmation before saving
- Success message with booking confirmation
- Database error handling with clear messages

## Setup Instructions

### Prerequisites
- Windows operating system
- .NET 10.0 or later
- Visual Studio 2022 (or later) or Visual Studio Code

**That's it! No database setup required!**

### Running the Application

1. **Using Visual Studio:**
   ```
   - Open WeAreCarsRentalSystemWinForms.csproj
   - Press F5 or click "Start"
   ```

2. **Using Command Line:**
   ```bash
   cd WeAreCarsRentalSystemWinForms
   dotnet build
   dotnet run
   ```

3. **First Run:**
   - The application will automatically create `WeAreCarsRental.db`
   - Database tables and indexes are created automatically
   - Start using the application immediately!

## Application Flow

1. **Launch** ? Welcome screen appears (database auto-created)
2. **Click "Proceed to Login"** ? Login form opens
3. **Enter credentials** ? Click "Login" (sta001 / givemethekeys123)
4. **Fill customer details** ? Enter all required information
5. **Select rental options** ? Choose car type, fuel type, extras
6. **Review total cost** ? Displayed in real-time
7. **Click "Confirm Booking"** ? Review summary dialog
8. **Confirm** ? Booking saved to local database
9. **Success message** ? Form resets for next booking

## Project Structure

```
WeAreCarsRentalSystemWinForms/
??? Program.cs                      # Application entry point
??? DatabaseHelper.cs               # SQLite database operations
??? WelcomeForm.cs                  # Splash/welcome screen
??? WelcomeForm.Designer.cs         # Welcome form UI design
??? LoginForm.cs                    # Staff authentication
??? LoginForm.Designer.cs           # Login form UI design
??? BookingForm.cs                  # Main booking functionality
??? BookingForm.Designer.cs         # Booking form UI design
??? WeAreCarsRentalSystemWinForms.csproj  # Project file
??? bin/Debug/net10.0-windows/
    ??? WeAreCarsRental.db         # SQLite database (auto-created)
```

## Validation Rules

### Customer Details
- **First Name:** Cannot be empty
- **Surname:** Cannot be empty
- **Address:** Cannot be empty
- **Age:** Must be 18 or older
- **Driving Licence:** Must select "Yes"

### Rental Details
- **Rental Days:** Must be between 1 and 28
- **Car Type:** Must select an option
- **Fuel Type:** Must select an option

## Error Handling

The application handles:
- Empty or invalid customer details
- Age restrictions (under 18)
- Missing driving licence
- Database file access issues
- SQL execution errors
- Invalid data types

All errors display user-friendly messages with clear guidance.

## Viewing Your Data

### Option 1: DB Browser for SQLite (Recommended)
1. Download from https://sqlitebrowser.org/
2. Install and open
3. Open the `WeAreCarsRental.db` file
4. Browse the `bookings` table

### Option 2: Visual Studio Code
1. Install "SQLite Viewer" extension
2. Right-click `WeAreCarsRental.db`
3. Select "Open Database"

### Option 3: SQL Queries (in code)
The database supports standard SQL queries:
```sql
-- View all bookings
SELECT * FROM bookings ORDER BY created_at DESC;

-- Count total bookings
SELECT COUNT(*) FROM bookings;

-- Calculate total revenue
SELECT SUM(total_cost) FROM bookings;
```

## Technical Details

- **Framework:** .NET 10.0 Windows Forms
- **Language:** C# 12.0
- **Database:** SQLite 3
- **Database Driver:** Microsoft.Data.Sqlite 8.0.0
- **UI Framework:** Windows Forms
- **Architecture:** Event-driven with form-based navigation

## Code Quality Features

? **Parameterized SQL Queries** - No string concatenation  
? **Input Validation** - All fields validated before processing  
? **Error Handling** - Try-catch blocks with user messages  
? **Clear Variable Names** - Self-documenting code  
? **Structured Methods** - Single responsibility principle  
? **Constants** - All pricing and configuration centralized  
? **Comments** - Clear documentation  
? **Minimal Dependencies** - Only SQLite for database  

## Academic Suitability

This project is designed for CET131 assessment and demonstrates:
- Windows Forms application development
- Local database integration
- User input validation
- Error handling and user feedback
- Form-based navigation
- Event-driven programming
- Secure database operations
- Professional UI design
- Self-contained application

## Advantages of SQLite for Assessment

? **Zero Setup** - Works immediately, no configuration  
? **Portable** - Single database file, easy to include in submission  
? **Offline** - No internet connection required  
? **Transparent** - Assessors can easily view data  
? **Professional** - Used by Android, iOS, browsers, and more  
? **Fast** - Excellent performance for this use case  
? **Reliable** - Battle-tested industry standard  

## Testing Checklist

- [ ] Welcome screen displays correctly
- [ ] Login with correct credentials succeeds
- [ ] Login with incorrect credentials fails
- [ ] Database file is created automatically
- [ ] Age < 18 prevents booking
- [ ] No driving licence prevents booking
- [ ] Empty fields show validation errors
- [ ] Total cost calculates correctly
- [ ] Booking saves to database
- [ ] Confirmation dialog shows correct details
- [ ] Form resets after successful booking
- [ ] Data persists between application runs

## Troubleshooting

### Database Issues

**Problem:** "Database is locked"  
**Solution:** 
- Close DB Browser or any tool viewing the database
- Restart the application

**Problem:** "Cannot find database file"  
**Solution:**
- Check in `bin/Debug/net10.0-windows/` directory
- Database is created on first run

**Problem:** "Table does not exist"  
**Solution:**
- Delete the `.db` file
- Restart application (will recreate automatically)

### Application Issues

**Problem:** Application won't start  
**Solution:**
```bash
# Check .NET version
dotnet --version

# Restore packages
dotnet restore

# Rebuild
dotnet clean
dotnet build
```

## Backup and Reset

### Backup Your Data
```bash
copy bin\Debug\net10.0-windows\WeAreCarsRental.db WeAreCarsRental_backup.db
```

### Reset Database
```bash
del bin\Debug\net10.0-windows\WeAreCarsRental.db
```
Database will be recreated on next run.

## Sample Data Queries

```sql
-- Recent bookings
SELECT * FROM bookings 
ORDER BY created_at DESC 
LIMIT 10;

-- Bookings by car type
SELECT car_type, COUNT(*) as count, SUM(total_cost) as revenue
FROM bookings 
GROUP BY car_type;

-- Average rental cost
SELECT AVG(total_cost) as average_cost FROM bookings;
```

## License

Created for CET131 Assessment 2 - Academic Use Only

## Author

CET131 Student Submission

---

**Perfect for Academic Submission!** ?
- Self-contained
- No external dependencies
- Database included
- Easy for assessors to run and test
