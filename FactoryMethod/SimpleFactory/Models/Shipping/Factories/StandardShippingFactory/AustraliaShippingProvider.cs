using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.SimpleFactory.Models.Shipping.Factories.StandardShippingFactory
{
    public class AustraliaShippingProvider
    {
        public ShippingCostCalculator GetShippingCostCalculator()
        {
            return new ShippingCostCalculator(
                internationalShippingFee: 250,
                extraWeightFee: 500
            )
            {
                ShippingType = ShippingType.Standard
            };
        }

        public CustomsHandlingOptions GetCustomsHandlingOptions()
        {
            return new CustomsHandlingOptions
            {
                TaxOptions = TaxOptions.PrePaid
            };
        }

        public InsuranceOptions GetInsuranceOptions()
        {
            return new InsuranceOptions
            {
                ProviderHasInsurance = false,
                ProviderHasExtendedInsurance = false,
                ProviderRequiresReturnOnDamange = false
            };
        }
    }
}
