namespace rentalapp;

public class Car
{
    private string Make { get; set; }
    private string Model { get; set; }
    private int Year { get; set; }
    private string Colour { get; set; }

    public Car(string make, string model, int year, string colour)
    {
        Make = make;
        Model = model;
        Year = year;
        Colour = colour;
    }

    public override string ToString()
    {
        return $"{Make} | {Model} ({Colour}) [{Year}]";
    }
}