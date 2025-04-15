using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SquatUIObserver : MonoBehaviour, ILiftObserver
{
    [SerializeField] private TextMeshProUGUI RepsCompletedText;
    [SerializeField] private TextMeshProUGUI QualityOfRepText;
    [SerializeField] private TextMeshProUGUI RepsLeftText;
    [SerializeField] private TextMeshProUGUI SquatFeedBack;
    [SerializeField] private TextMeshProUGUI SquatTitle;
    public IExerciseMiniGame exerciseMiniGame { get; set; }



    
    public void OnLiftStarted()
    {
        SquatTitle.text = "Barbell Back Squat";
        RepsLeftText.text = $"Total Reps to Complete: {exerciseMiniGame.RequiredNumberOfReps} reps";


    }

    public void OnLiftCompleted()
    {
        QualityOfRepText.text = $"Squat Quality: {exerciseMiniGame.QualityOfLift} Squat";
        SquatFeedBack.text = $"Completed Reps: {exerciseMiniGame.RepsCompleted}";

        int RepsLeft = exerciseMiniGame.RequiredNumberOfReps - exerciseMiniGame.RepsCompleted;
        RepsLeftText.text = $"Reps remaining: {RepsLeft}";

        // Start a coroutine that will clear the text after 2 seconds
        StartCoroutine(RemoveQualityTextAfterDelay(1f));
    }

    public void OnSetCompleted()
    {
        SquatFeedBack.text = "Set Completed! Great Work!";

    }

    private IEnumerator RemoveQualityTextAfterDelay(float delay)
    {
        // Wait the specified amount of time
        yield return new WaitForSeconds(delay);

        // Clear out the text
        QualityOfRepText.text = "";
    }

}

    

    


