using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface IHash
    {
        public static byte
            byteArrLen = 8;

        public static string GenerateSalt(byte length)  //Create a random salt string
        {
            RandomNumberGenerator randomNumGen = RandomNumberGenerator.Create();
            byte[] bytes = new byte[length];            //Creates an instance of onedimensional byte array. The highest number in a byte is 256 = 2^8.
            randomNumGen.GetBytes(bytes);               //Fills an array of bytes with a cryptographically strong random sequence of values.
            return Convert.ToBase64String(bytes);       //Converts the byte array to a string
        }

        public static string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);    //Converting the userInput+salt to a byte array (max value 255). The length of the array is defined by the length of the input+salt
            SHA256 sha256 = SHA256.Create();                        //Creates a SHA256 hashAlgorithm
            byte[] hash = sha256.ComputeHash(bytes);                //Convertes the bytes array to a hash containing a byte array with a length of 32.  //IF return Convert.ToBase64String(bytes); //Giver en længde på 40                                                 

            StringBuilder sb = new();
            for (int i = 0; i < hash.Length; i++)
            { sb.Append(hash[i].ToString("x2")); }      //Loop through each byte of the hashed data and format each one as a short hexadecimal string with a length of 2 and use lower case.
            return sb.ToString();                       //Return the short hexadecimal string. Giver en længde på 64.
        }

        public static bool CompareHash(string input, string salt, string hash)      //VERIFFY if string gives the same hash against the hash string
        {
            StringComparer stringComparerCaseSensitive = StringComparer.Ordinal;
            string hashOutput = IHash.GenerateHash(input, salt);                    //Hash the input.
            return stringComparerCaseSensitive.Compare(hashOutput, hash) == 0;      //Return true if perfect match
        }


    }
}
