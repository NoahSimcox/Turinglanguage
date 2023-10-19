using System;
using System.Collections.Generic;

public class Turer
{
    public static void Main (string[] args) 
    {

        //important variables
        List<int> tape = new List<int>();
        tape.Add(0);
        int pointer = 0;

        Console.WriteLine("Start Coding:");

        string codeline = Console.ReadLine();


        int count = 0;
        while (codeline.Length > count)
        {
            // codeline[count] => codeline[count] == '(' || codeline[count] == ')';
            switch(codeline[count])
            {
                case '>':
                    tape.Add(0);
                    pointer++;
                    break;
        
                case '<':
                    if (pointer == 0)
                        throw new InvalidOperationException("The Tape cannot go below zero");
                    pointer--;
                    break;
        
                case '+':
                    tape[pointer]++;
                    break;
        
                case '-':
                    if (tape[pointer] == 0)
                        throw new InvalidOperationException("The value of the Tape cannot go below zero");
                    tape[pointer]--;
                    break;
        
                case '|':
                    Console.Write(Convert.ToChar(tape[pointer] + 32));
                    break;
        
                case '*':
                    var input = Console.ReadLine();
                    if (input.Length != 1) 
                        throw new InvalidOperationException("The input must be of length 1");
                    tape[pointer] += (int)input[0];
                    break;
        
                // case '(' & pointer == 0:
        
            }
            count++;
        }
    }
}