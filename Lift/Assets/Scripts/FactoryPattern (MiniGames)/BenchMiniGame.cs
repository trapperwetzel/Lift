using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BenchMiniGame : IExerciseMiniGame {
    private readonly List<ILiftObserver> liftobservers = new List<ILiftObserver>();
    private bool hasNotifiedSetCompleted = false; // Add flag to prevent multiple notifications

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

    public ExerciseType LiftType => ExerciseType.Bench;
    public Animator animator { get; set; }

    [SerializeField] public float MinimumTime { get; set; }
    [SerializeField] public float MaximumTime { get; set; }
    [SerializeField] public int RequiredNumberOfReps { get; set; }
    [SerializeField] private TextMeshProUGUI pressComandText;

    public int RepsCompleted { get; set; }
    public string QualityOfLift { get; set; }

    private LiftStateMachine stateMachine;
    public float LiftTimer { get; set; }
    public bool PressCommand { get; set; }
    ILiftAnimationStrategy IExerciseMiniGame.animationStrategy { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public BenchMiniGame(Animator animator, float minimumTime, float maximumTime, int requiredReps)
    {
        this.animator = animator;
        this.MinimumTime = minimumTime;
        this.MaximumTime = maximumTime;
        this.RequiredNumberOfReps = requiredReps;
        this.RepsCompleted = 0;
    }

    public void StartExercise()
    {
        Debug.Log("[BENCH] OnStart called.");
        stateMachine = new LiftStateMachine(this, new BenchIdleState());
        NotifyBenchStarted();
    }

    public void DoExercise()
    {
        if (stateMachine != null)
        {
            stateMachine.Update();
            IssuePressCommand();
        }
    }

    public void EndExercise()
    {
        if (RepsCompleted >= RequiredNumberOfReps && !hasNotifiedSetCompleted)
        {
            NotifySetCompleted();
            hasNotifiedSetCompleted = true; // Prevent multiple notifications
            Reset();
        }
    }

    public bool IsSuccessful()
    {
        if (LiftTimer > MinimumTime && LiftTimer < MaximumTime)
        {
            RepsCompleted++;
            NotifyBenchCompleted();
            return true;
        }
        else
        {
            NotifyLiftFailed();
            return false;
        }
    }

    public void IssuePressCommand()
    {
        if (LiftTimer > 3.2f)
        {
            PressCommand = true;
            NotifyCommandGiven();
        }
    }

    public void ChangeState(ILiftState newState)
    {
        stateMachine?.ChangeState(newState);
    }

    private void NotifyBenchStarted()
    {
        foreach (var obs in liftobservers)
        {
            obs.OnLiftStarted();
        }
    }

    private void NotifyBenchCompleted()
    {
        foreach (var obs in liftobservers)
        {
            obs.OnLiftCompleted();
        }
    }

    private void NotifyCommandGiven()
    {
        foreach (var obs in liftobservers)
        {
            obs.OnCommandIssued();
        }
    }

    private void NotifyLiftFailed()
    {
        foreach (var obs in liftobservers)
        {
            obs.OnLiftFailed();
        }
    }

    private void NotifySetCompleted()
    {
        foreach (var obs in liftobservers)
        {
            obs.OnSetCompleted();
        }
    }

    public void Initialize() { }

    void IExerciseMiniGame.DetermineLiftAnimationStrategy()
    {
        //throw new System.NotImplementedException();
    }

    public void Reset()
    {
        RepsCompleted = 0;
        LiftTimer = 0f;
        PressCommand = false;
        QualityOfLift = "";
        stateMachine = null;
        hasNotifiedSetCompleted = false; // Reset the flag
        if (pressComandText != null)
        {
            pressComandText.text = "";
        }
        Debug.Log("[BENCH] Game reset.");
    }
}




