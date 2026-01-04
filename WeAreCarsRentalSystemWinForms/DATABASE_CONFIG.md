# Database Configuration Guide

## Supabase Connection String Setup

### Step 1: Get Your Supabase Credentials

1. Login to [Supabase](https://supabase.com)
2. Open your project
3. Go to **Settings** ? **Database**
4. Scroll down to **Connection String** section
5. Look for **Connection pooling** or **Direct connection**

### Step 2: Extract Connection Details

You'll need:
- **Host:** `db.xxxxxxxxxxxxx.supabase.co`
- **Database:** `postgres`
- **User:** `postgres`
- **Password:** `[YOUR_PASSWORD]`
- **Port:** `5432`

### Step 3: Update DatabaseHelper.cs

Open `DatabaseHelper.cs` and find this line:

```csharp
private const string ConnectionString = "Host=your-supabase-host.supabase.co;Database=postgres;Username=postgres;Password=your_password;SSL Mode=Require;Trust Server Certificate=true";
```

Replace it with your actual details:

```csharp
private const string ConnectionString = "Host=db.xxxxxxxxxxxxx.supabase.co;Database=postgres;Username=postgres;Password=your_actual_password;SSL Mode=Require;Trust Server Certificate=true";
```

### Example Connection Strings

**Format 1: Basic Connection**
```
Host=db.abcdefghijklm.supabase.co;Database=postgres;Username=postgres;Password=MySecurePass123;SSL Mode=Require;Trust Server Certificate=true
```

**Format 2: With Port (if needed)**
```
Host=db.abcdefghijklm.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=MySecurePass123;SSL Mode=Require;Trust Server Certificate=true
```

**Format 3: With Pooling (for connection pooler)**
```
Host=db.abcdefghijklm.supabase.co;Port=6543;Database=postgres;Username=postgres.pooler;Password=MySecurePass123;SSL Mode=Require;Trust Server Certificate=true
```

### Important Notes

?? **Security Warning:**
- Never commit your password to version control
- Keep your connection string private
- Use environment variables in production

? **SSL Configuration:**
- `SSL Mode=Require` - MUST be included for Supabase
- `Trust Server Certificate=true` - Required for Supabase certificates

### Testing Your Connection

Run the application. If configured correctly:
- No error message appears on startup
- You can create bookings successfully
- Data appears in your Supabase dashboard

If you see errors:
1. Double-check your password
2. Verify your host address
3. Ensure SSL Mode=Require is included
4. Check your internet connection
5. Verify Supabase project is not paused

### Alternative: Using Supabase Direct Connection URL

Supabase provides a direct connection URL. To convert it:

**Given URL:**
```
postgresql://postgres:[YOUR-PASSWORD]@db.xxxxxxxxxxxxx.supabase.co:5432/postgres
```

**Convert to:**
```
Host=db.xxxxxxxxxxxxx.supabase.co;Database=postgres;Username=postgres;Password=[YOUR-PASSWORD];SSL Mode=Require;Trust Server Certificate=true
```

### Troubleshooting

| Error | Solution |
|-------|----------|
| "Password authentication failed" | Check password is correct |
| "SSL connection error" | Add `SSL Mode=Require;Trust Server Certificate=true` |
| "Host not found" | Verify host address from Supabase dashboard |
| "Timeout" | Check internet connection and firewall |
| "Database does not exist" | Use `postgres` as database name |

### Default Credentials (DO NOT USE IN PRODUCTION)

For testing ONLY, the application includes a placeholder:
```
Host=your-supabase-host.supabase.co;Database=postgres;Username=postgres;Password=your_password;SSL Mode=Require;Trust Server Certificate=true
```

You MUST replace this with your actual Supabase credentials.
