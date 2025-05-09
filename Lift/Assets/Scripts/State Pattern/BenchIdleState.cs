using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. Idle State: wait for player input to start lowering the bar
public class BenchIdleState : ILiftState
{
    public void EnterState(IExerciseMiniGame exercise)
    {
        //exercise.animator.Play("BenchIdle");
        Debug.Log("Ready to start bench press.");
        
        
    }

    public void UpdateState(IExerciseMiniGame exercise)
    {
        // If player initiates the rep (press Space or W to lower)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Bench press descent started by player.");
            // Play descent animation (lower the bar to chest)
            exercise.animator.Play("BenchPress");
            

            // Transition to Descending state (bar on chest, waiting for cue)
            exercise.ChangeState(new BenchDescendingState());
        }
    }

    public void ExitState(IExerciseMiniGame exercise)
    {
        // (Optional) Code when leaving idle (e.g., lock start button UI, etc.)
        Debug.Log("Leaving BenchIdleState.");
    }
}