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
            
            string[] words = new string[50]{"brother","haunt","relax","complex","dark","foot","nonstop","whisper","fact","curvy","prevent","stupendous","aquatic","whirl","obscene","enthusiastic","anger","political","mellow","grease","account","loss","hard","forgetful","endurable","colour","shaggy","statement","label","limit","hideous","bang","rock","soothe","shoes","white","pail","attack","worthless","recondite","impress","matter","curly","hug","tremendous","reflect","club","form","hushed","spiffy"};
            Random random = new Random();
            string word = words[random.Next(words.Length)];
            bool head = false;
            bool leftArm = false;
            bool rightArm = false;
            bool torso = false;
            bool leftLeg = false;
            bool rightLeg = false;
            var letters = new List<Letter>{};
            foreach(char l in word) {
                letters.Add(new Letter(l,true));
            }
            DrawHangman(head, leftArm, rightArm, torso, leftLeg, rightLeg, word, letters);
            Console.WriteLine("To save this poor soul's life, it's up to you to guess the mystery word one letter a time.");
            Console.WriteLine("Capitalization does NOT matter.  You have 6 guesses left.");
            Console.WriteLine("Good luck!\n");
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