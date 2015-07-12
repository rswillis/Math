using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math
{
    public class Program
    {
        public void Main(string[] args)
        {
            bool playAgain = true;
            string operation = "add", response = string.Empty;
            int x, y, z = 0;
            int biggestNumber = 30, gameTime = 120, elapsedSeconds = 0, rightAnswers = 0, wrongAnswers = 0, totalQuestions = 0; 

            Random rnd = new Random();

            while (playAgain)
            {
                Console.WriteLine("You have {0} seconds to answer as many questions as you can", gameTime);
                Console.WriteLine("or you can type stop when you are done");
                Console.WriteLine("The clock starts when you tell me if you would like to add or subtract:");
                operation = Console.ReadLine().ToLower();

                while (!((operation == "add") || (operation == "subtract")))
                {
                    Console.WriteLine("please tell me if you would like to add or subtract");
                    operation = Console.ReadLine().ToLower();
                }


                DateTime start = DateTime.Now;

                x = rnd.Next(1, biggestNumber + 1);
                y = rnd.Next(1, biggestNumber + 1);
                totalQuestions = 0;


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

                    response = Console.ReadLine().ToLower();

                    if (response == z.ToString())
                    {
                        Console.WriteLine("Correct!");

                        totalQuestions = totalQuestions + 1;
                        rightAnswers = rightAnswers + 1;

                        elapsedSeconds = (int)DateTime.Now.Subtract(start).TotalSeconds;
                        if (elapsedSeconds > gameTime)
                        {
                            Console.WriteLine("Time's Up!");
                            break;
                        }

                        x = rnd.Next(1, biggestNumber + 1);
                        y = rnd.Next(1, biggestNumber + 1);

                    }
                    else if (response == "add")
                    {
                        operation = "add";
                    }
                    else if (response == "subtract")
                    {
                        operation = "subtract";
                    }
                    else if (response == string.Empty)
                    {
                        elapsedSeconds = (int)DateTime.Now.Subtract(start).TotalSeconds;
                        showCurrentScore(rightAnswers, wrongAnswers, totalQuestions, elapsedSeconds);
                    }
                    else if ((response == "stop") ||
                        (response == "quit") ||
                        (response == "end"))
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Try Again");
                        wrongAnswers = wrongAnswers + 1;
                    }
                }

                elapsedSeconds = (int)DateTime.Now.Subtract(start).TotalSeconds;
                showCurrentScore(rightAnswers, wrongAnswers, totalQuestions, elapsedSeconds);
                Console.WriteLine("Would you like to play again?");
                response = Console.ReadLine().ToLower();
                playAgain = false;
                if ((response == "yes") || (response == "y"))
                {
                    rightAnswers = 0;
                    wrongAnswers = 0;
                    totalQuestions = 0;
                    playAgain = true;
                }
            }
        }

        private void showCurrentScore(int rightAnswers, int wrongAnswers, int totalQuestions, int elapsedSeconds)
        {
            TimeSpan elapsedTime = new TimeSpan(0,0,elapsedSeconds);
            Console.WriteLine("Out of a total of {0} questions", totalQuestions.ToString());
            Console.WriteLine("You have {0} right answers and {1} wrong answers in {2} minutes and {3} seconds.", rightAnswers.ToString(), wrongAnswers.ToString(), elapsedTime.Minutes, elapsedTime.Seconds);
            calculateScore(rightAnswers, wrongAnswers);
            Console.WriteLine();
        }

        private void calculateScore(decimal rightAnswers, decimal wrongAnswers)
        {
            decimal totalAttempts = rightAnswers + wrongAnswers;
            //todo: divide by zero error
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
