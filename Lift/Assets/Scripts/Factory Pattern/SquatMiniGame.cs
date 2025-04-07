using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SquatMiniGame : IExerciseMiniGame {

    public ExerciseType LiftType => ExerciseType.Squat;
    public Animator animator { get; set; }

    // Serialized Fields for required Descent time (min and max time allowed)
    [SerializeField] private float MinimumTime = 2.1f;
    [SerializeField] private float MaximumTime = 5f;
    [SerializeField] public int RequiredNumberOfReps { get; set; }
    public int RepsCompleted { get; set; }

    [SerializeField] private TextMeshProUGUI repText;


    private bool IsSquatting = false;
    private float squatTimer = 0f;
    

    public SquatMiniGame(Animator animator, float minimumTime, float maximumTime,int aRequiredNumberOfReps, TextMeshProUGUI repsText)
    {
        this.animator = animator;
        MinimumTime = minimumTime;
        MaximumTime = maximumTime;
        RequiredNumberOfReps = aRequiredNumberOfReps;
        repText = repsText;
    } 

    

    public void StartExercise()
    {
        // Observer Pattern ** In the future ** Notify Observers
        Debug.Log("Exercise Started");
       

    }
    public void DoExercise()
    {
         
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("SquatDescent");
            Debug.Log("Player started Squat");
            Debug.Log($"Min {MinimumTime}, Max {MaximumTime}");
            IsSquatting = true;
            animator.SetBool("IsSquattingDescent",true);
            squatTimer = 0f;

            //UpdateText(); // Observer Pattern in the future 

        }
        if(Input.GetKey(KeyCode.Space) && IsSquatting == true)
        {

            Debug.Log(squatTimer);
            animator.SetBool("PassedDescent", false);
            squatTimer += Time.deltaTime;
            
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Squat Released");
            Debug.Log($"Squat Time Released: {squatTimer}");
            animator.SetBool("IsSquattingDescent", false);
            if (IsSuccessful())
            {
                Debug.Log("Squat passed!");
                Debug.Log($"Squat Time Released: {squatTimer}");
                Debug.Log($"Min {MinimumTime}, Max {MaximumTime}");
                animator.SetBool("PassedDescent", true);
                RepsCompleted++;
                UpdateText();
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
        return squatTimer > MinimumTime && squatTimer < MaximumTime;
        
    
    }

    
    public void EndExercise()
    {
        if(RepsCompleted == RequiredNumberOfReps)
        {
            Debug.Log("Set Completed!");
            animator.Play("Idle");
            repText.text = "Set completed! Good Job!";
        }
    }



    public void UpdateText()
    {
        repText.text = "Reps Completed: " + RepsCompleted;

    }

    public void Initialize() { }

}
