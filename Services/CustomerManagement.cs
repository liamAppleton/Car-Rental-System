namespace rentalapp;

public class CustomerManagement
{
    public List<Customer> Customers { get; private set; }

    public CustomerManagement()
    {
        Customers = new List<Customer>();
    }

    public void AddCustomer(Customer customer)
    {
        Customers.Add(customer);
        Console.WriteLine($"{customer.Name} has been added.");
    }

    public void RemoveCustomer(Customer customer)
    {
        if (Customers.Contains(customer))
        {
            Customers.Remove(customer);
            Console.WriteLine($"{customer.Name} has been removed.");
        }
    }
}