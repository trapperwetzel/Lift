using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SquatMiniGameTest : MonoBehaviour
{
    public Animator animator;
    public int Reps { get; private set; }
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar pressed");
            animator.SetTrigger("DoSquat");
            Reps++;
            UpdateText();


        }
    }

    private void UpdateText()
    {
        repText.text = "Reps Completed: " + Reps;
    }

}
