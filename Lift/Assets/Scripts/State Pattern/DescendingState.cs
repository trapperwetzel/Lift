using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescendingState : ILiftState
{
    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log("Entering Descending State!");
    }
    public void UpdateState(IExerciseMiniGame exercise)
    {
        if (Input.GetKey(KeyCode.Space))
        {

            Debug.Log(exercise.LiftTimer);
            exercise.animator.SetBool("PassedDescent", false);
            exercise.LiftTimer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Squat Released");
            Debug.Log($"Squat Time Released: {exercise.LiftTimer}");
            exercise.animator.SetBool("IsSquattingDescent", false);
            exercise.ChangeState(new ConcentricState());
        }
    }


    public void ExitState(IExerciseMiniGame exercise)
    {
        Debug.Log("Exiting Descending State!");
    }
}
