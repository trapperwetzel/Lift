using UnityEngine;


public class BenchDescendingState : ILiftState {
    

    public void EnterState(IExerciseMiniGame exercise)
    {
        Debug.Log("Descendingstate");
        Debug.Log(exercise.LiftTimer);
        exercise.LiftTimer += Time.deltaTime;
    }

    public void UpdateState(IExerciseMiniGame exercise)
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Bench press descent started.");
            
            exercise.LiftTimer += Time.deltaTime;
            Debug.Log(exercise.LiftTimer);
        }
        
        
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (exercise.IsSuccessful())
            {
                Debug.Log("Update Called in BenchDescendingState!");
                Debug.Log($"Bench Ascend started at {exercise.LiftTimer}");
                exercise.animator.Play("BenchAscend");
                exercise.ChangeState(new BenchAscendingState());
            }
            else
            {
                Debug.Log("Failed!");
            }

                
        }

        
    }

    public void ExitState(IExerciseMiniGame exercise)
    {
        Debug.Log("Exiting Descent state!");
        
    }
}