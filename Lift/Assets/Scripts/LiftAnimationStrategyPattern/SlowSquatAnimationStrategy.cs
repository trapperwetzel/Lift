using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSquatAnimationStrategy : ILiftAnimationStrategy
{
    public void PlayAnimation(Animator animator, IExerciseMiniGame aMiniGame)
    {
        animator.SetInteger("SquatAnimationType", 3);
        aMiniGame.QualityOfLift = "Slow";

        Debug.Log("Slow Squat");
    }
    
}
