using System;
using System.Collections.Generic;

class Turer
{
    public static void Main (string[] args) 
    {

        //important variables
        List<int> tape = new List<int>();
        tape.Add(0);
        int pointer = 0;

        Console.WriteLine("Start Coding:");
        
        //Handles Readline and unbalanced parenthesis
        char[] chararr = Console.ReadLine().ToCharArray();
        char[] parenthesis = Array.FindAll(chararr, x => x is '(' or ')');
        Func<int, bool> balancecheck = x => x % 2 != 0;
        if (balancecheck(parenthesis.Length)) throw new InvalidOperationException("The program has an unbalanced parenthesis");

        int count = 0;
        while (chararr.Length > count)
        {
            
            switch(chararr[count])
            {
                case '>':
                    tape.Add(0);
                    pointer++;
                    break;
        
                case '<':
                    if (pointer == 0) throw new InvalidOperationException("The Tape cannot go below zero");
                    pointer--;
                    break;
        
                case '+':
                    tape[pointer]++;
                    break;
        
                case '-':
                    if (tape[pointer] == 0) throw new InvalidOperationException("The value of the Tape cannot go below zero");
                    tape[pointer]--;
                    break;
        
                case '|':
                    Console.Write(Convert.ToChar(tape[pointer]));
                    break;
        
                case '*':
                    var input = Console.ReadLine();
                    if (input.Length != 1) throw new InvalidOperationException("The input must be of length 1");
                    tape[pointer] += input[0];
                    break;
        
                // case '(' & pointer == 0:
        
            }
            count++;
        }
    }
}