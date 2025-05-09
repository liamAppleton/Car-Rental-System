namespace rentalapp;

public class Customer
{
    private int CustomerId { get; set; }
    private string Name { get; set; }
    private int Age { get; set; }
    private Car? CurrentlyRenting { get; set; }

    public Customer(int customerId, string name, int age)
    {
        CustomerId = customerId;
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