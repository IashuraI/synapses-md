namespace Md.Domain.Enums
{
    public enum OrderStatus
    {
        Open,
        Closed
    }
    public enum City
    {
        Kiev,
        khmelnytskyi
    }
    public enum PaymentMethod
    {
        Cash,
        Online
    }
    public enum DeliveryStatus
    {
        NotStarted,
        InKitchen,
        ReadyForDelivery,
        InDelivery,
        Delivered
    }
}
