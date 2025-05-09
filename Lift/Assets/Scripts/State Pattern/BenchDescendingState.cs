using UnityEngine;

// 2.Hold State: bar is on chest, wait for "LIFT!" cue, watch for early lift
public class BenchDescendingState : ILiftState {
    //private float cueDelay = 1.0f;  // time to wait before giving the LIFT cue (could randomize if desired)
    //private bool cueShown = false;

    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log(" Bar is on chest. Awaiting 'LIFT' cue.");
        
    }

    public void UpdateState(IExerciseMiniGame exercise)
    {
        // Check for premature lift attempt (player pressing too early, before cue)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            // Player attempted to press up before cue was given
            Debug.Log("Lift attempted too early! Rep failed.");
            // Play a failed lift animation or feedback (no movement because bar is held down)
            
            exercise.ChangeState(new BenchIdleState());
            return;
        }

        
    }

    public void ExitState(IExerciseMiniGame exercise)
    {
        // Nothing special on exit, possibly reset any hold animations
    }
}