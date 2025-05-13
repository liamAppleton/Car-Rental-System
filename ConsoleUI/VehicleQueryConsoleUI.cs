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
        table.AddColumn("Cars");

        foreach (Car car in _rentalManagement.Cars)
        {
            table.AddRow(car.GetVehicleDetails());
        }

        AnsiConsole.Write(table);
    }


}