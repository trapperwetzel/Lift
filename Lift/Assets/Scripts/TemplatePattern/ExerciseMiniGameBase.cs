using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class ExerciseMiniGameBase : IExerciseMiniGame {

    // Required by IExerciseMiniGame
    public abstract ExerciseType LiftType { get; } // ex: Squat, Bench

    public Animator animator { get; protected set; }
    public ILiftAnimationStrategy animationStrategy { get; set; }

    public int RequiredNumberOfReps { get; set; }
    public int RepsCompleted { get;  set; }

    public float MinimumTime { get;  set; }
    public float MaximumTime { get;  set; }
    public float LiftTimer { get; set; }

    public string QualityOfLift { get; set; }

    // Step 1: Common fields from IExerciseMiniGame

    private readonly List<ILiftObserver> observers = new();
    public void AddObserver(ILiftObserver observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void RemoveObserver(ILiftObserver observer)
    {
        if (observers.Contains(observer))
            observers.Remove(observer);
    }

    public void StartExercise()
    {
        RepsCompleted = 0;
        LiftTimer = 0f;

        Debug.Log($"[{LiftType}] Starting lift.");
        OnStart();  // Subclass-specific setup

        NotifyLiftStarted();
    }
    

    

    public void DoExercise()
    {
        HandleInput(); // Let the lift (Squat, etc.) process input

        LiftTimer += Time.deltaTime;

        if (IsSuccessful())
        {
            RepsCompleted++;
            NotifyRepCompleted();

            if (RepsCompleted >= RequiredNumberOfReps)
            {
                EndExercise();
            }
        }
    }

    public void EndExercise()
    {
        Debug.Log($"[{LiftType}] Set complete. Total reps: {RepsCompleted}");

        OnFinish();             // Subclass can override this
        NotifySetCompleted();
    }

    private void NotifyLiftStarted()
    {
        foreach (var observer in observers)
            observer.OnLiftStarted();
    }
    private void NotifyRepCompleted()
    {
        foreach (var observer in observers)
            observer.OnLiftCompleted();
    }
    private void NotifySetCompleted()
    {
        foreach (var observer in observers)
            observer.OnSetCompleted();
    }

    protected virtual void OnFinish() { }

    protected abstract void HandleInput();
    public abstract bool IsSuccessful();
    protected virtual void OnStart() { }
    public abstract void DetermineLiftAnimationStrategy();
    public virtual void Initialize() { }

    public abstract void ChangeState(ILiftState newState);


}
