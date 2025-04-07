using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExerciseType {
    Squat,
    Bench,
    Deadlift
}
public interface IExerciseMiniGame
{
    ExerciseType LiftType { get; } // read only for debugging/clarity 
    int RequiredNumberOfReps { get; } // Number of Reps needed to complete the exercise.
    int RepsCompleted { get; } // Number of completed Reps
    void StartExercise(); // UI, Tips, Sounds ETC

    void DoExercise();  // Actual Game Logic

    bool IsSuccessful(); // Determines if lift continues

    void EndExercise();

    void Initialize();

}


