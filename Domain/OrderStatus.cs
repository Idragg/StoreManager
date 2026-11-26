namespace StoreManager.BL.Domain;

public enum OrderStatus
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