using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftStateMachine {
    private ILiftState currentState;
    private IExerciseMiniGame exercise;

    public LiftStateMachine(IExerciseMiniGame exercise, ILiftState initialState)
    {
        this.exercise = exercise;
        ChangeState(initialState);
    }

    public void ChangeState(ILiftState newState)
    {
        currentState?.ExitState(exercise);
        currentState = newState;
        currentState?.EnterState(exercise);
    }

    public void Update()
    {
        currentState?.UpdateState(exercise);
    }
}