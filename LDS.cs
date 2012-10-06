using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;

namespace Seadragon
{
    public class LDS
    {
        public static List<Student> getMatchingStudents(string givenName, string surname)
        {
            List<Student> matches = new List<Student>();
            
            using (PrincipalContext pc = new PrincipalContext(
                ContextType.ApplicationDirectory, "ailds01v.home.ad1.sou.edu:1556",
                "CN=Users,CN=University", ContextOptions.Negotiate | ContextOptions.SecureSocketLayer))
            {
                SouPerson findPerson = new SouPerson(pc);
                findPerson.GivenName = givenName;
                findPerson.Surname = surname;

                PrincipalSearcher searcher = new PrincipalSearcher(findPerson);
                PrincipalSearchResult<Principal> results = searcher.FindAll();
                
                foreach (SouPerson person in results)
                {                                        
                    if (person.souStudent == true)
                    {
                        Student s = new Student();
                        s.setKey1(person.souStudentKey1);
                        s.setKey2(person.souStudentKey2);
                        s.setUsername(person.Name);
                        matches.Add(s);
                    }
                }

                return matches;
            }
        }
    
    }
}