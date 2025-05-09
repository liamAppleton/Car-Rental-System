namespace rentalapp;

public class Customer
{
    private string Name { get; set; }
    private int Age { get; set; }
    private Car? CurrentlyRenting { get; set; }

    public Customer(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void ViewCurrentlyRenting()
    {
        if (CurrentlyRenting != null)
        {
            CurrentlyRenting.DisplayDetails();
        }
        else
        {
            Console.WriteLine($"{Name} is not currently renting.");
        }

    }

}