using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSquatAnimationStrategy : ISquatAnimationStrategy
{
    public void PlayAnimation(Animator animator, SquatMiniGame aSquatMiniGame)
    {
        animator.SetInteger("SquatAnimationType", 1);
        aSquatMiniGame.QualityOfLift = "Good";
        Debug.Log("Good Squat Achieved!");
    }
}
