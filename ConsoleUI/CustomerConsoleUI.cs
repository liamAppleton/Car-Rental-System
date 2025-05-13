namespace rentalapp;
using Spectre.Console;

class CustomerConsoleUI
{
    private CustomerManagement _customerManagement;

    public CustomerConsoleUI(CustomerManagement customerManagement)
    {
        _customerManagement = customerManagement;
    }

    public void AddInputCustomer()
    {
        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter name: "));
        var age = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter age: ")
        );
        Guid newId = Guid.NewGuid();

        _customerManagement.AddCustomer(new Customer(newId, name, age));
    }

    public void RemoveInputCustomer()
    {
        var selectedName = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a customer:")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to view more customers)[/]")
            .AddChoices(_customerManagement.Customers
                .Select(c => c.Name)
                .ToArray()));

        Customer? selectedCustomer = _customerManagement.Customers.FirstOrDefault(c => c.Name == selectedName);

        _customerManagement.RemoveCustomer(selectedCustomer);
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
}