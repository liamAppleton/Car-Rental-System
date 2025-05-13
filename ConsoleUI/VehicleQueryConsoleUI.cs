using Spectre.Console;

namespace rentalapp;

public class VehicleQueryConsoleUI<T> where T : class, IRentalItem
{
    private RentalManagement<T> _rentalManagement;

    public VehicleQueryConsoleUI(RentalManagement<T> rentalManagement)
    {
        _rentalManagement = rentalManagement;
    }

    public void DisplayAllCars()
    {
        var table = new Table();
        table.AddColumn("Make");
        table.AddColumn("Model");
        table.AddColumn("Colour");
        table.AddColumn("Year");
        table.AddColumn("IsRented");
        table.AddColumn("CarId");

        foreach (Car car in _rentalManagement.Cars)
        {
            table.AddRow(car.Make, car.Model, car.Colour, car.Year.ToString(), car.IsRented.ToString(), car.CarId.ToString());
        }

        AnsiConsole.Write(table);
    }

    public void DisplayAllBikes()
    {
        var table = new Table();
        table.AddColumn("Colour");
        table.AddColumn("IsRented?");
        table.AddColumn("BikeId");

        foreach (Bike bike in _rentalManagement.Bikes)
        {
            table.AddRow(bike.Colour, bike.IsRented.ToString(), bike.BikeId.ToString());
        }

        AnsiConsole.Write(table);
    }


}