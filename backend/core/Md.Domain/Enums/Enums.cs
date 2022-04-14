namespace Md.Domain.Enums
{
    public enum OrderStatus
    {
        Open,
        Closed
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
    public enum AmountType
    {
        Things,
        Kilograms
    }
}
