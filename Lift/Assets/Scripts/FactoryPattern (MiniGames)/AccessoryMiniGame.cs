using UnityEngine;


public class AccesoryLiftMiniGame : IExerciseMiniGame {
    public ExerciseType LiftType => ExerciseType.Accessory;
    public Animator animator { get; set; }
    public ILiftAnimationStrategy animationStrategy { get; set; }
    public int RequiredNumberOfReps { get; set; }
    public int RepsCompleted { get; set; }
    public float MinimumTime { get; set; }
    public float MaximumTime { get; set; }
    public float LiftTimer { get; set; }
    public string QualityOfLift { get; set; }

    public bool IsSuccessful()
    {
        // ACCESORY LOGIC IS DIFFERENT THEN MAIN LIFT LOGIC
        return RepsCompleted == RequiredNumberOfReps;
    }

    public void StartExercise()
    {
        // Initialize exercise parameters  
        RepsCompleted = 0;
        LiftTimer = 0;
        QualityOfLift = string.Empty;
    }

    public void DoExercise()
    {
          
        RepsCompleted++;
    }

    public void EndExercise()
    {
        // Finalize the exercise  
        QualityOfLift = RepsCompleted >= RequiredNumberOfReps ? "Good" : "Poor";
    }

    public void DetermineLiftAnimationStrategy()
    {
        // Assign an animation strategy based on some condition  
        animationStrategy = new DefaultLiftAnimationStrategy();
    }

    public void Initialize()
    {
        // Initialize the mini-game  
        StartExercise();
    }

    public void ChangeState(ILiftState newState)
    {
        // Change the state of the lift  
        // Implementation depends on the state management logic  
    }

    public void AddObserver(ILiftObserver observer)
    {
        // Add an observer to the lift  
        // Implementation depends on observer pattern logic  
    }

    public void RemoveObserver(ILiftObserver observer)
    {
        // Remove an observer from the lift  
        // Implementation depends on observer pattern logic  
    }
}

// Example implementation of a default animation strategy  
public class DefaultLiftAnimationStrategy : ILiftAnimationStrategy {
    public void PlayAnimation(Animator animator, IExerciseMiniGame aMiniGame)
    {
        // Play default animation  
        animator.SetTrigger("DefaultLift");
    }
}