using System;
using System.IO;

namespace L10._1_InterleavedArray
{
    class Program
    {
        static string[] LoadData()
        {
            StreamReader reader = new StreamReader("NamesAndEmails.txt");

            // First count lines in file
            int numberOfLines = 0;
            while(!reader.EndOfStream)
            {
                reader.ReadLine();
                numberOfLines++;
            }

            reader.Close();


            // As each line describes a record of three string fields
            // we need an array with capacity for three times the number of lines
            string[] data = new string[numberOfLines * 3];

            reader = new StreamReader("NamesAndEmails.txt");

            // data in array is ordered surname, firstname, email
            // Instead of incrementing i by 1 each loop we increment by 3
            // that add on the offset to access the individual data fields
            for (int i = 0; i < numberOfLines; i++)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                data[3 * i] = values[0];
                data[3 * i + 1] = values[1];
                data[3 * i + 2] = values[2];
            }

            reader.Close();

            return data;
        }

        static void SortData(string[] pData)
        {
            // Your codes goes here

            
        }

        static void SaveData(string[] pData)
        {
            StreamWriter writer = new StreamWriter("output.txt");

            // data in array is ordered surname, firstname, email
            // Instead of incrementing i by 1 each loop we increment by 3
            // that add on the offset to access the individual data fields
            for (int i = 0; i < pData.Length; i = i + 3)
            {
                writer.WriteLine(pData[i] + "," + pData[i + 1] + "," + pData[i + 2]);
            }

            writer.Close();
        }

        static void Main(string[] args)
        {
            /* This program demonstrates the difficulties of loading different pieces of data
             * into the same array.
             * For each record there are three strings, a surname, first name and email address.
             * The goal is to load these pieces of data into a single array. Sort the array based on
             * surname and then save the array back to a file
             */

            string[] data = LoadData();
            SortData(data);
            SaveData(data);

        }
    }
}