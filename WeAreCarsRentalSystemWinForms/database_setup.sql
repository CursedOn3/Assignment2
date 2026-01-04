-- WeAreCars Rental System - Database Setup Script
-- Run this in your Supabase SQL Editor to create the bookings table

-- Create the bookings table
CREATE TABLE IF NOT EXISTS bookings (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    surname VARCHAR(100) NOT NULL,
    address TEXT NOT NULL,
    age INTEGER NOT NULL CHECK (age >= 18),
    rental_days INTEGER NOT NULL CHECK (rental_days >= 1 AND rental_days <= 28),
    car_type VARCHAR(50) NOT NULL,
    fuel_type VARCHAR(50) NOT NULL,
    extras TEXT,
    total_cost DECIMAL(10, 2) NOT NULL CHECK (total_cost >= 0),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create an index on created_at for faster date-based queries
CREATE INDEX IF NOT EXISTS idx_bookings_created_at ON bookings(created_at DESC);

-- Create an index on customer names for faster search
CREATE INDEX IF NOT EXISTS idx_bookings_customer ON bookings(surname, first_name);

-- Optional: Create a view to see booking summaries
CREATE OR REPLACE VIEW booking_summary AS
SELECT 
    id,
    first_name || ' ' || surname AS customer_name,
    age,
    rental_days,
    car_type,
    fuel_type,
    extras,
    total_cost,
    created_at
FROM bookings
ORDER BY created_at DESC;

-- Verify the table was created successfully
SELECT 
    table_name, 
    column_name, 
    data_type, 
    is_nullable
FROM information_schema.columns
WHERE table_name = 'bookings'
ORDER BY ordinal_position;

-- Display a success message
DO $$
BEGIN
    RAISE NOTICE 'WeAreCars database setup completed successfully!';
    RAISE NOTICE 'Table: bookings';
    RAISE NOTICE 'View: booking_summary';
    RAISE NOTICE 'Indexes: idx_bookings_created_at, idx_bookings_customer';
END $$;
