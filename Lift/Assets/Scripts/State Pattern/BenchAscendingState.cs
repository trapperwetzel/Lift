using UnityEngine;
// 3. Press/Reaction State: cue given, wait for player's press or timeout
public class BenchAscendingState : ILiftState {
    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log("BenchPressState: Cue given. Waiting for player to press up.");
        // (The LiftTimer is already reset at cue. We start counting reaction time now.)
    }

    public void UpdateState(IExerciseMiniGame exercise)
    {
        

        // Check if player presses the lift in reaction to cue
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            
            exercise.ChangeState(new BenchIdleState());
            return;
        }

        
    }

    public void ExitState(IExerciseMiniGame exercise)
    {
        Debug.Log("Exiting BenchPressState.");
        // On exit, if the press was successful, the base class will handle incrementing reps and notifying observers.
    }
}