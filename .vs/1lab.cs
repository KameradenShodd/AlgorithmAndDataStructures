using System.ComponentModel.Design;

namespace lab1;

class Program
{
    static void Main(string[] args)
    //This method launches the game and gather statistics(minimal, maximal amount of turns per game, overall amount of turns in game and how many times game was played.
    {
        int min = 0;
        int max = 0;
        int count = 0;
        int countgame = 0;
        do
        {
            Console.WriteLine("Let's play a game, pal. I will think of a number from 1 to 100, and you will try to guess it. I will tell you if your number is bigger or smaller than mine. Don't disappoint me, pal.");
            int counter = Game();
            if (counter < min || min == 0)
                min = counter;
            if (counter < max)
                max = counter;
            countgame++;
            count = count + counter;
        } while (AskToContinue() == 'Y');
        Console.WriteLine($"Pal, minimal number of your attempts are {min}, maximal are {max}, your number of attempts - {count}, overall you played for {countgame} times");
    }
    static int GameCheck(int a, int b)
    //Checks if the input number is bigger, smaller, or equal to the random number. It's called in Game with the input number and random number.
    {
        if (a > b)
            Console.WriteLine("Your number is bigger than the random number, pal");
        else if (a < b)
            Console.WriteLine("Your number is smaller than the random number, pal");
        else
        {
            Console.WriteLine("Took you long enough.");
            return 0;
        }
        return -1; // just to satisfy the compiler
    }
    static int Game()
    //The game: generates a random number, calls IntelligenceTest to get a number from the user, then calls GameCheck with receivednum and randomnum.
    {
        Random rnd = new Random();
        int counter = 0;
        int randomnum = rnd.Next(1, 101);
        while (true)
        {
            int receivednum = IntelligenceTest();
            counter++;
            if (GameCheck(receivednum, randomnum) == 0)
            {
                return counter;
            }
        }
    }
    static int IntelligenceTest()
    //Gets a number from the user and checks if it's in the stated range.
    {
        {
            int receivednum = 0;

            for (int i = 0; i < 3; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out receivednum) || receivednum > 100 || receivednum < 1)
                {
                    Console.WriteLine("Don't make a fool of yourself. Enter a number in the range from 1 to 100");
                }
                else
                {
                    return receivednum;
                }

                if (i == 2)
                {
                    Console.WriteLine("...Or...Seems like you are fudging dumb, pal. I LEAVE, LOSER!");
                    Environment.Exit(0);
                }
            }
            return 0; // just to satisfy the compiler

        }
    }
    static char AskToContinue()
    //Asks player if they want to continue
    {
        Console.WriteLine("Did you enjoy the game, pal? (Y/N)");
        char answer = Convert.ToChar((Console.Read()));
        Console.ReadLine(); //needed to prevent game calling user fool

        if (answer == 'Y'|| answer == 'y')
            return 'Y';
        else
            return 'N';
        }
    }
