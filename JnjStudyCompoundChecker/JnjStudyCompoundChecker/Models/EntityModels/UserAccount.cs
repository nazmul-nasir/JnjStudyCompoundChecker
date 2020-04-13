using System.Collections.Generic;
using JnjStudyCompoundChecker.Models.EntityModels.SubModels;

namespace JnjStudyCompoundChecker.Models.EntityModels
{
    public class UserAccount
    {
        public string SourceId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string IdentityProvider { get; set; }
        public string UniqueAuthenticationId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Address Address { get; set; }
        public string Country { get; set; }
        public string SponsorName { get; set; }
        public string Status { get; set; }
        public string UserType { get; set; }

        public List<BusinessRole> Roles { get; set; }
        public Associations Associations { get; set; }
    }
}
