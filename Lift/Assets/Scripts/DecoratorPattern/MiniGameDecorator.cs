using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameDecorator : IExerciseMiniGame {
    protected IExerciseMiniGame decoratedExercise;

    
    public MiniGameDecorator(IExerciseMiniGame exercise)
    {
        decoratedExercise = exercise;
    }

    // Read-only properties
    public ExerciseType LiftType => decoratedExercise.LiftType;
    public Animator animator => decoratedExercise.animator;
    

    // Properties with getters and setters
    public int RepsCompleted
    {
        get => decoratedExercise.RepsCompleted;
        
    }
    public float LiftTimer
    {
        get => decoratedExercise.LiftTimer;
        set => decoratedExercise.LiftTimer = value;
    }
    public ILiftAnimationStrategy animationStrategy
    {
        get => decoratedExercise.animationStrategy;
        set => decoratedExercise.animationStrategy = value;
    }
    public string QualityOfLift
    {
        get => decoratedExercise.QualityOfLift;
        set => decoratedExercise.QualityOfLift = value;
    }
    int IExerciseMiniGame.RequiredNumberOfReps { get => decoratedExercise.RequiredNumberOfReps; set => decoratedExercise.RequiredNumberOfReps = value; }
    int IExerciseMiniGame.RepsCompleted { get => decoratedExercise.RepsCompleted; set => decoratedExercise.RepsCompleted = value; }
    float IExerciseMiniGame.MinimumTime { get => decoratedExercise.MinimumTime; set => decoratedExercise.MinimumTime = value; }
    float IExerciseMiniGame.MaximumTime { get => decoratedExercise.MaximumTime; set => decoratedExercise.MaximumTime = value; }
    public bool PressCommand { get => decoratedExercise.PressCommand; set => decoratedExercise.PressCommand = value; }

    // Methods
    public virtual void StartExercise() => decoratedExercise.StartExercise();
    public virtual void DoExercise() => decoratedExercise.DoExercise();
    public virtual bool IsSuccessful() => decoratedExercise.IsSuccessful();
    public virtual void EndExercise() => decoratedExercise.EndExercise();
    public virtual void DetermineLiftAnimationStrategy() => decoratedExercise.DetermineLiftAnimationStrategy();
    public virtual void Initialize() => decoratedExercise.Initialize();
    public virtual void IssuePressCommand() => decoratedExercise.IssuePressCommand();
    public virtual void ChangeState(ILiftState newState) => decoratedExercise.ChangeState(newState);
    public virtual void AddObserver(ILiftObserver observer) => decoratedExercise.AddObserver(observer);
    public virtual void RemoveObserver(ILiftObserver observer) => decoratedExercise.RemoveObserver(observer);

    public void Reset()
    {
        decoratedExercise.Reset();
    }
}

public class EasyModeDecorator : MiniGameDecorator {

    public EasyModeDecorator(IExerciseMiniGame exercise) : base(exercise)
    {
        exercise.MinimumTime = 2f;
        exercise.MaximumTime = 7f;
    }

    
}

public class HardModeDecorator : MiniGameDecorator {

    
    public HardModeDecorator(IExerciseMiniGame exercise) : base(exercise)
    {
        if(exercise.LiftType == ExerciseType.Bench)
        {
            exercise.MaximumTime = 4.5f;
        }
        else
        {
            exercise.MaximumTime = 4f;
        }
            
    }
    

    
}

public class StrengthSetDecorator : MiniGameDecorator {

    public StrengthSetDecorator(IExerciseMiniGame exercise) : base(exercise)
    {
        exercise.RequiredNumberOfReps = 3;
    }

     
}

public class BodyBuildingSetDecorator : MiniGameDecorator {
    public BodyBuildingSetDecorator(IExerciseMiniGame exercise) : base(exercise)
    {
        exercise.RequiredNumberOfReps += 10;
    }



}
    


