namespace rentalapp;

public class Car : IInfoDisplay
{
    private int CarId { get; set; }
    private string Make { get; set; }
    private string Model { get; set; }
    private int Year { get; set; }
    private string Colour { get; set; }

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
}