using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeadliftMiniGame : IExerciseMiniGame
{
    public Animator animator {get; set;}
    public ExerciseType LiftType => ExerciseType.Deadlift;

    public int RequiredNumberOfReps { get; set; }
    public int RepsCompleted { get; set; }
    private float MinimumTime;
    private float MaximumTime;
    [SerializeField] private TextMeshProUGUI repText;
    public DeadliftMiniGame(Animator animator, float minimumTime, float maximumTime, int aRequiredNumberOfReps, TextMeshProUGUI aRepText)
    {
        this.animator = animator;
        MinimumTime = minimumTime;
        MaximumTime = maximumTime;
        RequiredNumberOfReps = aRequiredNumberOfReps;
        repText = aRepText;
    }

    public void StartExercise()
    {

    }
    public void DoExercise()
    {

    }
    public bool IsSuccessful()
    {
        return true;
    }
    public void EndExercise()
    {

    }
    public void Initialize()
    {

    }
}
