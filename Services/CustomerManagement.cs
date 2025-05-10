namespace rentalapp;

public class CustomerManagement
{
    private List<Customer> Customers { get; set; }

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

    public void DisplayAllCustomers()
    {
        if (Customers.Count == 0)
        {
            Console.WriteLine("No customers.");
        }
        else
        {
            Console.WriteLine("Customers:");
            foreach (Customer customer in Customers)
            {
                Console.WriteLine(customer.DisplayDetails());
            }
        }
    }
}