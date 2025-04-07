using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExerciseMiniGameFactory 
{
    public IExerciseMiniGame CreateMiniGame(ExerciseType type, Animator animator, float minTime, float maxTime, int requiredReps,TextMeshProUGUI repText)
    {
        switch (type)
        {
            case ExerciseType.Squat:
            return new SquatMiniGame(animator, minTime, maxTime, requiredReps,repText);
            case ExerciseType.Bench:
            return new BenchMiniGame(animator, minTime, maxTime, requiredReps, repText);
            case ExerciseType.Deadlift:
            return new DeadliftMiniGame(animator, minTime, maxTime, requiredReps, repText);
            default:
            throw new System.ArgumentException("Invalid exercise type");
        }
    }
    
   
}
