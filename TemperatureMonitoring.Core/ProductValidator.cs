using System.ComponentModel.DataAnnotations;

namespace TemperatureMonitoring.Core
{
    public static class ProductValidator
    {
        public static void ValidateProduct(Product product)
        {
            if (product.MinTemperature != int.MinValue && product.MaxTemperature != int.MaxValue && product.MinTemperature < -18 && product.MaxTemperature > 30)
                throw new ValidationException("Wrong temperature");
        }
    }
}