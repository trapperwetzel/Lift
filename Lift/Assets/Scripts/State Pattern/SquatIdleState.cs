using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatIdleState : ILiftState {
    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log($"Entering Idle State for {exercise.LiftType}!");
    }

    public void UpdateState(IExerciseMiniGame exercise)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player initiated the lift");
            exercise.animator.Play("SquatDescent");
            exercise.animator.SetInteger("SquatAnimationType", -1);
            exercise.animator.SetBool("IsSquattingDescent", true);

            exercise.LiftTimer = 0f;
            exercise.ChangeState(new SquatDescendingState());
        }
    }

    public void ExitState(IExerciseMiniGame exercise)
    {
        Debug.Log($"Exiting Idle State for {exercise.LiftType}!");
    }
}


