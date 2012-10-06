using System;
using System.DirectoryServices.AccountManagement;

namespace Seadragon
{
    public class AD
    {
        private static String DOMAIN = "SOU";

        public static Boolean checkPw(String username, String password)
        {
            if (password == String.Empty)
                return false;

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, DOMAIN))
            {
                Boolean isValid = pc.ValidateCredentials(username, password);
                return isValid;
            }
        }

        public static Boolean isEnabled(String username)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, DOMAIN))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);

                if (user == null)
                    return false;
                
                if ((bool)user.Enabled)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Administratively sets a user's password. Adminisitrative sets do not check against against password history
        /// TODO: Get AD credentials from web.config
        /// </summary>
        /// <param name="username">username of user to reset password for</param>
        /// <param name="newPassword">the new password</param>
        public static void setPw(String username, String newPassword)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, DOMAIN))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);
                user.SetPassword(newPassword);
            } 
        }

        public static void changePW(String username, String oldPassword, String newPassword)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, DOMAIN, username, oldPassword))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);
                user.ChangePassword(oldPassword, newPassword);                
            }
        }

        public static void enableAccount(String username)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, DOMAIN))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);
                user.Enabled = true;
                user.Save();
            }
        }

        public static DateTime? getExpiration(string username)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, DOMAIN))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);                
                
                return user.AccountExpirationDate;
            }
        }

        public static DateTime? getLastPasswordSet(string username)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, DOMAIN))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);

                return user.LastPasswordSet;
            }
        }   

        public static string getHome(string username)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, DOMAIN))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);

                return user.HomeDirectory;
            }
        }
             
    }
}