using Spectre.Console;

namespace rentalapp;

public class VehicleQueryConsoleUI<T> where T : class, IRentalItem
{
    private RentalManagement<T> _rentalManagement;
    private CustomerManagement _customerManagement;

    public VehicleQueryConsoleUI(RentalManagement<T> rentalManagement, CustomerManagement customerManagement)
    {
        _rentalManagement = rentalManagement;
        _customerManagement = customerManagement;
    }

    private Table InitialiseCarTable()
    {
        var table = new Table();
        table.AddColumn("Make");
        table.AddColumn("Model");
        table.AddColumn("Colour");
        table.AddColumn("Year");
        table.AddColumn("IsRented");
        table.AddColumn("RentedBy");
        table.AddColumn("CarId");
        return table;
    }

    private Table InitialiseBikeTable()
    {
        var table = new Table();
        table.AddColumn("Colour");
        table.AddColumn("IsRented");
        table.AddColumn("RentedBy");
        table.AddColumn("BikeId");
        return table;
    }

    private string? GetRentingCustomer(string id, string type)
    {
        return _rentalManagement.RentedVehicles.Join(
            _customerManagement.Customers,
            rental => rental.CustomerId,
            customer => customer.CustomerId,
            (rental, customer) => new { rental, customer })
            .Where(rentalCustomer => (type == "CAR" ?
            rentalCustomer.rental.Car.CarId.ToString() :
            rentalCustomer.rental.Bike.BikeId.ToString())
            == id)
            .Select(rentalCustomer => rentalCustomer.customer.Name)
            .FirstOrDefault() ?? "N/A";
    }

    public void DisplayAllCars()
    {
        var table = InitialiseCarTable();
        foreach (Car car in _rentalManagement.Cars)
        {
            table.AddRow(car.Make,
            car.Model,
            car.Colour,
            car.Year.ToString(),
            car.IsRented.ToString(),
            GetRentingCustomer(car.CarId.ToString(), "CAR"),
            car.CarId.ToString());
        }

        AnsiConsole.MarkupLine("\n[blue bold]Cars[/]");
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();
    }

    public void DisplayAllBikes()
    {
        var table = InitialiseBikeTable();

        foreach (Bike bike in _rentalManagement.Bikes)
        {
            table.AddRow(bike.Colour,
            bike.IsRented.ToString(),
            GetRentingCustomer(bike.BikeId.ToString(), "BIKE"),
            bike.BikeId.ToString());
        }

        AnsiConsole.MarkupLine("\n[yellow bold]Bikes[/]");
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();
    }

    public void DisplayCarsByRentalStatus(bool isRented)
    {
        var table = InitialiseCarTable();

        List<Car> rentedCars = _rentalManagement.Cars
            .Where(car => isRented ? car.IsRented : !car.IsRented)
            .ToList();

        foreach (Car car in rentedCars)
        {
            table.AddRow(car.Make,
            car.Model,
            car.Colour,
            car.Year.ToString(),
            car.IsRented.ToString(),
            GetRentingCustomer(car.CarId.ToString(), "CAR"),
            car.CarId.ToString());
        }

        AnsiConsole.MarkupLine($"\n[blue bold]{(isRented ? "Rented" : "Available")} Cars[/]");
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();
    }

    public void DisplayBikesByRentalStatus(bool isRented)
    {
        var table = InitialiseBikeTable();
        List<Bike> rentedBikes = _rentalManagement.Bikes
            .Where(bike => isRented ? bike.IsRented : !bike.IsRented)
            .ToList();

        foreach (Bike bike in rentedBikes)
        {
            table.AddRow(bike.Colour,
            bike.IsRented.ToString(),
            GetRentingCustomer(bike.BikeId.ToString(), "BIKE"),
            bike.BikeId.ToString());
        }

        AnsiConsole.MarkupLine($"\n[red bold]{(isRented ? "Rented" : "Available")} Bikes[/]");
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();
    }
}