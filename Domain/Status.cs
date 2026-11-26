namespace StoreManager.BL.Domain;

public enum Status
{
    Pending,
    Confirmed,
    Processing,
    ReadyForShipment,
    Shipped,
    Delivered,
    Cancelled,
    Returned
}