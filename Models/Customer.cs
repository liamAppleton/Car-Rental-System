namespace rentalapp;

public class Customer
{
    public Guid CustomerId { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public IRentalItem? CurrentlyRenting { get; set; }

    public Customer(Guid customerId, string name, int age)
    {
        CustomerId = customerId;
        Name = name;
        Age = age;
    }

    public string GetDetails()
    {
        return $"{CustomerId}: {Name} ({Age})";
    }

    public string GetCurrentlyRenting()
    {
        if (CurrentlyRenting != null)
        {
            return CurrentlyRenting.GetVehicleDetails();
        }
        else
        {
            return "Not currently renting";
        }

    }

}