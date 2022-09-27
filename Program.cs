using System;
using System.Text.RegularExpressions;

static string getNextNumber(int current)
{
    int nextNumber = current + 1;
    Globals.currentNumber = nextNumber;
    return nextNumber.ToString();
}

static void startProgram()
{
    Console.WriteLine($"Welcome to Fizz Buzz!");
    Console.WriteLine(Globals.spacing + "Press any key to start...");
    Console.ReadLine();
    nextQuestion();
}

static void nextQuestion()
{
    Console.Clear();
    Console.WriteLine(Globals.currentNumber);
    string userInput = Console.ReadLine();
    if (userInput == getNextNumber(Globals.currentNumber))
    {
        if (!Globals.numRegex.IsMatch(userInput)) handleIncorrect();
        else
        {
            if (isItDivisibleBy3_Or_5(int.Parse(userInput))) handleIncorrect();
            else nextQuestion();
        }
    }
    else
    {
        if (userInput == "fizz" || userInput == "buzz")
        {
            if (isItDivisibleBy3_Or_5(Globals.currentNumber)) nextQuestion();
            else handleIncorrect();
        }
        else handleIncorrect();
    }
}

static bool isItDivisibleBy3_Or_5(int num)
{
    if (num % 3 == 0) {
        return true;
    }
    else if (num %  5 == 0) 
    {
        return true;
    }
    else return false;
}

static void handleIncorrect()
{
    Console.WriteLine("Incorrect answer!");
    string correctEnding = isItDivisibleBy3_Or_5(Globals.currentNumber) ? (Globals.currentNumber % 3 == 0 ? "fizz" : "buzz") : Globals.currentNumber.ToString();
    Console.WriteLine("The correct answer was: " + correctEnding);
    Console.WriteLine(Globals.spacing + "Press any key to continue...");
    Console.ReadLine();
    Globals.currentNumber = 0;
    nextQuestion();
}

startProgram();

public static class Globals
{
    public static int currentNumber = 1;
    public static string spacing = "\n\n";
    public static Regex numRegex = new Regex(@"^\d+$");

}
