using Microsoft.AspNetCore.Identity;

namespace FitnessCommunity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public Enums.MeasureType MeasureType { get; set; } = Enums.MeasureType.kg;

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string PublicInfo { get; set; }
    }
}
