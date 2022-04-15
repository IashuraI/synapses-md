using Md.Domain.Entities.Base;
using Md.Domain.Entities.Meals;
using Md.Infrastucture.Meta.Attributes;

namespace Md.Domain.Entities.Orders
{
    [ODataResource]
    public sealed class OrderMeal : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid MealId { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; } = null!;
        public Meal Meal { get; set; } = null!;
    }
}
