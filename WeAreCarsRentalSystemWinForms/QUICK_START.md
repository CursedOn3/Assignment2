# ?? Quick Start Guide - For Assessors

## WeAreCars Rental System - Windows Forms Application with SQLite

---

## ? INSTANT SETUP (0 seconds!)

### The Entire Setup Process:

```bash
cd WeAreCarsRentalSystemWinForms
dotnet run
```

**That's it!** ??

No database configuration, no accounts, no internet required!

---

## ?? What Happens on First Run?

1. ? Application starts
2. ? SQLite database file created automatically (`WeAreCarsRental.db`)
3. ? Database tables and indexes created
4. ? Welcome screen appears
5. ? Ready to use!

---

## ?? Login Credentials

**Username:** `sta001`  
**Password:** `givemethekeys123`

---

## ?? Quick Test Scenario

### Test 1: Successful Booking (2 minutes)
1. Run: `dotnet run`
2. Click "Proceed to Login"
3. Login: sta001 / givemethekeys123
4. Enter customer details:
   - First Name: John
   - Surname: Smith
   - Address: 123 Main Street
   - Age: 25
   - Licence: Yes
5. Select rental options:
   - Days: 5
   - Car: Sports Car (+£75)
   - Fuel: Electric (+£50)
   - Extras: Both checked (+£60)
6. Check total: Should be **£310.00**
   - Base: 5 × £25 = £125
   - Car: £75
   - Fuel: £50
   - Mileage: 5 × £10 = £50
   - Breakdown: 5 × £2 = £10
   - **Total: £310.00** ?
7. Click "Confirm Booking"
8. Review summary
9. Click "Yes"
10. Success message appears! ?
11. Data saved to local database ?

### Test 2: Validation - Age < 18 (30 seconds)
1. Create new booking
2. Enter age: 17
3. Try to confirm
4. ? Error: "Customer must be 18 or over" ?

### Test 3: Validation - No Licence (30 seconds)
1. Create new booking
2. Age: 25
3. Select "No" for licence
4. Try to confirm
5. ? Error: "Valid driving licence required" ?

### Test 4: Verify Data Persistence (30 seconds)
1. Close the application
2. Run again: `dotnet run`
3. Check database file exists ?
4. All previous bookings preserved ?

---

## ?? Pricing Verification

### Quick Calculation Examples:

**Example 1: Basic Rental**
- 3 days × £25 = **£75**

**Example 2: City Car, Petrol, No Extras**
- 7 days × £25 = **£175**
- Car: £0
- Fuel: £0
- **Total: £175**

**Example 3: Full Premium**
- 10 days × £25 = £250
- Sports Car: £75
- Electric: £50
- Unlimited Mileage: 10 × £10 = £100
- Breakdown Cover: 10 × £2 = £20
- **Total: £495**

---

## ?? View Saved Bookings

### Option 1: DB Browser for SQLite (Best for Assessment)

1. Download: https://sqlitebrowser.org/
2. Install (takes 1 minute)
3. Open DB Browser
4. File ? Open Database
5. Navigate to: `WeAreCarsRentalSystemWinForms/bin/Debug/net10.0-windows/`
6. Open: `WeAreCarsRental.db`
7. Click "Browse Data" tab
8. Select "bookings" table
9. See all saved bookings! ?

### Option 2: Quick File Check

```bash
# Navigate to database location
cd bin/Debug/net10.0-windows

# List files - you should see WeAreCarsRental.db
dir

# Check file size (increases with each booking)
dir WeAreCarsRental.db
```

---

## ?? Database Location

**File Name:** `WeAreCarsRental.db`

**Debug Build:**
```
WeAreCarsRentalSystemWinForms/bin/Debug/net10.0-windows/WeAreCarsRental.db
```

**Release Build:**
```
WeAreCarsRentalSystemWinForms/bin/Release/net10.0-windows/WeAreCarsRental.db
```

---

## ?? Troubleshooting (Unlikely with SQLite!)

### Issue: "Database is locked"
**Cause:** DB Browser has the database open  
**Solution:** Close DB Browser, then run application

### Issue: Application won't start
**Solution:** 
```bash
# Verify .NET is installed
dotnet --version

# Should show 10.0 or higher
# If not, download from: https://dotnet.microsoft.com/download

# Restore and rebuild
dotnet restore
dotnet build
dotnet run
```

### Issue: "No such table: bookings"
**Cause:** Database file corrupted  
**Solution:** 
```bash
# Delete and recreate
del bin\Debug\net10.0-windows\WeAreCarsRental.db
dotnet run  # Will recreate automatically
```

---

## ?? Assessment Features Checklist

### Forms (3) ?
- [x] Welcome screen with instructions
- [x] Login form with validation
- [x] Booking form with all sections

### Database (6) ?
- [x] Local SQLite database
- [x] Automatic database creation
- [x] Parameterized SQL queries
- [x] Data persists between runs
- [x] Error handling
- [x] Database constraints

### Validation (6) ?
- [x] Age must be 18+
- [x] Valid licence required
- [x] All fields required
- [x] Login credentials checked
- [x] Rental days 1-28
- [x] Total cost calculated correctly

### User Experience (5) ?
- [x] Clear navigation flow
- [x] Real-time cost updates
- [x] Confirmation dialogs
- [x] Success/error messages
- [x] Form resets after save

---

## ?? Why SQLite is Perfect for Assessment

| Feature | SQLite | Cloud DB |
|---------|--------|----------|
| Setup Time | ? 0 seconds | ?? 5+ minutes |
| Configuration | ? None | ? Required |
| Internet | ? Not needed | ? Required |
| Account | ? No | ? Yes |
| Assessor Friendly | ? Instant | ?? Setup needed |
| Data Viewing | ? Easy (file) | ?? Dashboard login |
| Portable | ? Single file | ? Cloud only |
| Submission | ? Include .db | ?? Credentials? |

**SQLite Winner for Academic Projects!** ??

---

## ?? What Gets Created

After first run, you'll see:

```
WeAreCarsRentalSystemWinForms/
??? bin/
?   ??? Debug/
?       ??? net10.0-windows/
?           ??? WeAreCarsRental.db          ? Database file (NEW!)
?           ??? WeAreCarsRentalSystemWinForms.exe
```

**The `.db` file contains all your bookings!**

---

## ? Complete Test Script (5 minutes)

```bash
# 1. Run application
cd WeAreCarsRentalSystemWinForms
dotnet run

# 2. Test valid booking
#    - Login: sta001 / givemethekeys123
#    - Enter customer: John, Smith, 123 Main St, Age 25, Licence Yes
#    - Select: 5 days, Sports Car, Electric, both extras
#    - Verify total: £310.00
#    - Confirm and save

# 3. Test age validation
#    - New booking, age 17
#    - Should show error

# 4. Test licence validation
#    - New booking, no licence
#    - Should show error

# 5. Close application

# 6. Verify database exists
dir bin\Debug\net10.0-windows\WeAreCarsRental.db

# 7. Open in DB Browser (optional)
#    - See saved booking data

# ? All tests passed!
```

---

## ?? Assessment Advantages

### For Students:
? No setup hassle  
? Works offline  
? Fast development  
? Easy testing  
? Professional database  

### For Assessors:
? **Clone and run** - zero config  
? **View data easily** - single file  
? **No accounts** - no sign-ups  
? **No internet** - works anywhere  
? **Transparent** - all data visible  

---

## ?? Pro Tips

1. **Database Location:** Always in `bin/` directory
2. **Backup Data:** Copy the `.db` file
3. **Reset Database:** Delete `.db` file, runs creates it
4. **View Live Data:** Use DB Browser while app runs
5. **Portable:** Can copy entire project folder

---

## ?? Sample Database Queries

If you open the database in DB Browser:

```sql
-- View all bookings
SELECT * FROM bookings ORDER BY created_at DESC;

-- Count total bookings
SELECT COUNT(*) as total FROM bookings;

-- Total revenue
SELECT SUM(total_cost) as revenue FROM bookings;

-- Most popular car type
SELECT car_type, COUNT(*) as count 
FROM bookings 
GROUP BY car_type 
ORDER BY count DESC;
```

---

## ? Summary

**Run Time:** 0 seconds setup + instant run  
**Configuration:** None required  
**Dependencies:** Just .NET (already have it)  
**Database:** Auto-created SQLite file  
**Data:** Persists automatically  
**Assessment Ready:** Immediately!  

---

**This is the easiest database setup possible!** ??

Just run the application and everything works! Perfect for CET131 assessment.

---

Last Updated: January 2025
