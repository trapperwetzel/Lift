using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSquatAnimationStrategy : ISquatAnimationStrategy
{
    public void PlayAnimation(Animator animator, SquatMiniGame aSquatMiniGame)
    {
        animator.SetInteger("SquatAnimationType", 3);
        aSquatMiniGame.QualityOfLift = "Slow";

        Debug.Log("Slow Squat");
    }
    
}
