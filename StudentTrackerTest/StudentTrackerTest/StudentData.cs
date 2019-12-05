///Jennifer Murphy
//December 6, 2019
//C# Class

using System;
using System.IO;

namespace StudentTrackerTest
{
    //This class states the data types used in the program
    public class StudentData
    {
        //Declaring Fields
        private string _FName;
        private string _LName;
        private string _TeacherName;
        private int _Quiz1;
        private int _Quiz2;
        private int _Quiz3;
        private int _Quiz4;

        //Declaring Properties
        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

        public string LName
        {
            get { return _LName; }
            set { _LName = LName; }
        }

        public string TeacherName
        {
            get { return _TeacherName; }
            set { _TeacherName = TeacherName; }
        }

        public int Quiz1
        {
            get { return _Quiz1; }
            set { _Quiz1 = value; }
        }

        public int Quiz2
        {
            get { return _Quiz2; }
            set { _Quiz2 = value; }
        }

        public int Quiz3
        {
            get { return _Quiz3; }
            set { _Quiz3 = value; }
        }

        public int Quiz4
        {
            get { return _Quiz4; }
            set { _Quiz4 = value; }
        }

        // Creating Constructors
        public StudentData(string pFName, string pLName, string pTeacherName, string pQuiz1, string pQuiz2, string pQuiz3, string pQuiz4)
        {
            _FName = pFName;
            _LName = pLName;
            _TeacherName = pTeacherName;

            _Quiz1 = 0;
            int.TryParse(pQuiz1, out _Quiz1);
            _Quiz2 = 0;
            int.TryParse(pQuiz2, out _Quiz2);
            _Quiz3 = 0;
            int.TryParse(pQuiz3, out _Quiz3);
            _Quiz4 = 0;
            int.TryParse(pQuiz4, out _Quiz4);
        }

        public StudentData()
        {
        }



        // Telling program HOW to store data in csv file
        public string ToData()
        {
            // Take the given data for this record instance and format it into a string
            string result = _FName + "," + _LName + "," + _TeacherName + "," + _Quiz1.ToString() + "," +
                _Quiz2.ToString() + "," + _Quiz3.ToString() + "," + _Quiz4.ToString();
            return result;
        }

        //Storing Data in an Array
        public void FromData(string pData)
        {
            string[] fields;

            fields = pData.Split(',');

            _FName = fields[0];
            _LName = fields[1];
            _TeacherName = fields[2];
            _Quiz1 = int.Parse(fields[3]);
            _Quiz2 = int.Parse(fields[4]);
            _Quiz3 = int.Parse(fields[5]);
            _Quiz4 = int.Parse(fields[6]);
        }
    }
}

