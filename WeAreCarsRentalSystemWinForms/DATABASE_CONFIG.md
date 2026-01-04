# Database Configuration Guide - SQLite

## SQLite Local Database

This application now uses **SQLite** - a lightweight, file-based database that requires **NO SETUP**!

---

## ? No Configuration Required!

Unlike cloud databases, SQLite works out of the box:

? **No account creation needed**  
? **No internet connection required**  
? **No connection string to configure**  
? **No external services**  
? **Completely portable**  

---

## ?? Database Location

The SQLite database file is automatically created in your application directory:

**File Name:** `WeAreCarsRental.db`

**Full Path:** 
```
WeAreCarsRentalSystemWinForms/bin/Debug/net10.0-windows/WeAreCarsRental.db
```

Or if you run from Release:
```
WeAreCarsRentalSystemWinForms/bin/Release/net10.0-windows/WeAreCarsRental.db
```

---

## ?? How It Works

### First Run
1. Application starts
2. Checks if `WeAreCarsRental.db` exists
3. If not, creates it automatically
4. Creates the `bookings` table
5. Creates indexes for performance
6. Ready to use!

### Subsequent Runs
1. Application finds existing database
2. Uses existing data
3. All previous bookings are preserved

---

## ?? Viewing Your Data

### Option 1: DB Browser for SQLite (Recommended)
1. Download from https://sqlitebrowser.org/
2. Install the application
3. Open the `WeAreCarsRental.db` file
4. Browse the `bookings` table
5. View all saved bookings

### Option 2: Visual Studio Code
1. Install "SQLite Viewer" extension
2. Right-click on `WeAreCarsRental.db`
3. Select "Open Database"

### Option 3: Command Line
```bash
# Navigate to the database location
cd WeAreCarsRentalSystemWinForms/bin/Debug/net10.0-windows

# Open SQLite
sqlite3 WeAreCarsRental.db

# View all bookings
SELECT * FROM bookings;

# Exit
.exit
```

---

## ?? Database Schema

```sql
CREATE TABLE bookings (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    first_name TEXT NOT NULL,
    surname TEXT NOT NULL,
    address TEXT NOT NULL,
    age INTEGER NOT NULL,
    rental_days INTEGER NOT NULL,
    car_type TEXT NOT NULL,
    fuel_type TEXT NOT NULL,
    extras TEXT,
    total_cost REAL NOT NULL,
    created_at TEXT DEFAULT (datetime('now'))
);
```

---

## ? Advantages of SQLite

### For Students/Learning:
? **Zero setup** - works immediately  
? **No accounts** - no sign-up required  
? **Offline** - works without internet  
? **Portable** - single file database  
? **Fast** - excellent for small to medium apps  
? **Reliable** - industry-standard database  

### For Assessment:
? **Easy for assessors** - no configuration needed  
? **Self-contained** - database included with submission  
? **Transparent** - data can be easily viewed  
? **Professional** - used by major companies  

---

## ?? File Management

### Backup Your Data
Simply copy the `WeAreCarsRental.db` file to another location:
```bash
copy WeAreCarsRental.db WeAreCarsRental_backup.db
```

### Reset Database
Delete the database file and it will be recreated on next run:
```bash
del WeAreCarsRental.db
```

### Move Database
You can move the `.db` file to another location. The application creates it in the application directory.

---

## ?? Troubleshooting

### Issue: "Database is locked"
**Cause:** Another program has the database open  
**Solution:** Close DB Browser or any other tool viewing the database

### Issue: "No such table: bookings"
**Cause:** Database file was deleted or corrupted  
**Solution:** Delete the `.db` file and restart the application

### Issue: "Cannot find database file"
**Cause:** Looking in wrong directory  
**Solution:** Check in `bin/Debug/net10.0-windows/` or `bin/Release/net10.0-windows/`

---

## ?? Why SQLite for CET131?

SQLite is perfect for academic projects because:

1. **No External Dependencies** - Everything self-contained
2. **Easy to Demonstrate** - Assessor can run immediately
3. **Portable Submission** - Database included in project
4. **Professional** - Used by:
   - Android applications
   - iOS applications
   - Browsers (Firefox, Chrome)
   - Embedded systems
   - Desktop applications

5. **Appropriate Complexity** - Database concepts without cloud complexity

---

## ?? Sample Queries

### View all bookings
```sql
SELECT * FROM bookings ORDER BY created_at DESC;
```

### Count total bookings
```sql
SELECT COUNT(*) as total_bookings FROM bookings;
```

### Total revenue
```sql
SELECT SUM(total_cost) as total_revenue FROM bookings;
```

### Bookings by car type
```sql
SELECT car_type, COUNT(*) as count 
FROM bookings 
GROUP BY car_type 
ORDER BY count DESC;
```

### Recent bookings (last 7 days)
```sql
SELECT * FROM bookings 
WHERE created_at >= datetime('now', '-7 days')
ORDER BY created_at DESC;
```

---

## ?? Benefits Over Cloud Databases

| Feature | SQLite | Supabase/Cloud |
|---------|--------|----------------|
| Setup Time | ? 0 seconds | ?? 5+ minutes |
| Internet Required | ? No | ? Yes |
| Account Needed | ? No | ? Yes |
| Configuration | ? None | ? Connection string |
| Cost | ?? Free | ?? Free tier limited |
| Portability | ? Single file | ? Cloud only |
| Assessment Friendly | ? Very | ?? Requires setup |

---

## ?? Learning Resources

- **SQLite Official:** https://www.sqlite.org/
- **DB Browser:** https://sqlitebrowser.org/
- **SQLite Tutorial:** https://www.sqlitetutorial.net/
- **Microsoft Docs:** https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/

---

## ? Summary

**You don't need to do anything!**

Just run the application and SQLite handles everything:
```bash
cd WeAreCarsRentalSystemWinForms
dotnet run
```

The database is created automatically, and your bookings are saved locally in a single file.

Perfect for academic projects! ??

---

Last Updated: January 2025
