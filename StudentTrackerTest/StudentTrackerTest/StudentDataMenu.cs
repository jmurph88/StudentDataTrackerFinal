//Jennifer Murphy
//December 6, 2019
//C# Class

using System;
using System.Collections.Generic;

namespace StudentTrackerTest
{
    public class StudentDataFunc
    {
        //Creating StudentData list to be accessed by all functions in class
        public static List<StudentData> StudentDataList = new List<StudentData>();

        //Show Menu Options and converts user input to char to be read by main()
        public static char DisplayMenu()
        {
            string choice;

            Console.WriteLine("Student Data Tracker");
            Console.WriteLine("Choose an option:");
            //Console.WriteLine("[F]ind");
            Console.WriteLine("[A]dd");
            Console.WriteLine("[D}elete");
            Console.WriteLine("[E]dit Scores");
            Console.WriteLine("[P]rint ");
            Console.WriteLine("[Q]uit");

            choice = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.WriteLine(" ");
            return choice[0];
        }
    }
}

