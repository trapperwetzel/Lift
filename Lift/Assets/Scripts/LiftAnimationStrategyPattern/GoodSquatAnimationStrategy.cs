
using UnityEngine;

public class GoodSquatAnimationStrategy : ILiftAnimationStrategy
{
    public void PlayAnimation(Animator animator, IExerciseMiniGame aMiniGame)
    {
        animator.SetInteger("SquatAnimationType", 1);
        aMiniGame.QualityOfLift = "Good";
        Debug.Log("Good Squat Achieved!");
    }
}
