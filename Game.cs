using System;
using System.Collections.Generic;
using System.Text;

namespace Abducted
{
    class Game
    {

        // Properties
        public string CodeWord
        { get; private set; }

        public string CurrentWord
        // underscores that will be replaced as the current word is guessed
        { get; private set; }

        public int MaxNumberOfGuesses
        { get; }

        public int NumberOfWrongGuesses
        { get; private set; }

        // Fields
        private string[] codeWordsList = new string[] {
      "zag",
      "interactive",
      "development",
      "design",
      "clients",
      "websites",
      "kentico",
      "sitefinity",
      "umbraco"
      };

        private Ufo displayUfo = new Ufo();

        // Constructor
        public Game()
        {
            Random rnd = new Random();
            CodeWord = codeWordsList[rnd.Next(codeWordsList.Length)];

            MaxNumberOfGuesses = 5;
            NumberOfWrongGuesses = 0;

            for (int n = 0; n < CodeWord.Length; n++)
            {
                CurrentWord += "_";
            }
        }

        // Methods
        public void Greet()
        {
            Console.WriteLine("" +
            "ABDUCTED: THE GAME \n" +
            "================== \n" +
            "Greetings, Earthling!  We shall play a game. \n" +
            "You must save your friend from being abducted by guessing a word.");
        }



        public void Display()
        {
            Console.WriteLine(displayUfo.Stringify());
            Console.WriteLine($"Guess this word: {CurrentWord}");
            int GuessesLeft = 5 - NumberOfWrongGuesses;
            Console.WriteLine($"You have {GuessesLeft} guesses remaining.");
        }

        public void Ask()
        {
            Console.Write("Guess a letter!: ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            if (userInput.Trim().Length != 1)
            {
                Console.WriteLine("One letter at a time!");
                return;
            }

            char guessedLetter = userInput.Trim().ToCharArray()[0];

            if (CodeWord.Contains(guessedLetter))
            {
                Console.WriteLine($"Yes! The word contains the letter {guessedLetter}.");
                for (int i = 0; i < CodeWord.Length; i++)
                {
                    if (guessedLetter == CodeWord[i])
                    {
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guessedLetter.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"Nope! {guessedLetter} is not a letter in this word.");
                NumberOfWrongGuesses++;
                displayUfo.AddPart();
            }
        }

        public bool DidWin()
        {
            if (CurrentWord.Equals(CodeWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DidLose()
        {
            if (NumberOfWrongGuesses >= MaxNumberOfGuesses)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
