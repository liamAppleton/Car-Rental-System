namespace rentalapp;

public class CustomerManagement
{
    private List<Customer> Customers { get; set; }

    public CustomerManagement(List<Customer> customers)
    {
        Customers = customers;
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

    public void DisplayAllCustomers()
    {
        Console.WriteLine("Customers:");
        foreach (Customer customer in Customers)
        {
            customer.DisplayDetails();
        }
    }
}