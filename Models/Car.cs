namespace rentalapp;

public class Car : IRentalItem
{
    public int CarId { get; private set; }
    public string Type { get; private set; }
    private string Make { get; set; }
    private string Model { get; set; }
    private int Year { get; set; }
    public string Colour { get; private set; }
    public bool IsRented { get; private set; }

    public Car(int carId, string type, string make, string model, int year, string colour)
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
        return $"[{Type}] {Make} | {Model} ({Colour}) [{Year}]";
    }

    public void Rent()
    {
        if (!IsRented)
        {
            IsRented = true;
            Console.WriteLine($"[{Type}] {CarId} ({Colour} {Make} {Model}) is now rented.");
        }
        else Console.WriteLine("Car is already being rented.");
    }

    public void Return()
    {
        if (IsRented)
        {
            IsRented = false;
            Console.WriteLine($"[{Type}] {CarId} ({Colour} {Make} {Model}) is now returned.");
        }
        else Console.WriteLine("Car is already returned.");
    }
}