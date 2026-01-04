# WeAreCars Rental System - Windows Forms Application

A Windows Forms-based car rental management system developed for CET131 Assessment 2 with Supabase PostgreSQL database integration.

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

### 5. Database Integration (Supabase)

#### Database Table: `bookings`
```sql
CREATE TABLE bookings (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    surname VARCHAR(100) NOT NULL,
    address TEXT NOT NULL,
    age INTEGER NOT NULL,
    rental_days INTEGER NOT NULL,
    car_type VARCHAR(50) NOT NULL,
    fuel_type VARCHAR(50) NOT NULL,
    extras TEXT,
    total_cost DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

#### Security Features
- **Parameterized SQL queries** prevent SQL injection
- **SSL/TLS connection** to Supabase (SSL Mode=Require)
- **Input validation** before database operations
- **Error handling** with user-friendly messages

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
- Supabase account with PostgreSQL database

### Database Setup

1. **Create a Supabase Project**
   - Sign up at [https://supabase.com](https://supabase.com)
   - Create a new project
   - Note your database credentials

2. **Get Connection Details**
   - Go to Project Settings ? Database
   - Find your connection string information:
     - Host: `db.xxxxxxxxxxxxx.supabase.co`
     - Database: `postgres`
     - User: `postgres`
     - Password: Your database password
     - Port: `5432`

3. **Configure Connection String**
   - Open `DatabaseHelper.cs`
   - Update the `ConnectionString` constant:
   ```csharp
   private const string ConnectionString = 
       "Host=db.xxxxxxxxxxxxx.supabase.co;Database=postgres;Username=postgres;Password=your_password;SSL Mode=Require;Trust Server Certificate=true";
   ```
   - Replace:
     - `db.xxxxxxxxxxxxx.supabase.co` with your Supabase host
     - `your_password` with your database password

4. **Table Creation**
   - The application automatically creates the `bookings` table on first run
   - Alternatively, you can create it manually in Supabase SQL Editor

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

## Application Flow

1. **Launch** ? Welcome screen appears
2. **Click "Proceed to Login"** ? Login form opens
3. **Enter credentials** ? Click "Login"
4. **Fill customer details** ? Enter all required information
5. **Select rental options** ? Choose car type, fuel type, extras
6. **Review total cost** ? Displayed in real-time
7. **Click "Confirm Booking"** ? Review summary dialog
8. **Confirm** ? Booking saved to database
9. **Success message** ? Form resets for next booking

## Project Structure

```
WeAreCarsRentalSystemWinForms/
??? Program.cs                      # Application entry point
??? DatabaseHelper.cs               # Database connection and operations
??? WelcomeForm.cs                  # Splash/welcome screen
??? WelcomeForm.Designer.cs         # Welcome form UI design
??? LoginForm.cs                    # Staff authentication
??? LoginForm.Designer.cs           # Login form UI design
??? BookingForm.cs                  # Main booking functionality
??? BookingForm.Designer.cs         # Booking form UI design
??? WeAreCarsRentalSystemWinForms.csproj  # Project file
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
- Database connection failures
- SQL execution errors
- Invalid data types

All errors display user-friendly messages with clear guidance.

## Database Connectivity

### Testing Connection
The application tests database connectivity on startup and shows a warning if:
- Connection string is not configured
- Supabase server is unreachable
- Credentials are incorrect
- SSL/TLS handshake fails

### Connection String Format
```
Host=your-host.supabase.co;Database=postgres;Username=postgres;Password=your_password;SSL Mode=Require;Trust Server Certificate=true
```

**Important SSL Settings:**
- `SSL Mode=Require` - Forces encrypted connection
- `Trust Server Certificate=true` - Required for Supabase SSL certificates

## Technical Details

- **Framework:** .NET 10.0 Windows Forms
- **Language:** C# 12.0
- **Database:** PostgreSQL (via Supabase)
- **Database Driver:** Npgsql 8.0.1
- **UI Framework:** Windows Forms
- **Architecture:** Event-driven with form-based navigation

## Code Quality Features

? **Parameterized SQL Queries** - No string concatenation  
? **Input Validation** - All fields validated before processing  
? **Error Handling** - Try-catch blocks with user messages  
? **Clear Variable Names** - Self-documenting code  
? **Structured Methods** - Single responsibility principle  
? **Constants** - All pricing and configuration centralized  
? **Comments** - Clear XML documentation  
? **No External Dependencies** - Only Npgsql for database  

## Academic Suitability

This project is designed for CET131 assessment and demonstrates:
- Windows Forms application development
- Database integration with cloud services
- User input validation
- Error handling and user feedback
- Form-based navigation
- Event-driven programming
- Secure database operations
- Professional UI design

## Testing Checklist

- [ ] Welcome screen displays correctly
- [ ] Login with correct credentials succeeds
- [ ] Login with incorrect credentials fails
- [ ] Age < 18 prevents booking
- [ ] No driving licence prevents booking
- [ ] Empty fields show validation errors
- [ ] Total cost calculates correctly
- [ ] Database connection works
- [ ] Booking saves to database
- [ ] Confirmation dialog shows correct details
- [ ] Form resets after successful booking

## Troubleshooting

### Database Connection Issues

**Problem:** "Failed to connect to database"  
**Solution:** 
- Verify Supabase connection string in `DatabaseHelper.cs`
- Check internet connectivity
- Verify Supabase project is active
- Confirm database password is correct

**Problem:** "SSL connection failed"  
**Solution:**
- Ensure `SSL Mode=Require` is in connection string
- Add `Trust Server Certificate=true`
- Check firewall settings

### Application Issues

**Problem:** "Table does not exist"  
**Solution:**
- Application should create table automatically
- Manually run CREATE TABLE query in Supabase SQL Editor
- Check database permissions

## Support

For issues or questions about this CET131 assessment project:
1. Review this README thoroughly
2. Check database connection string configuration
3. Verify Supabase account is active
4. Test database connectivity using Supabase dashboard

## License

Created for CET131 Assessment 2 - Academic Use Only

## Author

CET131 Student Submission
