using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExerciseMiniGameFactory 
{
    public IExerciseMiniGame CreateMiniGame(ExerciseType type, Animator animator, float minTime, float maxTime, int requiredReps)
    {
        switch (type)
        {
            case ExerciseType.Squat:
            return new SquatMiniGame(animator, minTime, maxTime, requiredReps);
            case ExerciseType.Bench:
            return new BenchMiniGame(animator, minTime, maxTime, requiredReps );
            case ExerciseType.Deadlift:
            return new DeadliftMiniGame(animator, minTime, maxTime, requiredReps);
            default:
            throw new System.ArgumentException("Invalid exercise type");
        }
    }
    
   
}
