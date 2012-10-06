using System;
using System.Web;
using log4net;
using System.Text.RegularExpressions;
using System.DirectoryServices.Protocols;
using System.Collections.Generic;

namespace Seadragon
{
    public class DirMgr
    {
        private static readonly ILog log = LogManager.GetLogger("File");

        /// <summary>
        /// Validates a user's passsword against various authentication sources
        /// </summary>
        /// <param name="username">username of user</param>
        /// <param name="password">password to validate</param>
        /// <param name="sync">whether the authentication sources are in sync</param>
        /// <returns>whether the user could succesfully bind to any directory</returns>
        public static Boolean checkPw(string username, string password)
        {            
            
            Boolean adValid = AD.checkPw(username, password);                

            // Return true if can bind to active directory
            if (adValid)
            {
                log.Info(String.Format("Correct old password for user {0}", username));                
                return true;
            }
            else
            {
                log.Info(String.Format("Incorrect old password for user {0}", username));
                log.Info(String.Format("{0} enabled: {1}", username, AD.isEnabled(username)));
                return false;
            }            
        }

        public static Boolean checkAD(string username, string password)
        {
            // Attempt directory binds
            Boolean adValid = AD.checkPw(username, password);
            if (adValid)
            {
                log.Info(String.Format("Correct Active Directory password for user {0}", username));
                return true;
            }
            else
            {
                log.Info(String.Format("Incorrect Active Directory password for user {0}", username));
                return false;
            }

        }
        public static void setPw(String username, String newPassword)
        {
            log.Debug(String.Format("Setting AD password for user {0}", username));
            AD.setPw(username, newPassword);            
        }

        public static void changePw(String username, String oldPassword, String newPassword)
        {
            log.Debug(String.Format("Changing AD password for user {0}", username));
            AD.setPw(username, newPassword);                        
        }

        /// <summary>
        /// Validates that a password meets the complexity policy
        /// </summary>
        /// <param name="value">password to validate</param>
        /// <param name="errorMessage">message returned when passoword does not meet requirements</param>
        /// <returns>whether or not the password meets the requirements</returns>
        public static Boolean isValidPassword(String value, out String errorMessage)
        {
            const string passwordSizeRegex = "(?=^.{6,255}$)";
            const string uppercaseRegex = "(?=.*[A-Z])";
            const string lowercaseRegex = "(?=.*[a-z])";
            const string punctuationRegex = @"(?=.*\d)";
            const string upperlowernumericRegex = "(?=.*[^A-Za-z0-9])";

            Boolean isValid;
            Regex regex = new Regex(
               passwordSizeRegex +
               "(" + punctuationRegex + uppercaseRegex + lowercaseRegex +
                  "|" + punctuationRegex + upperlowernumericRegex + lowercaseRegex +
                  "|" + upperlowernumericRegex + uppercaseRegex + lowercaseRegex +
                  "|" + punctuationRegex + uppercaseRegex + upperlowernumericRegex +
               ")^.*");

            if (value == null || value.Trim() == string.Empty)
            {
                isValid = false;
                errorMessage = "Password may not be blank.";
            }
            else
            {
                if (regex.Match(value).Success)
                {
                    isValid = true;
                    errorMessage = "";
                }
                else
                {
                    isValid = false;
                    errorMessage = "Password does not meet the <br />complexity requirements.";
                }
            }
            return isValid;
        }

        /// <summary>
        /// Tests whether or not givenName, surname, id and dob match a user
        /// </summary>
        /// <param name="givenName">Last name</param>
        /// <param name="surname">First name</param>
        /// <param name="id">SSN or 940</param>
        /// <param name="dob">Date of birth</param>
        /// <returns>
        /// username if a match is found
        /// empty string if a match is not found        
        /// </returns>
        public static string isValidKey(string givenName, string surname, string id, string strRawDOB)
        {
            string key1, key2, username;
            List<Student> matches;
            Student s = new Student();
            String dob = "";

            givenName = givenName.Trim();
            surname = surname.Trim();

            // Parse Calendar picker date into MMDDYY            
            try
            {                
                
                DateTime objDOB = DateTime.Parse(strRawDOB);
                dob = objDOB.ToString("MMddyy");
            }
            catch
            {                
                // Try MMddyy
                try
                {
                    DateTime objDOB = DateTime.ParseExact(strRawDOB, "MMddyy", null);
                    dob = objDOB.ToString("MMddyy");
                }
                catch
                {
                    try
                    {
                        // Try MMddyyyy
                        DateTime objDOB = DateTime.ParseExact(strRawDOB, "MMddyyyy", null);
                        dob = objDOB.ToString("MMddyy");
                    }
                    catch
                    {
                        return "";
                    }
                }                
            }
            

            matches = LDS.getMatchingStudents(givenName, surname);

            foreach (Student m in matches)
            {
                if (m.isKey(id, dob))
                {
                    log.Debug(String.Format("Student Key is valid for {0}", m.getUsername()));
                    return m.getUsername();
                }
                else
                {
                    log.Debug(String.Format("Student Key is invalid for {0}", m.getUsername()));
                }
            }

            return "";                                    
        }
        
        public static void activateAccount(string username, string password)
        {
            log.Debug(String.Format("Activating account for {0}", username));
            
            AD.enableAccount(username);
            setPw(username, password);
      
            log.Info(String.Format("Account activated for {0}", username));
        }
    }
}