namespace rentalapp;
using Spectre.Console;

class ConsoleUI<T> where T : class, IRentalItem
{
    private CustomerManagement _customerManagement;
    private RentalManagement<T> _rentalManagement;

    public ConsoleUI(CustomerManagement customerManagement, RentalManagement<T> rentalManagement)
    {
        _customerManagement = customerManagement;
        _rentalManagement = rentalManagement;
    }

    public Customer CreateCustomerFromInput()
    {
        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter name: "));
        var age = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter age: ")
        );
        Guid newId = Guid.NewGuid();

        return new Customer(newId, name, age);
    }

    public void DisplayAllCustomers()
    {
        var table = new Table();
        table.AddColumn("Name");
        table.AddColumn("Age");
        table.AddColumn("Currently Renting");

        foreach (Customer customer in _customerManagement.Customers)
        {
            table.AddRow(customer.Name, customer.Age.ToString(), customer.GetCurrentlyRenting());
        }

        AnsiConsole.Write(table);
    }

    // change any methods in other classes that have weighty console writes to strings/lists/whatever so they can be fed through AnsiConsole here


}