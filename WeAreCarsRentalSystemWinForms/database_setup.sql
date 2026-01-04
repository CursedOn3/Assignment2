-- WeAreCars Rental System - SQLite Database Setup Script
-- This script is for reference only - the application creates the database automatically
-- The database file will be created at: WeAreCarsRental.db

-- Create the bookings table
CREATE TABLE IF NOT EXISTS bookings (
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

-- Create an index on created_at for faster date-based queries
CREATE INDEX IF NOT EXISTS idx_bookings_created_at 
ON bookings(created_at DESC);

-- Create an index on customer names for faster search
CREATE INDEX IF NOT EXISTS idx_bookings_customer 
ON bookings(surname, first_name);

-- NOTE: SQLite does not support VIEWS creation in the same way as PostgreSQL
-- To view booking summaries, use this query:
-- 
-- SELECT 
--     id,
--     first_name || ' ' || surname AS customer_name,
--     age,
--     rental_days,
--     car_type,
--     fuel_type,
--     extras,
--     total_cost,
--     created_at
-- FROM bookings
-- ORDER BY created_at DESC;

-- Verify the table structure
-- PRAGMA table_info(bookings);

-- Sample query to view all bookings
-- SELECT * FROM bookings ORDER BY created_at DESC;
