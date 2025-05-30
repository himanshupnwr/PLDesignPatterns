using System.Globalization;
using ChainOfResponsibility.V2.CustomExceptions;

namespace ChainOfResponsibility.V2.Validator
{
    public class SocialSecurityNumberValidator
    {
        public bool Validate(string socialSecurityNumber, RegionInfo regionInfo)
        {
            return regionInfo.TwoLetterISORegionName switch
            {
                "SE" => ValidateSwedishSocialSecurityNumber(socialSecurityNumber),
                "US" => ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber),
                _ => throw new UnsupportedSocialSecurityNumberException("Invalid Region")
            };
        }

        private bool ValidateSwedishSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 1;
        }

        private bool ValidateUnitedStatesSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 2;
        }
    }
}
