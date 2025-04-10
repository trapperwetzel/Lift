using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageSquatAnimationStrategy : ILiftAnimationStrategy
{
    public void PlayAnimation(Animator animator, IExerciseMiniGame aMiniGame)
    {
        animator.SetInteger("SquatAnimationType", 2);
        aMiniGame.QualityOfLift = "Average";
        Debug.Log("Average Squat");
    }
}
