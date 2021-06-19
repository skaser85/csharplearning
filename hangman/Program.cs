using System;
using System.Collections.Generic;

namespace hangman
{
    class Program
    {
        static void DrawHangman(bool head, bool leftArm, bool rightArm, bool torso, bool leftLeg, bool rightLeg, string word, List<Letter> letters)
        {
            string onlyPole = "|    ";
            
            Console.WriteLine("|---|");
            
            if (head) 
                Console.WriteLine("|   O");
            else
                Console.WriteLine(onlyPole);

            if (leftArm && torso && rightArm)
                Console.WriteLine("|  /|\\");
            else if (leftArm && torso && !rightArm)
                Console.WriteLine("|  /|");
            else if (leftArm && !torso && !rightArm)
                Console.WriteLine("|  /");
            else if(!leftArm && torso && rightArm)
                Console.WriteLine("|   |\\");
            else if(!leftArm && !torso && rightArm)
                Console.WriteLine("|    \\");
            else if (!leftArm && !torso && !rightArm)
                Console.WriteLine(onlyPole);

            if (leftLeg && rightLeg)
                Console.WriteLine("|  / \\");
            else if (leftLeg && !rightLeg)
                Console.WriteLine("|  /");
            else if (!leftLeg && rightLeg)
                Console.WriteLine("|    \\");
            else if (!leftLeg && !rightLeg)
                Console.WriteLine(onlyPole);
            
            Console.WriteLine(onlyPole);
            Console.WriteLine(new String('=', word.Length));
            string output = "";
            foreach (Letter l in letters) {
                if (l.guessed)
                    output += l.letter;
                else
                    output += "_";
            }
            Console.WriteLine(output);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            
            Random random = new Random();
            
            string[] words = new string[50]{"brother","haunt","relax","complex","dark","foot","nonstop","whisper","fact","curvy","prevent","stupendous","aquatic","whirl","obscene","enthusiastic","anger","political","mellow","grease","account","loss","hard","forgetful","endurable","colour","shaggy","statement","label","limit","hideous","bang","rock","soothe","shoes","white","pail","attack","worthless","recondite","impress","matter","curly","hug","tremendous","reflect","club","form","hushed","spiffy"};
            string word = words[random.Next(words.Length)];
            
            var letters = new List<Letter>{};
            foreach(char l in word) {
                letters.Add(new Letter(l,false));
            }
            
            string guessedLetters = "";
            int wrongGuesses = 0;
            
            bool head = false;
            bool leftArm = false;
            bool rightArm = false;
            bool torso = false;
            bool leftLeg = false;
            bool rightLeg = false;
            
            DrawHangman(head, leftArm, rightArm, torso, leftLeg, rightLeg, word, letters);
            
            Console.WriteLine("To save this poor soul's life, it's up to you to guess the mystery word one letter a time.");
            Console.WriteLine("Capitalization does NOT matter.  You have 6 incorrect guesses left.");
            Console.WriteLine("Good luck!\n");

            bool finished = false;
            bool hanged = false;

            do {
                Console.Write("Guess a letter: ");
                string guess = Console.ReadLine().ToLower();
                if (guess.Length > 1) {
                    Console.WriteLine("Invalid text.  Only 1 letter a time, please.");
                    continue;
                }
                if (guessedLetters.Contains(guess)) {
                    Console.WriteLine("You've already guessed this letter!");
                    continue;
                }
                guessedLetters += guess;
                if (word.Contains(guess)) {
                    char guessChar = char.Parse(guess);
                    foreach (Letter l in letters) {
                        if (l.letter == guessChar) {
                            l.guessed = true;
                        }
                    }
                    bool allFound = true;
                    foreach (Letter l in letters) {
                        if (l.guessed == false) {
                            allFound = false;
                            break;
                        }
                    }
                    Console.WriteLine("Great work!  You found a letter!");
                    if (allFound) finished = true;
                } else {
                    switch (wrongGuesses) {
                        case 0:
                            head = true;
                            break;
                        case 1:
                            torso = true;
                            break;
                        case 2:
                            leftArm = true;
                            break;
                        case 3:
                            rightArm = true;
                            break;
                        case 4:
                            leftLeg = true;
                            break;
                        case 5:
                            rightLeg = true;
                            break;
                    }
                    wrongGuesses += 1;
                    Console.WriteLine("Nope!");
                    if (wrongGuesses == 6) {
                        Console.WriteLine("Womp! Womp! He hangs!");
                        finished = true;
                        hanged = true;
                    }
                }
                DrawHangman(head, leftArm, rightArm, torso, leftLeg, rightLeg, word, letters);
                Console.WriteLine($"Letters you've already guessed: {guessedLetters}");
                Console.WriteLine($"You have {6 - wrongGuesses} incorrect guesses left.");
            } while (!finished);

            if (hanged) {
                Console.WriteLine("While halcyon days of yore race through the condemned's mind as the noose breaks his neck, you can take comfort in the fact that justice was indeed served.");
                Console.WriteLine($"The word you were looking for was: {word}");
            } else {
                Console.Write("He lives!  Congratulations!");
            }
            Console.WriteLine();
        }
    }

    public class Letter
    {
        public char letter { get; set; }
        public bool guessed { get; set; }

        public Letter(char theLetter, bool hasBeenGuessed)
        {
            letter = theLetter;
            guessed = hasBeenGuessed;
        }
    }
}