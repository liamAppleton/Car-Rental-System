using Spectre.Console;
using System.Text.RegularExpressions;

namespace rentalapp;

public class RentalConsoleUI<T> where T : class, IRentalItem
{
    private RentalManagement<T> _rentalManagement;
    private CustomerManagement _customerManagement;

    public RentalConsoleUI(RentalManagement<T> rentalManagement, CustomerManagement customerManagement)
    {
        _rentalManagement = rentalManagement;
        _customerManagement = customerManagement;
    }

    public void AddInputRental()
    {
        string[] vehiclesDetails = _rentalManagement.Cars.Cast<IRentalItem>()
        .Concat(_rentalManagement.Bikes.Cast<IRentalItem>())
        .Where(vehicle => !vehicle.IsRented)
        .Select(vehicle => vehicle.GetVehicleDetails())
        .ToArray();

        var vehicle = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a vehicle to rent: ")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to view more vehicles)[/]")
            .AddChoices(vehiclesDetails)
        );

        Regex id = new Regex(@"- ([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})$");
        Match idMatch = id.Match(vehicle);

        Regex carType = new Regex(@"\[CAR\]");
        Match carMatch = carType.Match(vehicle);

        Car? car = null;
        Bike? bike = null;

        if (carMatch.Success)
        {
            car = _rentalManagement.Cars
                .FirstOrDefault(c => c.CarId == Guid.Parse(idMatch.Groups[1].Value));
        }
        else
        {
            bike = _rentalManagement.Bikes
                .FirstOrDefault(b => b.BikeId == Guid.Parse(idMatch.Groups[1].Value));
        }

        var customerName = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title($"Select a customer to rent [[{vehicle}]]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to view more customers)[/]")
            .AddChoices(_customerManagement.Customers
                .Select(c => c.Name)
                .ToArray())
        );

        Customer? customer = _customerManagement.Customers
            .Where(c => c.Name == customerName)
            .FirstOrDefault();

        customer.CurrentlyRenting = car != null ? car : bike;

        Guid rentalId = Guid.NewGuid();

        _rentalManagement.AddVehicle(new Rental(rentalId, customer.CustomerId, car, bike));
    }

    public void RemoveInputRental()
    {
        try
        {
            string[] vehiclesDetails = _rentalManagement.Cars.Cast<IRentalItem>()
                .Concat(_rentalManagement.Bikes.Cast<IRentalItem>())
                .Where(vehicle => vehicle.IsRented)
                .Select(vehicle => vehicle.GetVehicleDetails())
                .ToArray();

            var rental = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select a rental to remove: ")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to view more rentals)[/]")
                .AddChoices(vehiclesDetails)
            );

            Regex id = new Regex(@"- ([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})$");
            Match idMatch = id.Match(rental);

            Rental? selectedRental = _rentalManagement.RentedVehicles
                .FirstOrDefault(r =>
                (r.Car != null ? r.Car.CarId : r.Bike.BikeId)
                == Guid.Parse(idMatch.Groups[1].Value));

            _rentalManagement.RemoveVehicle(selectedRental);
        }
        catch (Exception ex)
        {
            Console.WriteLine("No rentals available.");
        }
    }

    public void DisplayAllRentalVehicles()
    {
        if (_rentalManagement.RentedVehicles.Count == 0)
        {
            AnsiConsole.MarkupLine("[red] No rented vehicles [/]");
        }
        else
        {
            var table = new Table();
            table.AddColumn("Vehicle Details");
            table.AddColumn("Rented By");

            foreach (Rental rental in _rentalManagement.RentedVehicles)
            {
                string details = rental.Car != null ? rental.Car.GetVehicleDetails() : rental.Bike.GetVehicleDetails();

                string? customerName = _rentalManagement.RentedVehicles
                    .Join(_customerManagement.Customers,
                    rental => rental.CustomerId,
                    customer => customer.CustomerId,
                    (rental, customer) => new { rental, customer })
                    .Where(rentalCustomer => rentalCustomer.rental.RentalId == rental.RentalId)
                    .Select(rentalCustomer => rentalCustomer.customer.Name)
                    .FirstOrDefault();

                table.AddRow(details, customerName);
            }

            AnsiConsole.Write(table);
        }
    }
}