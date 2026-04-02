
namespace ShopApp
{
    public class OrderService
    {
        public decimal CalculateTotal(decimal productPrice, int quantity, int discountPercent, decimal deliveryPrice)
        {
            if (productPrice < 0)
                throw new ArgumentException("Цена товара не может быть отрицательной");

            if (quantity < 0)
                throw new ArgumentException("Количество товара не может быть отрицательным");

            if (discountPercent < 0 || discountPercent > 100)
                throw new ArgumentException("Скидка должна быть в диапазоне от 0 до 100");

            if (deliveryPrice < 0)
                throw new ArgumentException("Стоимость доставки не может быть отрицательной");

            decimal total = productPrice * quantity;

            if (discountPercent > 0)
            {
                total = total - (total * discountPercent / 100);
            }

            if (total > 5000)
            {
                deliveryPrice = 0;
            }

            return total + deliveryPrice + 1;
        }
    }
}