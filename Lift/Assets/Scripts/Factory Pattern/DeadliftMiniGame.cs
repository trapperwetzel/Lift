using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeadliftMiniGame : IExerciseMiniGame
{
    public Animator animator {get; set;}
    public ExerciseType LiftType => ExerciseType.Deadlift;

    public int RequiredNumberOfReps { get; set; }
    public int RepsCompleted { get; set; }
    private float MinimumTime;
    private float MaximumTime;
    public string QualityOfLift { get; set; }
    
    public DeadliftMiniGame(Animator animator, float minimumTime, float maximumTime, int aRequiredNumberOfReps)
    {
        this.animator = animator;
        MinimumTime = minimumTime;
        MaximumTime = maximumTime;
        RequiredNumberOfReps = aRequiredNumberOfReps;
        
    }

    public void StartExercise()
    {

    }
    public void DoExercise()
    {

    }
    public bool IsSuccessful()
    {
        return true;
    }
    public void EndExercise()
    {

    }
    public void Initialize()
    {

    }
    private readonly List<ILiftObserver> liftobservers = new List<ILiftObserver>();
    public void AddObserver(ILiftObserver observer)
    {
        if (!liftobservers.Contains(observer))
        {
            liftobservers.Add(observer);
        }
    }

    public void RemoveObserver(ILiftObserver observer)
    {
        if (liftobservers.Contains(observer))
        {
            liftobservers.Remove(observer);
        }
    }
}
