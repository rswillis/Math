﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math
{
    public class Program
    {
        public void Main(string[] args)
        {
            string operation = "add";
            int x, y, z = 0;
            int biggestNumber = 20, rightAnswers = 0, wrongAnswers = 0, totalQuestions = 0;

            Random rnd = new Random();

            Console.WriteLine("please tell me if you would like to add or subtract");
            operation = Console.ReadLine().ToLower(); 

            while(!((operation == "add") || (operation == "subtract")))
            {
                Console.WriteLine("please tell me if you would like to add or subtract");
                operation = Console.ReadLine().ToLower();
            }


            Console.WriteLine("type stop when you are done");

            x = rnd.Next(1, biggestNumber + 1);
            y = rnd.Next(1, biggestNumber + 1);
            totalQuestions = 1;


            while (true)
            {
                if (operation == "add")
                {
                    Console.WriteLine("{0} + {1}", x, y);
                    z = x + y;
                }
                else if (operation == "subtract")
                {
                    //make sure subtraction can't go into negative numbers
                    if (y > x)
                        swap(ref x, ref y);

                    Console.WriteLine("{0} - {1}", x, y);
                    z = x - y;
                }

                var response = Console.ReadLine().ToLower();

                if (response == z.ToString())
                {
                    Console.WriteLine("Correct!");

                    rightAnswers = rightAnswers + 1;

                    x = rnd.Next(1, biggestNumber);
                    y = rnd.Next(1, biggestNumber);

                    totalQuestions = totalQuestions + 1;
                }
                else if (response == "add")
                {
                    operation = "add";
                }
                else if(response == "subtract")
                {
                    operation = "subtract";
                }
                else if((response == "stop") ||
                    (response == "quit") ||
                    (response == "end"))
                {
                    Console.WriteLine("Out of a total of {0} questions", totalQuestions.ToString());
                    Console.WriteLine("You had {0} right answers and {1} wrong answers.", rightAnswers.ToString(), wrongAnswers.ToString());
                    calculateScore(rightAnswers, wrongAnswers);
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Try Again");
                    wrongAnswers = wrongAnswers + 1;
                }
            }
        }

        private void calculateScore(decimal rightAnswers, decimal wrongAnswers)
        {
            decimal totalAttempts = rightAnswers + wrongAnswers;
            var percentage = System.Math.Round(((rightAnswers / totalAttempts) * 100), 2);
            string letterGrade = null;

            if (percentage == 100)
                letterGrade = "A+";
            else if (percentage < 100 && percentage >= 93)
                letterGrade = "A";
            else if (percentage < 93 && percentage >= 90)
                letterGrade = "A-";
            else if (percentage < 90 && percentage >= 87)
                letterGrade = "B+";
            else if (percentage < 87 && percentage >= 83)
                letterGrade = "B";
            else if (percentage < 83 && percentage >= 80)
                letterGrade = "B-";
            else if (percentage < 80 && percentage >= 77)
                letterGrade = "C+";
            else if (percentage < 77 && percentage >= 73)
                letterGrade = "C";
            else if (percentage < 73 && percentage >= 70)
                letterGrade = "C-";
            else if (percentage < 70 && percentage >= 67)
                letterGrade = "D+";
            else if (percentage < 67 && percentage >= 63)
                letterGrade = "D";
            else if (percentage < 63 && percentage >= 60)
                letterGrade = "D-";
            else
                letterGrade = "F";

            Console.WriteLine("Your score was {0} - {1}", percentage.ToString(), letterGrade);
        }

        private void swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
    }
}