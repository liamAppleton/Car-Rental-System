namespace rentalapp;

interface IRentalItem
{
    bool IsRented { get; }

    void Rent();

    void Return();
}