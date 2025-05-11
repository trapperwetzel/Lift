using UnityEngine;
// 3. Press/Reaction State: cue given, wait for player's press or timeout
public class BenchAscendingState : ILiftState {
    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log("Entering Ascending State!");
        exercise.LiftTimer = 0f; // Reset the timer for the ascending phase.
        
    }

    public void UpdateState(IExerciseMiniGame exercise)
    {


        Debug.Log("yay:)");
        exercise.ChangeState(new BenchIdleState());
        
    }

    public void ExitState(IExerciseMiniGame exercise)
    {
        Debug.Log("Exiting AscendingState.");
        // On exit, if the press was successful, the base class will handle incrementing reps and notifying observers.
    }
}