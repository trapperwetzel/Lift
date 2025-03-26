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

    [SerializeField] private CoolDown cooldown;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
            
    }

    public void Update()
    {
        DoSquat();
    }

    // Squat/Lift animation (testing for now) 

    public void DoSquat()
    {
        if (cooldown.IsCoolingDown) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar pressed");
            animator.SetTrigger("DoSquat");
            cooldown.StartCoolDown();
            Reps++;
            UpdateText();

            
        }

    }
    private void UpdateText()
    {
        repText.text = "Reps Completed: " + Reps;
    }

}

[System.Serializable]
public class CoolDown {
    [SerializeField] private float cooldownTime;
    private float _nextMovementTime;

    public bool IsCoolingDown => Time.time < _nextMovementTime;

    public void StartCoolDown() => _nextMovementTime = Time.time + cooldownTime;


}