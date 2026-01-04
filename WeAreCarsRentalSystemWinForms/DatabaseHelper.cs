using Npgsql;
using System;

namespace WeAreCarsRentalSystemWinForms
{
    public class DatabaseHelper
    {
        // TODO: Replace with your actual Supabase connection string
        // Format: Host=db.xxxxx.supabase.co;Database=postgres;Username=postgres;Password=your_password;SSL Mode=Require;Trust Server Certificate=true
        private const string ConnectionString = "Host=db.ybhwrcyngnfxgobhrgvh.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=Un1f13dNepal@;SSL Mode=Require;Trust Server Certificate=true";

        public static void CreateTableIfNotExists()
        {
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS bookings (
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
                );";

            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create table: {ex.Message}");
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void InsertBooking(string firstName, string surname, string address, int age,
                                        int rentalDays, string carType, string fuelType, string extras,
                                        decimal totalCost)
        {
            string insertQuery = @"
                INSERT INTO bookings (first_name, surname, address, age, rental_days, car_type, fuel_type, extras, total_cost)
                VALUES (@firstName, @surname, @address, @age, @rentalDays, @carType, @fuelType, @extras, @totalCost);";

            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@rentalDays", rentalDays);
                        command.Parameters.AddWithValue("@carType", carType);
                        command.Parameters.AddWithValue("@fuelType", fuelType);
                        command.Parameters.AddWithValue("@extras", extras ?? "None");
                        command.Parameters.AddWithValue("@totalCost", totalCost);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to insert booking: {ex.Message}");
            }
        }
    }
}
