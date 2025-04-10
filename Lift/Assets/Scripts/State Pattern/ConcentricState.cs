using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcentricState : ILiftState
{
    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log("Entering Concentric State!");
    }
    public void UpdateState(IExerciseMiniGame exercise)
    {
        if (exercise.IsSuccessful())
        {
            Debug.Log("REPS COMPLETED: " + exercise.RepsCompleted);
            
            
            Debug.Log("Squat passed!");
            Debug.Log($"Squat Time Released: {exercise.LiftTimer}");
            Debug.Log($"Min {exercise.MinimumTime}, Max {exercise.MaximumTime}");


            exercise.DetermineLiftAnimationStrategy();
            exercise.animationStrategy.PlayAnimation(exercise.animator,exercise);

            
            
        }
        else
        {
            exercise.animator.SetBool("PassedDescent", false);
        }
        
        exercise.ChangeState(new IdleState());
    }
    public void ExitState(IExerciseMiniGame exercise)
    {
        Debug.Log("Exiting Concentric State!");
    }
}
