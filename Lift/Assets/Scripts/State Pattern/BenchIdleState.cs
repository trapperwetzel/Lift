using UnityEngine;

public class BenchIdleState : ILiftState {
    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log("Entering BenchIdleState");
        Debug.Log(exercise.LiftTimer);
    }

    public void UpdateState(IExerciseMiniGame exercise)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            exercise.LiftTimer += Time.deltaTime;
            Debug.Log("Bench press descent started.");
            exercise.animator.Play("BenchDescent");
            Debug.Log(exercise.LiftTimer);
            exercise.ChangeState(new BenchDescendingState());
        }
    }

    public void ExitState(IExerciseMiniGame exercise)
    {
        Debug.Log("Exiting BenchIdleState");
    }
}
