using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices.AccountManagement;

namespace Seadragon
{
    [DirectoryObjectClass("user")]
    public class SouPerson : UserPrincipal
    {
        // Implement the constructor using the base class constructor.
        public SouPerson(PrincipalContext context) : base(context)
        {
        }

        SouPersonSearchFilter searchFilter;

        new public SouPersonSearchFilter AdvancedSearchFilter
        {
            get
            {
                if (null == searchFilter)
                    searchFilter = new SouPersonSearchFilter(this);

                return searchFilter;
            }
        }
                                
        [DirectoryProperty("souStudentKey1")]
        public string souStudentKey1
        {
            get
            {
                if (ExtensionGet("souStudentKey1").Length != 1)
                    return null;

                return (string)ExtensionGet("souStudentKey1")[0];
            }
        }

        [DirectoryProperty("souStudentKey2")]
        public string souStudentKey2
        {
            get
            {
                if (ExtensionGet("souStudentKey2").Length != 1)
                    return null;

                return (string)ExtensionGet("souStudentKey2")[0];
            }
        }

        [DirectoryProperty("souStudent")]
        public bool? souStudent
        {
            get
            {
                if (ExtensionGet("souStudent").Length != 1)
                    return false;

                return (bool?) ExtensionGet("souStudent")[0];
            }
        }
        
        // Implement the overloaded search method FindByIdentity
        public static new SouPerson FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
        {
            SouPerson result = (SouPerson) FindByIdentityWithType(context, typeof(SouPerson), identityType, identityValue);
            return result;
        }
    }
   
    public class SouPersonSearchFilter : AdvancedFilters
    {
        public SouPersonSearchFilter(Principal p) : base(p) { }

        public void souStudentKey1(string value, MatchType mt)
        {
            this.AdvancedFilterSet("givenName", value, typeof(string), mt);
        }

        public void souStudentKey2(string value, MatchType mt)
        {
            this.AdvancedFilterSet("sn", value, typeof(string), mt);
        }
    }
}