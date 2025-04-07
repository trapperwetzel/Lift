using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageSquatAnimationStrategy : ISquatAnimationStrategy
{
    public void PlayAnimation(Animator animator, SquatMiniGame aSquatMiniGame)
    {
        animator.SetInteger("SquatAnimationType", 2);
        aSquatMiniGame.QualityOfLift = "Average";
        Debug.Log("Average Squat");
    }
}
