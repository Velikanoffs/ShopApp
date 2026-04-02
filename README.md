/Краткий анализ/
Какие случаи проверялись
Корректные сценарии: заказы без скидки, со скидкой, с нулевой доставкой, с бесплатной доставкой (при сумме >5000), единичное количество, скидка 0%, скидка 100%.

Граничные значения: нулевая цена, нулевое количество, скидка 0%, скидка 100%, итоговая сумма ровно 5000, итоговая сумма чуть больше 5000.

Ошибочные ситуации: отрицательные цена, количество, скидка, стоимость доставки; скидка больше 100%.

Какие тесты прошли
Все тесты, проверяющие выброс исключений (5 тестов) — прошли, так как валидация работает корректно.

Тест CalculateTotal_TotalExactly5000_DeliveryNotFree — прошёл, условие total > 5000 корректно не обнуляет доставку.

Какие тесты не прошли
Все тесты, проверяющие итоговую сумму (кроме исключений), не прошли из-за наличия в возвращаемом значении лишней единицы (+1).
А именно:

CalculateTotal_NoDiscount_ReturnsCorrectSum

CalculateTotal_WithDiscount_AppliesDiscountCorrectly

CalculateTotal_ZeroDelivery_AddsDeliveryCorrectly

CalculateTotal_TotalAbove5000_DeliveryBecomesFree

CalculateTotal_QuantityOne_WorksCorrectly

CalculateTotal_DiscountZero_NoDiscountApplied

CalculateTotal_Discount100_TotalBecomesZeroPlusDelivery

CalculateTotal_ProductPriceZero_ReturnsDeliveryPlusOne

CalculateTotal_QuantityZero_ReturnsDeliveryPlusOne

CalculateTotal_DiscountZero_NoChange

CalculateTotal_Discount100_FullDiscount

CalculateTotal_TotalJustAbove5000_DeliveryFree

Какие ошибки были обнаружены
Главная ошибка: в строке return total + deliveryPrice + 1; присутствует лишнее добавление +1, которого нет в требованиях. Это приводит к завышению итоговой стоимости на 1 единицу в любом заказе.

Потенциальная неточность (не ошибка, но может не соответствовать требованию «бесплатная доставка при сумме заказа от 5000»): в условии if (total > 5000) используется строгое неравенство, поэтому при total == 5000 доставка не становится бесплатной. Если по бизнес-правилам бесплатная доставка должна быть при сумме ≥5000, то это также ошибка.
