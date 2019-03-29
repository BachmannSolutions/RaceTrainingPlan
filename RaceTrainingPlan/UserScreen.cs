using System;

namespace RaceTrainingPlan
{
    class UserScreen
    {
        // Welcome screen
        internal static void WelcomeScreen()
        {
            Console.WriteLine( "--------------------------------------------------" );
            Console.WriteLine( "    Welcome to your 12-week Race Training Plan    " );
            Console.WriteLine( "--------------------------------------------------" );
        }

        // Prompts the user to provide a value.
        internal static int Prompt( string message, int pLowNum, int pHighNum )
        {
            bool ExitFlag = false;
            int choice = 0;

            while( ExitFlag == false )
            {
                Console.Write( message );
                string UDInput = Console.ReadLine();
                bool valid = true;

                bool canParse = int.TryParse(UDInput, out choice);
                valid = canParse && choice >= pLowNum && choice <= pHighNum;

                if( !valid )
                {
                    Console.WriteLine( "Please enter a number related to your workout plan" );
                }
                else
                    ExitFlag = true;
            }
            return choice;
        }
        // Prompts the user to provide a value.
        internal static string Prompt( string message )
        {
            Console.Write( message );
            string UDInput = Console.ReadLine();

            return UDInput;
        }

        // Prompts the user to press button to return to main menu.
        internal static void ClosingCase()
        {
            Console.WriteLine();
            Console.WriteLine( "Press any button to return to the main menu" );
            Console.ReadLine();
            Console.Clear();
        }

        // Prompts the user to select or y/n.
        static public bool Continue( string question )
        {
            bool done = false;
            Console.Write( question );
            while( true )
            {
                string answer = Console.ReadLine();
                if( answer != null && answer == "n" )
                {
                    done = true;
                    break;
                }
                else if( answer != null && answer == "y" )
                {
                    done = false;
                    break;
                }
                else
                {
                    Console.Write( "Only 'y' or 'n' are allowed. " + question );
                }
            }
            return done;
        }
    }
}