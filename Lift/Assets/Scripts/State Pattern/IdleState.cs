using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ILiftState
{
   public void EnterState(IExerciseMiniGame exercise)
   {
        Debug.Log("Idle State Entered");
        
   }
   public void UpdateState(IExerciseMiniGame exercise)
   {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            exercise.animator.Play("SquatDescent");
            Debug.Log("Player started Squat");
            Debug.Log($"Min {exercise.MinimumTime}, Max {exercise.MaximumTime}");

            exercise.animator.SetInteger("SquatAnimationType", -1); // Reset Squat Animation Type each rep;
            exercise.animator.SetBool("IsSquattingDescent", true);
            exercise.LiftTimer = 0f;
            exercise.ChangeState(new DescendingState());



        }
    }
   public void ExitState(IExerciseMiniGame exercise)
   {
        Debug.Log("Leaving Idle... Squat Started.");
   }
}

