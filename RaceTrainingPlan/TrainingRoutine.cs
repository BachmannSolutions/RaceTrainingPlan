namespace RaceTrainingPlan
{
    class TrainingRoutine
    {
        // Gets or sets the training week.
        public string Week { get; set; }

        // Gets or sets the training day.
        public string Day { get; set; }

        // Gets or sets the workout.
        public string Workout { get; set; }

        // Returns selected Week, Day, and Workout
        public override string ToString()
        {
            return "Your Week " + Week + ", Day " + Day + ", Workout is " + Workout;
        }
    }
}
