using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace WeAreCarsRentalSystemWinForms
{
    public class DatabaseHelper
    {
        // SQLite database file will be created in the application directory
        private static readonly string DatabasePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, 
            "WeAreCarsRental.db"
        );

        private static string ConnectionString => $"Data Source={DatabasePath}";

        public static void CreateTableIfNotExists()
        {
            string createTableQuery = @"
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
                );";

            string createIndexQuery1 = @"
                CREATE INDEX IF NOT EXISTS idx_bookings_created_at 
                ON bookings(created_at DESC);";

            string createIndexQuery2 = @"
                CREATE INDEX IF NOT EXISTS idx_bookings_customer 
                ON bookings(surname, first_name);";

            try
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    
                    using (var command = new SqliteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqliteCommand(createIndexQuery1, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqliteCommand(createIndexQuery2, connection))
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
                using (var connection = new SqliteConnection(ConnectionString))
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
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@rentalDays", rentalDays);
                        command.Parameters.AddWithValue("@carType", carType);
                        command.Parameters.AddWithValue("@fuelType", fuelType);
                        command.Parameters.AddWithValue("@extras", extras ?? "None");
                        command.Parameters.AddWithValue("@totalCost", (double)totalCost);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to insert booking: {ex.Message}");
            }
        }

        public static string GetDatabasePath()
        {
            return DatabasePath;
        }
    }
}
