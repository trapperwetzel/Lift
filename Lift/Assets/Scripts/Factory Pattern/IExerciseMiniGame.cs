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
    ILiftAnimationStrategy animationStrategy { get; set; }
    int RequiredNumberOfReps { get; set; } // Number of Reps needed to complete the exercise.
    int RepsCompleted { get; set; }// Reps completed during set
    float MinimumTime { get; set; }
    float MaximumTime { get; set; }
    float LiftTimer { get; set; }
    
    string QualityOfLift { get; set; }
    bool IsSuccessful(); // Determines if lift continues

    void DoExercise();  // Actual Game Logic
    void StartExercise(); // UI, Tips, Sounds ETC
    void EndExercise();
    void DetermineLiftAnimationStrategy();
    void Initialize();
    void ChangeState(ILiftState newState);
    void AddObserver(ILiftObserver observer);
    void RemoveObserver(ILiftObserver observer);

}


