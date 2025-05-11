using UnityEngine;
public class GoodBenchAnimationStrategy : ILiftAnimationStrategy {
    public void PlayAnimation(Animator animator, IExerciseMiniGame aMiniGame)
    {
        // Play the animation for the good bench press
        animator.SetTrigger("GoodBenchPress");
        // You can add more logic here if needed
    }
}