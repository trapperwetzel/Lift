using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExerciseType {
    Squat,
    Bench,
    Deadlift,
    Accessory
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
    bool PressCommand { get; set; }
    
    string QualityOfLift { get; set; }
    bool IsSuccessful(); // Determines if lift continues
    void Reset();
    void StartExercise(); // UI, Tips, Sounds ETC
    void DoExercise();  // Actual Game Logic
    void EndExercise();
    void DetermineLiftAnimationStrategy();
    void Initialize();
    void IssuePressCommand(); // Called when the player presses the button to start the lift
    void ChangeState(ILiftState newState);
    void AddObserver(ILiftObserver observer);
    void RemoveObserver(ILiftObserver observer);

}


    
