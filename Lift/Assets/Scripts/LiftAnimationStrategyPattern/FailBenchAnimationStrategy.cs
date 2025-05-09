using UnityEngine;
public class FailBenchAnimationStrategy : ILiftAnimationStrategy {
    public void PlayAnimation(Animator animator, IExerciseMiniGame aMiniGame)
    {
        animator.SetInteger("BenchAnimationType", 3);
        aMiniGame.QualityOfLift = "Slow";
        Debug.Log("Slow Bench");
    }
}