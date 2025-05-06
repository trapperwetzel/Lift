using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatLockoutState : ILiftState {
    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log($"Entering Lockout State for {exercise.LiftType}!");
    }

    public void UpdateState(IExerciseMiniGame exercise)
    {
        //command.Execute();
    }

    public void ExitState(IExerciseMiniGame exercise)
    {
        Debug.Log($"Exiting Lockout State for {exercise.LiftType}!");
    }
}