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
    Animator animator { get; }
    int RequiredNumberOfReps { get; } // Number of Reps needed to complete the exercise.
    int RepsCompleted { get; set; }// Reps completed during set
    float MinimumTime { get; }
    float MaximumTime { get; }
    float LiftTimer { get; set; }

    ILiftAnimationStrategy animationStrategy { get; set; }



    void StartExercise(); // UI, Tips, Sounds ETC
    string QualityOfLift { get; set; }






    void DoExercise();  // Actual Game Logic



    bool IsSuccessful(); // Determines if lift continues

    void EndExercise();

    void DetermineLiftAnimationStrategy();
    
    void Initialize();

    void ChangeState(ILiftState newState);
    void AddObserver(ILiftObserver observer);
    void RemoveObserver(ILiftObserver observer);

}


