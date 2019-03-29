using System;
using System.Collections.Generic;
using System.IO;


namespace RaceTrainingPlan
{
    class Program
    {
        static readonly List<TrainingRoutine> _selectedTrainingRoutine = new List<TrainingRoutine>();
        static List<TrainingRoutine> _editedTrainingRoutine = new List<TrainingRoutine>();

        static void Main( string[] args )
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(CurrentDirectory);
            var fileName = Path.Combine(directory.FullName, "TrainingRoutine.csv");
            var fileContents = ReadTrainingRoutine(fileName);

            UserScreen.WelcomeScreen();

            int option = 0;
            while( ( option = Menu.Prompt() ) != 4 )
            {
                switch( option )
                {
                    case 1:
                    DisplayFullRoutine( fileContents );
                    break;

                    case 2:
                    EditSelection();
                    break;

                    case 3:
                    DisplayEditedRoutine();
                    break;
                }
            }
        }

        // Case 1: Displays Full Routine.
        static void DisplayFullRoutine( List<TrainingRoutine> _output )
        {

            Console.Clear();
            Console.WriteLine( "-----------------------------------" );
            Console.WriteLine( "   View Full Race Training Plan    " );
            Console.WriteLine( "-----------------------------------" );
            foreach( var item in _output )
            {
                Console.WriteLine( "Your Week " + item.Week + ", Day " + item.Day + ", Workout is " + item.Workout );
            }

            UserScreen.ClosingCase();
        }

        // Case 2: Prompts user for Week, Day, and Routine and edits routine.
        static void EditSelection()
        {
            Console.Clear();
            Console.WriteLine( "-----------------------------------" );
            Console.WriteLine( "            Edit Workout           " );
            Console.WriteLine( "-----------------------------------" );

            bool done = false;
            do
            {
                int weekSelection = UserScreen.Prompt("Which week do you want to edit? ", 1,12);
                int daySelection = UserScreen.Prompt("Which day do you want to edit? ", 1,7);
                string workoutSelection = UserScreen.Prompt("What workout will you do? ");
                //+"" is the same as converting an INT to a STRING
                //need to compare edite TR to original TR
                _editedTrainingRoutine.Add( new TrainingRoutine { Week = weekSelection+"", Day = daySelection+"", Workout = workoutSelection } );
                done = UserScreen.Continue( "Edit another routine? Press y/n " );

            } while( !done );

            Console.Clear();
        }

        // Case 3: Displays selected Routines.
        static void DisplayEditedRoutine()
        {
            Console.Clear();
            Console.WriteLine( "-----------------------------------" );
            Console.WriteLine( "        Your Edited Workout        " );
            Console.WriteLine( "-----------------------------------" );

            _editedTrainingRoutine.ForEach( ( routine ) => Console.WriteLine( routine ) );

            UserScreen.ClosingCase();
        }

        public static string ReadFile( string FileName )
        {
            using( var reader = new StreamReader( FileName ) )
            {
                return reader.ReadToEnd();
            }
        }

        public static List<TrainingRoutine> ReadTrainingRoutine( string fileName )
        {
            var FullTrainingPlan = new List<TrainingRoutine>();
            using( var reader = new StreamReader( fileName ) )
            {
                string line = "";
                reader.ReadLine();
                while( ( line = reader.ReadLine() ) != null )
                {
                    var trainingRoutine = new TrainingRoutine();
                    string[] values = line.Split(',');

                    trainingRoutine.Week = values[0];

                    trainingRoutine.Day = values[1];

                    trainingRoutine.Workout = values[2];

                    FullTrainingPlan.Add( trainingRoutine );
                }
            }
            return FullTrainingPlan;
        }

        //TODO: how do I get what's in the CSV and prompt the user to edit something, then make it stick in this below
        public static List<TrainingRoutine> WriteTrainingRoutine( string fileName, List<TrainingRoutine> eTRoutine )
        {
            var FullTrainingPlan = new List<TrainingRoutine>();
            foreach( TrainingRoutine TR in eTRoutine )
            {
                //use LINQ find sytnax
                //FullTrainingPlan.find where week and day match, then overwrite workout
                //mylist = mylist.Where( n => n.Id == ID ).Select( n => { n.Property = ""; return n; } ).ToList();
                //mylist = mylist.Select( n => { if( n.Id == ID ) { n.Property = ""; } return n; } ).ToList();

            }



            ///////////////////////////
            //try
            //{
            //    TR.SubmitChanges( ConflictMode.ContinueOnConflict );
            //}

            //catch( ChangeConflictException e )
            //{
            //    Console.WriteLine( e.Message );
            //    foreach( ObjectChangeConflict occ in db.ChangeConflicts )
            //    {
            //        //No database values are merged into current.
            //        occ.Resolve( RefreshMode.KeepCurrentValues );
            //    }
            //}
            ////////////////////////////////////////









            using( var writer = new StreamWriter( fileName ) )
            {
                foreach( TrainingRoutine TR in eTRoutine)
                {
                    writer.WriteLine( TR.Week + "," + TR.Day + "," + TR.Workout );
                }
            }
            return FullTrainingPlan;
        }
    }
}
