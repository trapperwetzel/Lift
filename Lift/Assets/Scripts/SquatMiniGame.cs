using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SquatMiniGame : MonoBehaviour, IExerciseMiniGame {
    
    public Animator animator;
    // Serialized Fields for required Descent time (min and max time allowed)
    [SerializeField] private float MinimumTime;
    [SerializeField] private float MaximumTime;
    bool IsSquatting = false;
    float squatTimer = 0f;
    public int RepsCompleted { get; private set; }

    public TextMeshProUGUI repText;

    

    

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void Update()
    {
        DoExercise();
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
            if (IsSuccessful(squatTimer))
            {
                Debug.Log("Squat passed!");
                Debug.Log($"Squat Time Released: {squatTimer}");
                Debug.Log($"Min {MinimumTime}, Max {MaximumTime}");
                animator.SetBool("PassedDescent", true);
            }
            else
            {
                animator.SetBool("PassedDescent", false);
            }

        }
        


    }
    public bool IsSuccessful(float squatTime)
    {
        if(squatTime > MinimumTime && squatTime < MaximumTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    
    }

    
    public void EndExercise()
    {

    }



    public void UpdateText()
    {
        repText.text = "Reps Completed: " + RepsCompleted;

    }


}
