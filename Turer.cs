﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Turer
{
  
    public static void Main (string[] args)
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        
        //important variables
        List<int> tape = new List<int>();
        tape.Add(0);
        int pointer = 0;
        

        //Handles Readline and unbalanced parenthesis
        string chararr = "";
        Array.ForEach(File.ReadLines("C:\\Users\\Noah Simcox\\RiderProjects\\TuringLanguage\\TuringLanguage\\code.cerb").ToArray(), x => chararr += x);
        int check = 0;
        Stack<int> opens = new Stack<int>();
        Dictionary<int, int> parenPairs = new Dictionary<int, int>();
        for (int i = 0; i < chararr.Length; i++)
        {
          if (chararr[i] == '(')
          {
              check++;
              opens.Push(i);
          }

          if (chararr[i] == ')')
          { 
              parenPairs.Add(opens.Pop(), i);
              check--; 
            
            if (i + 1 == chararr.Length && check != 0)
            {
              throw new InvalidOperationException("The program has an unbalanced parenthesis");
            }       
          }
        }
          

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

                case '(':
                  if (tape[pointer] != 0)
                    break;
                  count = parenPairs[count] + 1;
                  break;

                case ')':
                  if (tape[pointer] == 0)
                    break;
                  count = parenPairs.FirstOrDefault(x => x.Value == count).Key;
                  break;
            }
            count++;
        }
        time.Stop();
        TimeSpan ts = time.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
        Console.WriteLine("RunTime " + elapsedTime);
    }
}
/*>++++++++(<+++++++++++++>-) h
>+++++++(<+++++++++++++++>-) i
++++++++++(>++++++++++(>++++++++++(>++++++++++(>++++++++++(>++++++++++ (<<<<<<<|>|>>>>>>-) <-)<-)<-)<-)<-)*/