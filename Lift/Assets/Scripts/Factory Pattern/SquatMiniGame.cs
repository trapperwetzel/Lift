using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SquatMiniGame : IExerciseMiniGame {


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

    public ExerciseType LiftType => ExerciseType.Squat;
    public Animator animator { get; set; }

    // Serialized Fields for required Descent time (min and max time allowed)
    [SerializeField] public float MinimumTime { get; set; }
    [SerializeField] public float MaximumTime { get; set; }
    [SerializeField] public int RequiredNumberOfReps { get; set; }
    [SerializeField] private TextMeshProUGUI RepsCompletedText;
    [SerializeField] private TextMeshProUGUI QualityOfRepText;
    [SerializeField] private TextMeshProUGUI RequiredNumberOfRepsText;

    // can move this back to private
    public int RepsCompleted { get; set; }
    public string QualityOfLift { get; set; }
    private ILiftState currentState;
    
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
        ChangeState(new IdleState());
        NotifySquatStarted();

    }
    public void DoExercise()
    {

        if (currentState != null)
        {
            currentState.UpdateState(this);
            EndExercise();
        }

    }
    public bool IsSuccessful()
    {
        if(LiftTimer > MinimumTime && LiftTimer < MaximumTime)
        {
            RepsCompleted++;
            NotifySquatCompleted();
            
            return true;
        }
        else
        {
            return false;
        }
            
        
    
    }

    
    public void EndExercise()
    {
        if(RepsCompleted == RequiredNumberOfReps)
        {
            Debug.Log("Set Completed!");
            NotifySetCompleted();
        }
    }



    

    public void Initialize() { }
    public void ChangeState(ILiftState newState)
    {
        // If the CurrentState is not null, use the CurrentStates ExitState method
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        // Set the current state to the new state that was changed by the UpdateState method 
        currentState = newState;
        currentState.EnterState(this);
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
        else if(LiftTimer <= averageThreshold)
        {
            this.animationStrategy = new AverageSquatAnimationStrategy();
            
        }
        else
        {
            this.animationStrategy = new SlowSquatAnimationStrategy();
           
        }
    }


    // -------------- Observer Notifications --------------
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

    private void NotifySetCompleted()
    {
        foreach (var obs in liftobservers)
        {
            obs.OnSetCompleted();
        }
    }
}
