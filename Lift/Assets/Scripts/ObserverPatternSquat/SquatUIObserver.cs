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
   // public IExerciseMiniGame exerciseMiniGame { get; set; }



    
    public void OnLiftStarted()
    {
        SquatTitle.text = "Barbell Back Squat";
        var miniGame = ExerciseMiniGameManager.Instance.CurrentMiniGame;
        if (miniGame != null)
        {
            RepsLeftText.text = $"Total Reps to Complete: {miniGame.RequiredNumberOfReps} reps";
        }
        


    }

    public void OnLiftCompleted()
    {
        var miniGame = ExerciseMiniGameManager.Instance.CurrentMiniGame;
        if (miniGame != null)
        {
            Debug.Log($"Mini-Game Type: {miniGame.LiftType}, Reps: {miniGame.RepsCompleted}");
            QualityOfRepText.text = $"Squat Quality: {miniGame.QualityOfLift} Squat";
            SquatFeedBack.text = $"Completed Reps: {miniGame.RepsCompleted}";
            int RepsLeft = miniGame.RequiredNumberOfReps - miniGame.RepsCompleted;
            RepsLeftText.text = $"Reps remaining: {RepsLeft}";
            StartCoroutine(RemoveQualityTextAfterDelay(1f));
        }
    }

    public void OnSetCompleted()
    {
        SquatFeedBack.text = "Set Completed! Great Work!";
        if(ExerciseMiniGameManager.Instance != null)
        {
            ExerciseMiniGameManager.Instance.startButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("ExerciseMiniGameManager instance is null.");
        }
    }

    private IEnumerator RemoveQualityTextAfterDelay(float delay)
    {
        // Wait the specified amount of time
        yield return new WaitForSeconds(delay);

        // Clear out the text
        QualityOfRepText.text = "";
    }

}

    

    


