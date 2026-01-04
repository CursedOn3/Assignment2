# WeAreCars Rental System

A console-based car rental management system developed for CET131 Assessment 2.

## Features

### Staff Authentication
- Secure login system with fixed credentials
- Username: `sta001`
- Password: `givemethekeys123`
- Access denied for incorrect credentials

### Customer Information Collection
- First name and surname
- Full address
- Age verification (must be 18 or over)
- Driving licence validation (required to proceed)

### Rental Options

#### Car Types
- City car (+£0)
- Family car (+£50)
- Sports car (+£75)
- SUV (+£65)

#### Fuel Types
- Petrol (+£0)
- Diesel (+£0)
- Hybrid (+£30)
- Electric (+£50)

#### Optional Extras
- Unlimited mileage (+£10 per day)
- Breakdown cover (+£2 per day)

### Pricing
- Base rental rate: £25 per day
- Rental duration: 1-28 days
- All surcharges are clearly displayed

### Validation
- All user inputs are validated with clear error messages
- Age must be 18 or over
- Valid driving licence is mandatory
- Rental days must be between 1 and 28

### Booking Summary
- Complete overview of customer details
- Itemized cost breakdown
- Total price calculation
- Confirmation before finalizing booking

## How to Run

### Prerequisites
- .NET 6.0 SDK or later

### Running the Application

1. Navigate to the project directory:
   ```bash
   cd WeAreCarsRentalSystem
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

## Usage Instructions

1. **Welcome Screen**: Read the brief instructions and press any key to continue
2. **Staff Login**: Enter the staff credentials
3. **Customer Details**: Provide all required customer information
4. **Rental Preferences**: Select car type, fuel type, and optional extras
5. **Summary Review**: Review the complete booking summary and cost breakdown
6. **Confirmation**: Confirm or cancel the booking

## Application Structure

- **Program.cs**: Main application file containing all logic
- Clear separation of concerns with dedicated methods for:
  - User authentication
  - Input validation
  - Booking processing
  - Cost calculation
  - Summary display

## Technical Details

- Language: C# (.NET 6.0)
- Type: Console Application
- No external libraries or databases required
- Suitable for academic submission

## Author

Created for CET131 Assessment 2
