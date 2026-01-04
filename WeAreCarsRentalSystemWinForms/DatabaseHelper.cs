using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;

namespace WeAreCarsRentalSystemWinForms
{
    public class DatabaseHelper
    {
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

        public static DataTable GetAllBookings()
        {
            string selectQuery = @"
                SELECT 
                    id,
                    first_name,
                    surname,
                    address,
                    age,
                    rental_days,
                    car_type,
                    fuel_type,
                    extras,
                    total_cost,
                    created_at
                FROM bookings
                ORDER BY created_at DESC;";

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("first_name", typeof(string));
            dataTable.Columns.Add("surname", typeof(string));
            dataTable.Columns.Add("address", typeof(string));
            dataTable.Columns.Add("age", typeof(int));
            dataTable.Columns.Add("rental_days", typeof(int));
            dataTable.Columns.Add("car_type", typeof(string));
            dataTable.Columns.Add("fuel_type", typeof(string));
            dataTable.Columns.Add("extras", typeof(string));
            dataTable.Columns.Add("total_cost", typeof(double));
            dataTable.Columns.Add("created_at", typeof(string));

            try
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(selectQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataRow row = dataTable.NewRow();
                                row["id"] = reader.GetInt32(0);
                                row["first_name"] = reader.GetString(1);
                                row["surname"] = reader.GetString(2);
                                row["address"] = reader.GetString(3);
                                row["age"] = reader.GetInt32(4);
                                row["rental_days"] = reader.GetInt32(5);
                                row["car_type"] = reader.GetString(6);
                                row["fuel_type"] = reader.GetString(7);
                                row["extras"] = reader.IsDBNull(8) ? "None" : reader.GetString(8);
                                row["total_cost"] = reader.GetDouble(9);
                                row["created_at"] = reader.GetString(10);
                                dataTable.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve bookings: {ex.Message}");
            }

            return dataTable;
        }

        public static void DeleteBooking(int bookingId)
        {
            string deleteQuery = @"DELETE FROM bookings WHERE id = @bookingId;";

            try
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@bookingId", bookingId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("Booking not found or already deleted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete booking: {ex.Message}");
            }
        }

        public static void UpdateBooking(int bookingId, string firstName, string surname, string address, 
                                        int age, int rentalDays, string carType, string fuelType, 
                                        string extras, decimal totalCost)
        {
            string updateQuery = @"
                UPDATE bookings 
                SET first_name = @firstName,
                    surname = @surname,
                    address = @address,
                    age = @age,
                    rental_days = @rentalDays,
                    car_type = @carType,
                    fuel_type = @fuelType,
                    extras = @extras,
                    total_cost = @totalCost
                WHERE id = @bookingId;";

            try
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@bookingId", bookingId);
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@rentalDays", rentalDays);
                        command.Parameters.AddWithValue("@carType", carType);
                        command.Parameters.AddWithValue("@fuelType", fuelType);
                        command.Parameters.AddWithValue("@extras", extras ?? "None");
                        command.Parameters.AddWithValue("@totalCost", (double)totalCost);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("Booking not found or could not be updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update booking: {ex.Message}");
            }
        }

        public static string GetDatabasePath()
        {
            return DatabasePath;
        }
    }
}
