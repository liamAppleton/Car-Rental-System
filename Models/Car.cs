using Spectre.Console;

namespace rentalapp;

public class Car : IRentalItem
{
    public Guid CarId { get; private set; }
    public string Type { get; private set; }
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public string Colour { get; private set; }
    public bool IsRented { get; private set; }

    public Car(Guid carId, string type, string make, string model, int year, string colour)
    {
        CarId = carId;
        Type = type;
        Make = make;
        Model = model;
        Year = year;
        Colour = colour;
        IsRented = false;
    }

    public string GetVehicleDetails()
    {
        return $"[[{Type}]] {Make} | {Model} ({Colour}) [[{Year}]] - {CarId}";
    }

    public void Rent()
    {
        if (!IsRented)
        {
            IsRented = true;
        }
        else Console.WriteLine("Car is already being rented.");
    }

    public void Return()
    {
        if (IsRented)
        {
            IsRented = false;
        }
        else Console.WriteLine("Car is already returned.");
    }
}