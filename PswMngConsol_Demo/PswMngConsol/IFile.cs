using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PswMngConsol
{
    internal class IFile
    {
        public static string path = @"C:\Dev\";
        public static List<string> readAllLines = new();
        public static List<string> readAllLinesSplit = new();
        public static List<string> fullPathService = new();
        public static List<string> fullPathAdmin = new();
        public static List<string> fileAdminTxt = new();
        public static List<string> fileServiceTxt = new();
        public static List<string[]> listStringArray = new List<string[]>();


        public static void ReadToPersonFromTxtFile(string fullPath)
        {
            readAllLines = File.ReadAllLines(fullPath).ToList(); //Return all text as String array and then convert to List<string>.
            string[] readAllLinesArraySplit = new string[4]; //Der logges HashString,Salt,PswTip,CreationDateTime, derfor length = 4.
            char charSeparator = ',';
            List<CPerson> people = new List<CPerson>();
            foreach (string item1 in readAllLines)
            {
                readAllLinesArraySplit = item1.Split(charSeparator);
                CPerson p = new CPerson(readAllLinesArraySplit[0], readAllLinesArraySplit[1], readAllLinesArraySplit[2], readAllLinesArraySplit[3]);
                people.Add(p);
            }
            int counter = 0;
            foreach (CPerson p in people)
            {
                Console.WriteLine($"Person {counter++} :\n" + p.HashString + " " + p.Salt + " " + p.PswTip + " " + p.CreationDateTime);
            }
            Console.ReadLine();
        }

        
        public static void ReadAllToListStringArrayFromTxtFile(string fullPath)
        {
            readAllLines = File.ReadAllLines(fullPath).ToList(); //Return all text as String array and then convert to List<string>.
            string[] readAllLinesArraySplit; 
            char charSeparator = ',';
            
            foreach (string item1 in readAllLines)
            {
                readAllLinesArraySplit = item1.Split(charSeparator);
                listStringArray.Add(readAllLinesArraySplit);
            }
        }

        public static void OverWritePswTipInTxtFile(string fullPath, string newPswTip)
        {
            //SKAL ÆNDRES TIL DEN GENERELLE ReadAllToListStringArrayFromTxtFile(), listen skal dog først cleares

            listStringArray.Clear();
            ReadAllToListStringArrayFromTxtFile(fullPath);
            string fullTextToOverWrite = $"{listStringArray[0][0]},{listStringArray[0][1]},{newPswTip},{listStringArray[0][3]}"; 
            IFile.ClearAllStrInFileTxt(fullPath);
            IFile.ReadAndOverwriteStrToFileTxt(fullPath, fullTextToOverWrite);
        }

        public static bool FileExists(string fileName, string pathOptional = @"C:\Dev\")
        {
            if (File.Exists(pathOptional + fileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CreateFileTxt(string fileName, string pathOptional = @"C:\Dev\")
        {
            if (File.Exists(pathOptional + fileName))
            {
                Console.WriteLine("Filen findes allerede");
                Console.ReadLine();
            }
            else
            {
                File.Create(pathOptional + fileName).Close();
            }
            
        }

        public static void CreateListFile()
        {
            fileAdminTxt.Add(@$"Admin{0}.txt");         //Creating a 1 Admin file per default 
            for (int i = 0; i < 1000; i++)
            {
                fileServiceTxt.Add(@$"Service{i}.txt"); //Creating a 1000 service files per default 
            }

        }

        public static void CreateFullPathList()
        {
            foreach (string item in fileServiceTxt)
            {
                fullPathService.Add(path + item);
            }

            foreach (string item in fileAdminTxt)
            {
                fullPathAdmin.Add(path + item);
            }

        }

        public static void WriteToConsoleListFileAndFullPath()
        {

            Console.WriteLine(fileAdminTxt[0].ToString());
            foreach (string item1 in fileServiceTxt)
            {
                Console.WriteLine(item1);
            }

            foreach (string item2 in fullPathService)
            {
                Console.WriteLine(item2);
            }
        }

        public static void ReadAndAddStrToFileTxt(string fullPath, string txtToFile)
        {
            File.AppendAllText(fullPath, txtToFile);
        }

        public static void ReadAndOverwriteStrToFileTxt(string fullPath, string txtToFile)
        {
            File.WriteAllText(fullPath, txtToFile);
        }

        public static void ClearAllStrInFileTxt(string fullPath)
        {
            File.WriteAllText(fullPath, String.Empty);
        }

        public static int ReturnElementsInSingleLineFileTxt(string fullPath)
        {
            readAllLines = File.ReadAllLines(fullPath).ToList(); //Return all text as String array and then convert to List<string>.
            string[] readAllLinesArraySplit;
            int arrayLength = 0;
            char charSeparator = ',';
            foreach (string item1 in readAllLines)
            {
                readAllLinesArraySplit = item1.Split(charSeparator);
                arrayLength = readAllLinesArraySplit.Length;
            }
            return arrayLength;
        }

        

    }
}
