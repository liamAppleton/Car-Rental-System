using Spectre.Console;

namespace rentalapp;

public class VehicleQueryConsoleUI<T> where T : class, IRentalItem
{
    private RentalManagement<T> _rentalManagement;

    public VehicleQueryConsoleUI(RentalManagement<T> rentalManagement)
    {
        _rentalManagement = rentalManagement;
    }

    private Table InitialiseCarTable()
    {
        var table = new Table();
        table.AddColumn("Make");
        table.AddColumn("Model");
        table.AddColumn("Colour");
        table.AddColumn("Year");
        table.AddColumn("IsRented");
        table.AddColumn("CarId");
        return table;
    }

    private Table InitialiseBikeTable()
    {
        var table = new Table();
        table.AddColumn("Colour");
        table.AddColumn("IsRented?");
        table.AddColumn("BikeId");
        return table;
    }

    public void DisplayAllCars()
    {
        var table = InitialiseCarTable();

        foreach (Car car in _rentalManagement.Cars)
        {
            table.AddRow(car.Make, car.Model, car.Colour, car.Year.ToString(), car.IsRented.ToString(), car.CarId.ToString());
        }

        AnsiConsole.Write(table);
    }

    public void DisplayAllBikes()
    {
        var table = InitialiseBikeTable();

        foreach (Bike bike in _rentalManagement.Bikes)
        {
            table.AddRow(bike.Colour, bike.IsRented.ToString(), bike.BikeId.ToString());
        }

        AnsiConsole.Write(table);
    }

    public void DisplayCarsByRentalStatus(bool isRented)
    {
        var table = InitialiseCarTable();
        List<Car> rentedCars = _rentalManagement.Cars
            .Where(car => isRented ? car.IsRented : !car.IsRented)
            .ToList();

        foreach (Car car in rentedCars)
        {
            table.AddRow(car.Make, car.Model, car.Colour, car.Year.ToString(), car.IsRented.ToString(), car.CarId.ToString());
        }

        AnsiConsole.Write(table);
    }

    public void DisplayBikesByRentalStatus(bool isRented)
    {
        var table = InitialiseBikeTable();
        List<Bike> rentedBikes = _rentalManagement.Bikes
            .Where(bike => isRented ? bike.IsRented : !bike.IsRented)
            .ToList();

        foreach (Bike bike in rentedBikes)
        {
            table.AddRow(bike.Colour, bike.IsRented.ToString(), bike.BikeId.ToString());
        }

        AnsiConsole.Write(table);
    }
}