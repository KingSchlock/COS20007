using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace HelloWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string? name;

            Message[] myMessages = new Message[7];

            Message myMessage0 = new Message("Hello World! From Message Class.");
            Message myMessage1 = new Message("Welcome back!");
            Message myMessage2 = new Message("Great name!");
            Message myMessage3 = new Message("Oh hi!");
            Message myMessage4 = new Message("What a lovely name.");
            Message myMessage5 = new Message("Beautiful name.");
            Message myMessage6 = new Message("What a Silly Name!");

            myMessages[0] = myMessage0;
            myMessages[1] = myMessage1;
            myMessages[2] = myMessage2;
            myMessages[3] = myMessage3;
            myMessages[4] = myMessage4;
            myMessages[5] = myMessage5;
            myMessages[6] = myMessage6;

            myMessages[0].PrintPrompt();

            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine(); 
            name = name?.ToLower();
            
            if (name == "thomas")
            {
                myMessages[1].PrintPrompt();
            }
            else if (name == "max")
            {
                myMessages[2].PrintPrompt();
            }
            else if (name == "lee")
            {
                myMessages[3].PrintPrompt();
            }
            else if (name == "naomi")
            {
                myMessages[4].PrintPrompt();
            }
            else if (name == "rori")
            {
                myMessages[5].PrintPrompt();
            }
            else
            {
                myMessages[6].PrintPrompt();
            }
            Console.ReadLine();
        }
    }
}
