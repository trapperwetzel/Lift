using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SquatMiniGame : IExerciseMiniGame {
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

    public ExerciseType LiftType => ExerciseType.Squat;
    public Animator animator { get; set; }

    [SerializeField] public float MinimumTime { get; set; }
    [SerializeField] public float MaximumTime { get; set; }
    [SerializeField] public int RequiredNumberOfReps { get; set; }
    [SerializeField] private TextMeshProUGUI RepsCompletedText;
    [SerializeField] private TextMeshProUGUI QualityOfRepText;
    [SerializeField] private TextMeshProUGUI RequiredNumberOfRepsText;

    public int RepsCompleted { get; set; }
    public string QualityOfLift { get; set; }
    private LiftStateMachine stateMachine;

    public float LiftTimer { get; set; }
    public ILiftAnimationStrategy animationStrategy { get; set; }

    public SquatMiniGame(Animator animator, float minimumTime, float maximumTime, int aRequiredNumberOfReps)
    {
        this.animator = animator;
        MinimumTime = minimumTime;
        MaximumTime = maximumTime;
        RepsCompleted = 0;
        RequiredNumberOfReps = aRequiredNumberOfReps;
    }

    public void StartExercise()
    {
        Debug.Log("Exercise Started");
        stateMachine = new LiftStateMachine(this, new SquatIdleState());
        NotifySquatStarted();
    }

    public void DoExercise()
    {
        if (stateMachine != null)
        {
            stateMachine.Update();
        }
    }

    public void EndExercise()
    {
        if (RepsCompleted == RequiredNumberOfReps && !hasNotifiedSetCompleted)
        {
            Debug.Log("Set Completed!");
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
            NotifySquatCompleted();
            return true;
        }
        else
        {
            NotifyLiftFailed();
            return false;
        }
    }

    public void Initialize() { }

    public void ChangeState(ILiftState newState)
    {
        stateMachine?.ChangeState(newState);
    }

    public void DetermineLiftAnimationStrategy()
    {
        float range = MaximumTime - MinimumTime;
        float segment = range / 3f;
        float fastThreshold = MinimumTime + segment;
        float averageThreshold = MinimumTime + (2 * segment);
        Debug.Log($"Good Squat Threshold: {fastThreshold}");
        Debug.Log($"Average Threshold: {averageThreshold}");
        if (LiftTimer <= fastThreshold)
        {
            this.animationStrategy = new GoodSquatAnimationStrategy();
        }
        else if (LiftTimer <= averageThreshold)
        {
            this.animationStrategy = new AverageSquatAnimationStrategy();
        }
        else
        {
            this.animationStrategy = new SlowSquatAnimationStrategy();
        }
    }

    private void NotifySquatStarted()
    {
        foreach (var obs in liftobservers)
        {
            obs.OnLiftStarted();
        }
    }

    private void NotifySquatCompleted()
    {
        foreach (var obs in liftobservers)
        {
            obs.OnLiftCompleted();
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

    public void IssuePressCommand() { }

    public bool PressCommand { get; set; }

    public void Reset()
    {
        RepsCompleted = 0;
        LiftTimer = 0f;
        QualityOfLift = "";
        stateMachine = null;
        animationStrategy = null;
        hasNotifiedSetCompleted = false; // Reset the flag
        if (RepsCompletedText != null)
        {
            RepsCompletedText.text = "Reps: 0";
        }
        if (QualityOfRepText != null)
        {
            QualityOfRepText.text = "";
        }
        if (RequiredNumberOfRepsText != null)
        {
            RequiredNumberOfRepsText.text = $"Required Reps: {RequiredNumberOfReps}";
        }
        Debug.Log("[SQUAT] Game reset.");
    }
}