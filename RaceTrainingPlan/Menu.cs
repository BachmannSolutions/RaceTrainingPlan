using System;

namespace RaceTrainingPlan
{
    // Application menu options.
    internal class Menu
    {
        static string[] _options = new string[]
        {
            "View Full Race Training Plan",
            "Edit Workout",
            "View Edited Workout",
            "Quit"
        };

        // Display of menu options.
        static void Display()
        {
            for( int i = 0; i < _options.Length; i++ )
            {
                Console.WriteLine( $"{i + 1}) {_options[i]}" );
            }
        }

        // Displays the application menu and prompts the user for selection.
        internal static int Prompt()
        {
            Console.WriteLine( "--------------------------------------------------" );
            Console.WriteLine( "            Select One of the Following           " );
            Console.WriteLine( "--------------------------------------------------" );

            Display();
            int option = 0;

                option = UserScreen.Prompt( "Please select an option (1-" + (_options.Length.ToString()) + "): ", 
                    (int)1 , (int)4 );

            return option;
        }
    }
}
