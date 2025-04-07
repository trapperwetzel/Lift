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
    [SerializeField] private float MinimumTime = 2.1f;
    [SerializeField] private float MaximumTime = 5f;
    [SerializeField] public int RequiredNumberOfReps { get; set; }

    [SerializeField] private TextMeshProUGUI RepsCompletedText;
    [SerializeField] private TextMeshProUGUI QualityOfRepText;
    [SerializeField] private TextMeshProUGUI RequiredNumberOfRepsText;

    public int RepsCompleted { get; set; }
    public string QualityOfLift { get; set; }
    private bool IsSquatting = false;
    private float SquatTimer = 0f;
    private ISquatAnimationStrategy animationStrategy;

    public SquatMiniGame(Animator animator, float minimumTime, float maximumTime, int aRequiredNumberOfReps)
    {
        this.animator = animator;
        MinimumTime = minimumTime;
        MaximumTime = maximumTime;
        RequiredNumberOfReps = aRequiredNumberOfReps;
        
    } 

    

    public void StartExercise()
    {
        // Observer Pattern ** In the future ** Notify Observers
        Debug.Log("Exercise Started");
        NotifySquatStarted();

    }
    public void DoExercise()
    {
         
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("SquatDescent");
            Debug.Log("Player started Squat");
            Debug.Log($"Min {MinimumTime}, Max {MaximumTime}");
            IsSquatting = true;
            animator.SetInteger("SquatAnimationType", - 1); // Reset Squat Animation Type each rep;
            animator.SetBool("IsSquattingDescent",true);
            SquatTimer = 0f;

             

        }
        if(Input.GetKey(KeyCode.Space) && IsSquatting == true)
        {

            Debug.Log(SquatTimer);
            animator.SetBool("PassedDescent", false);
            SquatTimer += Time.deltaTime;
            
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Squat Released");
            Debug.Log($"Squat Time Released: {SquatTimer}");
            animator.SetBool("IsSquattingDescent", false);
            if (IsSuccessful())
            {
                
                Debug.Log("Squat passed!");
                Debug.Log($"Squat Time Released: {SquatTimer}");
                Debug.Log($"Min {MinimumTime}, Max {MaximumTime}");


                animationStrategy = DetermineSquatAnimationStrategy();
                animationStrategy.PlayAnimation(animator,this);

                RepsCompleted++;
                NotifySquatCompleted();
            }
            else
            {
                animator.SetBool("PassedDescent", false);
            }
            EndExercise();
        }
        


    }
    public bool IsSuccessful()
    {
        return SquatTimer > MinimumTime && SquatTimer < MaximumTime;
        
    
    }

    
    public void EndExercise()
    {
        if(RepsCompleted == RequiredNumberOfReps)
        {
            Debug.Log("Set Completed!");
            animator.Play("Idle");
            NotifySetCompleted();
        }
    }



    

    public void Initialize() { }

    private ISquatAnimationStrategy DetermineSquatAnimationStrategy()
    {
        float range = MaximumTime - MinimumTime;
        float segment = range / 3f;
        float fastThreshold = MinimumTime + segment;
        float averageThreshold = MinimumTime + (2 * segment);
        Debug.Log($"Good Squat Threshold: {fastThreshold}");
        Debug.Log($"Average Threshold: {averageThreshold}");
        if (SquatTimer <= fastThreshold)
        {
            return new GoodSquatAnimationStrategy();
            
        }
        else if(SquatTimer <= averageThreshold)
        {
            return new AverageSquatAnimationStrategy();
            
        }
        else
        {
            return new SlowSquatAnimationStrategy();
           
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
