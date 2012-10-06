using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Seadragon
{
    public class Student
    {
        private String username;
        private String key1;
        private String key2;
                
        public void setKey1(String key1)
        {
            this.key1 = key1;
        }

        public void setKey2(String key2)
        {
            this.key2 = key2;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }

        public Boolean isKey(String id, String dob)
        {
            if (computeKey(id, dob).Equals(key1) || computeKey(id, dob).Equals(key2))
                return true;
            else
                return false;
        }

        public String getUsername()
        {
            return this.username;
        }

        /// <summary>
        /// Returns the student key (hex md5) for an id and birthdate combination
        /// </summary>
        /// <param name="id">ID, which should be SSN or 940</param>
        /// <param name="dob">Birthdate</param>
        /// <returns>Student Key</returns>
        public static String computeKey(String id, String dob)
        {
            MD5CryptoServiceProvider csp = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(dob + id);
            data = csp.ComputeHash(data);

            String key = "";
            for (int i = 0; i < data.Length; i++)
                key += data[i].ToString("x2").ToUpper();

            return key;
        }
    }
}