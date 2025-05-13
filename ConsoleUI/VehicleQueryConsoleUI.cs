namespace rentalapp;

public class VehicleQueryConsoleUI<T> where T : class, IRentalItem
{
    private RentalManagement<T> _rentalManagement;

    public VehicleQueryConsoleUI(RentalManagement<T> rentalManagement)
    {
        _rentalManagement = rentalManagement;
    }


}