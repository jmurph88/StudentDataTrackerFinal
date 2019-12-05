//Jennifer Murphy
//December 6, 2019
//C# Class

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace StudentTrackerTest
{
    class Program
    {
        // Creating StudentData list to be accessed by all functions in class
        public static List<StudentData> StudentDataList = new List<StudentData>();

        // Loading the Data from the File(Input)
        static void LoadData(string pFilePath)
        {
            StudentData s;
            string inline;
            string[] values;

            try
            {
                if (File.Exists(pFilePath))
                {
                    using (StreamReader sr = new StreamReader(pFilePath))
                    {
                        while ((inline = sr.ReadLine()) != null)
                        {
                            values = inline.Split(',');
                            //s = StudentData.FromData(inline);
                            s = new StudentData(values[0], values[1], values[2], values[3], values[4], values[5], values[6]); //index was outside bounds of array?
                            StudentDataList.Add(s);
                        }
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            char choice;
            string name;
            bool isDone = false;

            // The following declaration will build a string of your current directory with the CSV filename
            string filePath = Path.Combine(Environment.CurrentDirectory, "StudentDataCSVTest.csv");

            try
            {
                // Loads data from csv file and readies if for processing
                LoadData(filePath);

                // While user does not QUIT, continually show the menu of options available
                while (!isDone)
                {
                    // Displays Menu for user
                    choice = StudentDataFunc.DisplayMenu();

                    if (choice == 'F') // Option: FIND ***This is not functional at this time due to dotnet.exe error***
                    {
                        // Search List of Students
                        Console.WriteLine(" ");
                        Console.WriteLine("Please Enter \r\n [F] to search by student's first name, \r\n [L] to search by student's last or \r\n [T] to search teacher name:");
                        name = Console.ReadLine().ToUpper();

                        if (name == "F")
                        {
                            searchByFirstName();
                            break;
                        }

                        else if (name == "L")
                        {
                            searchByLastName();
                            break;
                        }

                        else if (name == "T")
                        {
                            searchByTeacherName();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("No matching records found.");
                        }
                        Console.WriteLine(" ");
                    }

                    else if (choice == 'A') // Option: ADD
                    {
                        // Get data from the user to add to the student list
                        Console.WriteLine(" ");
                        Console.WriteLine("Enter first name of student to be added:");
                        string FNameInput = Console.ReadLine();

                        Console.WriteLine("Enter last name of student to be added:");
                        string LNameInput = Console.ReadLine();

                        Console.WriteLine("Enter the last name of the student's teacher:");
                        string TeacherNameInput = Console.ReadLine();

                        Console.WriteLine("Enter Quiz 1 score:");
                        int Quiz1Input = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Quiz 2 score:");
                        int Quiz2Input = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Quiz 3 score:");
                        int Quiz3Input = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Quiz 4 score:");
                        int Quiz4Input = Convert.ToInt32(Console.ReadLine());

                        StudentDataList.Add(new StudentData(FNameInput, LNameInput, TeacherNameInput, Quiz1Input.ToString(),
                                        Quiz2Input.ToString(), Quiz3Input.ToString(), Quiz4Input.ToString()));

                        SaveData(filePath);

                        Console.WriteLine(" ");
                        Console.WriteLine("Your data has been added.");
                        Console.WriteLine(" ");
                    }

                    else if (choice == 'D') // Option: DELETE
                    {
                        DeleteStudent();
                        Console.WriteLine(" ");
                        SaveData(filePath);
                    }

                    else if (choice == 'E')
                    {
                        StudentUpdate();
                        SaveData(filePath);
                    }

                    else if (choice == 'P') // Option: PRINT
                    {
                        // Print the student data to the screen
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Student     \tTeacher\tQz 1\tQz 2\tQz 3\tQz 4");
                        Console.WriteLine("--------    \t-------\t----\t----\t----\t----");
                        foreach (StudentData item in StudentDataList)
                        {
                            Console.WriteLine(item.LName + ", " +
                                item.FName + "\t" +
                                item.TeacherName + "\t" +
                                item.Quiz1 + "\t" +
                                item.Quiz2 + "\t" +
                                item.Quiz3 + "\t" +
                                item.Quiz4);
                        }
                        Console.WriteLine();
                    }

                    else if (choice == 'Q') // Option: QUIT
                    {
                        // Save the student data and then set the done flag to exit the while loop
                        SaveData(filePath);
                        isDone = true;
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Your input is invalid.", innerException: ex);
            }
        }


        // Save the student data to the file
        public static void SaveData(string pFilePath)
        {
            using (StreamWriter sw = new StreamWriter(pFilePath, false))
            {
                foreach (StudentData s in StudentDataList)
                {
                    sw.WriteLine(s.ToData());
                }
            }
        }

        //Searches student data List by Student First Name
        public static void searchByFirstName()
        {

            Console.WriteLine("Enter first name of student:");
            string input = Console.ReadLine();
            foreach (StudentData result in StudentDataList.Where(s => s.FName.Contains(input)))
            {
                Console.WriteLine(result);
            }
        }

        //Searches student data list by student last name
        public static void searchByLastName()
        {
            Console.WriteLine("Enter last name of student:");
            string input = Console.ReadLine();
            foreach (StudentData result in StudentDataList.Where(s => s.LName.Contains(input)))
            {
                Console.WriteLine(result);
            }
        }

        //Searches student data list by teacher name
        public static void searchByTeacherName()
        {
            Console.WriteLine("Enter teacher name:");
            string input = Console.ReadLine();
            foreach (StudentData result in StudentDataList.Where(s => s.TeacherName.Contains(input)))
            {
                Console.WriteLine(result);
            }
        }

        //Deleting a student from the student tracker or returns to main menu
        public static void DeleteStudent()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter the last name of the student you wish to delete:");
            string deleteInput = Console.ReadLine();
            Console.WriteLine("You are deleting " + deleteInput + ". Is this correct? [Y]es or [N]o");
            char answerInput = Console.ReadKey().KeyChar;
            if (answerInput == 'Y')
            {
                foreach (StudentData deleteResult in StudentDataList.ToList().Where(s => s.LName.Contains(deleteInput)))
                {
                    StudentDataList.Remove(deleteResult);
                }

                Console.WriteLine(" ");
                Console.WriteLine("You have succesfully deleted a student.");

            }
            else if (answerInput == 'N')
            {
                StudentDataFunc.DisplayMenu();
            }
        }

        //Edits student's quiz scores - allows user to pick which score to edit and replaces old score with new score
        //(Things to Improve: - needs to be able to edit student name and teacher name 
                           //- return to quiz selection menu or main menu option)
        public static void StudentUpdate()
        {
            char quizName;
            Console.WriteLine("");
            Console.WriteLine("Enter the last name of the student whose quiz scores you would like to edit:");
            string editInput = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Please Enter \r\n [A] to edit Quiz 1 \r\n [B] to edit Quiz 2 \r\n [C] to edit Quiz 3 \r\n [D] to edit Quiz 4");
            quizName = Console.ReadKey().KeyChar;

            if (quizName == 'A')
            {
                //Reads user input and updates Quiz1 for the selected student
                Console.WriteLine("Enter the new score for Quiz 1: ");
                int nQuiz1 = Convert.ToInt32(Console.ReadLine());
                StudentDataList.Where(s => s.LName.Contains(editInput)).ToList().ForEach(i => i.Quiz1 = nQuiz1);

                Console.WriteLine("The student's quiz score has been updated.");
                Console.WriteLine(" "); //Creates empty line before menu displays again to improve readability 
            }

            else if (quizName == 'B')
            {
                //Reads user input and updates Quiz2 for the selected student
                Console.WriteLine("Enter the new score for Quiz 2: ");
                int nQuiz2 = Convert.ToInt32(Console.ReadLine());
                StudentDataList.Where(s => s.LName.Contains(editInput)).ToList().ForEach(i => i.Quiz2 = nQuiz2);

                Console.WriteLine("The student's quiz score has been updated.");
                Console.WriteLine(" ");
            }

            else if (quizName == 'C')
            {
                //Reads user input and updates Quiz3 for the selected student
                Console.WriteLine("Enter the new score for Quiz3: ");
                int nQuiz3 = Convert.ToInt32(Console.ReadLine());
                StudentDataList.Where(s => s.LName.Contains(editInput)).ToList().ForEach(i => i.Quiz3 = nQuiz3);

                Console.WriteLine("The student's quiz score has been updated..");
                Console.WriteLine(" ");
            }

            else if (quizName == 'D')
            {
                //Reads user input and updates Quiz4 for the selected student
                Console.WriteLine("Enter the new score for Quiz 4: ");
                int nQuiz4 = Convert.ToInt32(Console.ReadLine());
                StudentDataList.Where(s => s.LName.Contains(editInput)).ToList().ForEach(i => i.Quiz4 = nQuiz4);

                Console.WriteLine("The student's quiz score has been updated.");
                Console.WriteLine(" ");
            }
            //Catches input that is incorret
            else if (quizName != 'A' || quizName != 'B' || quizName != 'C' || quizName != 'D')
            {
                Console.WriteLine("The letter you have entered is not valid.");
            }

        }

    }
}


