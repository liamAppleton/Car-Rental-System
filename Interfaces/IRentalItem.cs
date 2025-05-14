namespace rentalapp;

public interface IRentalItem
{
    bool IsRented { get; }

    void Rent();

    void Return();

    string GetVehicleDetails();
}