using System;
public class GuessingGame {
    int number;
    const int MAX_NUMBER = 100;
    const int MAX_TRIES = 10;
    public static int TotalTries= 0;
    public static int NumGames = 0;
    public GuessingGame(int number){
        this.number = number;
    }
    public static int checkGuess(int guess, int num){
        if(guess > num){
            return 1;
        }else if(guess < num){
            return -1;
        }
        else{
            return 0;
        }
    }
    public static void Main(string[] args) {
        Random rgen = new Random();
        while(true){
            GuessingGame game = new GuessingGame(rgen.Next(MAX_NUMBER)+ 1);
            int num = game.number;
            int guess = 0;
            int tries = 0;
            while(guess != num && tries < MAX_TRIES){
                Console.WriteLine("Enter Number: ");
                guess = Convert.ToInt32(Console.ReadLine());
                if(guess >= 0 && guess <= 100){
                    int result = checkGuess(guess, num);
                    if(result == 1){
                        Console.WriteLine("Too high");
                        tries++;
                    }else if(result == -1){
                        Console.WriteLine("Too low");
                        tries++;
                    }
                    else if(result == 0){
                        Console.WriteLine("Correct");
                        Console.WriteLine("Tries: " + tries);
                        NumGames++;
                        TotalTries+=tries;
                        Console.WriteLine("Total games: " + NumGames);
                        Console.WriteLine("Total tries: " + TotalTries);
                        break;
                    }
                    Console.WriteLine("Tries left: " + (MAX_TRIES-tries));
                }else{
                    Console.WriteLine("Invalid");
                }
            }
            if(guess != num){
                Console.WriteLine("You Lost");
                Console.WriteLine("The number was: " + num);
                NumGames++;
                TotalTries += tries;
            }
            Console.WriteLine("Play again(y/n)? ");
            string newGame = Console.ReadLine();
            if(newGame != "y"){
                Console.WriteLine("Total games: " + NumGames);
                Console.WriteLine("Total tries: " + TotalTries);
                break;
            }
        }
    }
}