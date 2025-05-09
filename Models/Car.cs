namespace rentalapp;

public class Car : IInfoDisplay, IRentalItem
{
    private int CarId { get; set; }
    private string Make { get; set; }
    private string Model { get; set; }
    private int Year { get; set; }
    private string Colour { get; set; }
    public bool IsRented { get; private set; } = false;

    public Car(int carId, string make, string model, int year, string colour)
    {
        CarId = carId;
        Make = make;
        Model = model;
        Year = year;
        Colour = colour;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"{Make} | {Model} ({Colour}) [{Year}]");
    }

    public void Rent()
    {
        if (!IsRented)
        {
            IsRented = true;
            Console.WriteLine($"{CarId} ({Colour} {Make} {Model}) is now rented.");
        }
        else Console.WriteLine("Car is already being rented.");
    }

    public void Return()
    {
        if (IsRented)
        {
            IsRented = false;
            Console.WriteLine($"{CarId} ({Colour} {Make} {Model}) is now returned.");
        }
        else Console.WriteLine("Car is already returned.");
    }
}