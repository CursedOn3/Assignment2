namespace WeAreCarsRentalSystemWinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        
        // Initialize database table
        try
        {
            DatabaseHelper.CreateTableIfNotExists();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Warning: Could not initialize database.\n\n" +
                          $"Error: {ex.Message}\n\n" +
                          $"Please update the connection string in DatabaseHelper.cs\n" +
                          $"The application will continue, but bookings cannot be saved.",
                          "Database Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        Application.Run(new WelcomeForm());
    }    
}