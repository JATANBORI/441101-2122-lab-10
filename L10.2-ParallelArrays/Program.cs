using System;
using System.IO;

namespace L10._2_ParallelArrays
{
    class Program
    {
        static void LoadData(out string[] pSurnames, out string[] pFirstNames, out int[] pAges)
        {
            StreamReader reader = new StreamReader("NamesAndAges.txt");

            // First count lines in file
            int numberOfLines = 0;
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                numberOfLines++;
            }

            reader.Close();

            reader = new StreamReader("NamesAndAges.txt");

            // As each line describes a record of three string fields
            // create memory in each of the three arrays
            pSurnames = new string[numberOfLines];
            pFirstNames = new string[numberOfLines];
            pAges = new int[numberOfLines];

            // data in the file is ordered surname, firstname, age
            // Read over the file and fill the arrays with data
            for (int i = 0; i < numberOfLines; i++)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                pSurnames[i] = values[0];
                pFirstNames[i] = values[1];
                pAges[i] = int.Parse(values[2]);
            }

            reader.Close();
        }

        static void SortData(string[] pSurnames, string[] pFirstNames, int[] pAges)
        {
            //Enter  your codes here
            
            
        }

        static void SaveData(string[] pSurnames, string[] pFirstNames, int[] pAges)
        {
            StreamWriter writer = new StreamWriter("output.txt");

            for (int i = 0; i < pSurnames.Length; i++)
            {
                writer.WriteLine(pSurnames[i] + "," + pFirstNames[i] + "," + pAges[i]);
            }

            writer.Close();
        }

        static void Main(string[] args)
        {
            /* This program demonstrates the difficulties of loading different pieces of data
             * into the same array.
             * For each record there are two string, a surname and first name, and an integer age.
             * Elements in an array must all be the same type, so we cannot store strings in the
             * same arrays as integers. Instead we will create three arrays - one for each field
             * We will load the date, sort by surname and then save the data back to a file
             */

            string[] surnames;
            string[] firstnames;
            int[] ages;

            LoadData(out surnames, out firstnames, out ages);
            SortData(surnames, firstnames, ages);
            SaveData(surnames, firstnames, ages);
        }
    }
}