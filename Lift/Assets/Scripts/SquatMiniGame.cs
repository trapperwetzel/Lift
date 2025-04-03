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
            Debug.Log("Player initaited Squat");
            IsSquatting = true;
            squatTimer = 0f;
            animator.SetBool("IsSquattingDescent",true);
            
            
            //UpdateText(); // Observer Pattern in the future 
            
        }
        if(Input.GetKey(KeyCode.Space) && IsSquatting == true)
        {

            squatTimer += Time.deltaTime;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Squat Released");
            animator.SetBool("IsSquattingDescent", false);

        }



    }
    public bool IsSuccessful()
    {
        return true;
    
    }

    
    public void EndExercise()
    {

    }



    public void UpdateText()
    {
        repText.text = "Reps Completed: " + RepsCompleted;

    }


}
