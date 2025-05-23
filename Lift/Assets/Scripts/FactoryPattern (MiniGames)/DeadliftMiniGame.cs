using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeadliftMiniGame : IExerciseMiniGame
{
    public Animator animator {get; set;}
    public ExerciseType LiftType => ExerciseType.Deadlift;
    public bool PressCommand { get; set; }
    public int RequiredNumberOfReps { get; set; }
    public int RepsCompleted { get; set; }
    public float LiftTimer { get; set; }
    public float MinimumTime { get; set; }
    public float MaximumTime { get; set; }
    public string QualityOfLift { get; set; }
    public ILiftAnimationStrategy animationStrategy { get; set; }
    public DeadliftMiniGame(Animator animator, float minimumTime, float maximumTime, int aRequiredNumberOfReps)
    {
        this.animator = animator;
        MinimumTime = minimumTime;
        MaximumTime = maximumTime;
        RequiredNumberOfReps = aRequiredNumberOfReps;
        
    }

    public void IssuePressCommand() { }
    public void StartExercise()
    {

    }
    public void Reset()
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
    public void GivenPressCommand()
    {
    }
    
    private readonly List<ILiftObserver> liftobservers = new List<ILiftObserver>();
    public void ChangeState(ILiftState newState)
    {

    }
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



    public void DetermineLiftAnimationStrategy()
    {

    }
}
