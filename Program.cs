using System;
using System.Collections.Generic;

namespace Tutorial {
    class Program {
        static Random random = new Random();
        static string[] words = {"programowanie", "malowanie"};

        static void Main(string[] args) {
            string word = words[random.Next(0, 1)];
            string blankedWord = charBlank(word);
            int tries = 10;

            Console.WriteLine("You have 10 tries, good luck!");

            while(true) {
                if(tries == 0) {
                    Console.WriteLine("You lost :(");
                    break;
                }

                showBlank(blankedWord);

                Console.Write("Guess: ");
                string input = Console.ReadLine();

                if(input.Length == 1) {
                    char letter = Convert.ToChar(input);

                    if(findLetter(word, letter)) {
                        blankedWord = revealLetter(word, letter, blankedWord);
                    }
                } else {
                    if(word.Equals(input)) {
                        Console.WriteLine("You Won!");
                        break;
                    }
                }

                tries--;
            }
        }

        static string charBlank(string word) {
            string res = "";

            for(int i = 0; i < word.Length - 1; i++) {
                res += "_";
            }

            return res;
        }

        static void showBlank(string blanked) {
            for(int i = 0; i < blanked.Length - 1; i++) {
                Console.Write($"{ blanked[i] } ");
            }
            Console.WriteLine();
        }

        static bool findLetter(string word, char letter) {
            for(int i = 0; i < word.Length - 1; i++) {
                if(letter.Equals(word[i])) {
                    return true;
                }
            }

            return false;
        }

        static string revealLetter(string word, char letter, string blankedWord) {
            List<int> lettersI = new List<int>();
            for(int i = 0; i < word.Length - 1; i++) {
                if(letter.Equals(word[i])) {
                    lettersI.Add(i);
                }
            }

            for(int i = 0; i < lettersI.Count; i++) {
                char[] letters = blankedWord.ToCharArray();
                letters[lettersI[i]] = letter;
                blankedWord = new string(letters);
            }

            return blankedWord;
        }
    }
}
