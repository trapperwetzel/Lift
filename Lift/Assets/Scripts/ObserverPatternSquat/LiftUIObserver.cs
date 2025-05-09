using System.Collections;
using TMPro;
using TinyGiantStudio.Text;
using UnityEngine;

public class LiftUIObserver : MonoBehaviour, ILiftObserver {
    [SerializeField] private Modular3DText liftTitleText;
    [SerializeField] private TextMeshProUGUI repsCompletedText;
    [SerializeField] private TextMeshProUGUI repsRemainingText;
    [SerializeField] private TextMeshProUGUI liftFeedbackText;

    public void OnLiftStarted()
    {
        var game = ExerciseMiniGameManager.Instance.CurrentMiniGame;
        if (game == null) return;

        

        liftTitleText.UpdateText(game.LiftType.ToString().ToUpper());
        repsCompletedText.text = "Reps: 0";
        repsRemainingText.text = $"Remaining: {game.RequiredNumberOfReps}";
        liftFeedbackText.text = "";
    }

    public void OnLiftCompleted()
    {
        var game = ExerciseMiniGameManager.Instance.CurrentMiniGame;
        if (game == null) return;

        repsCompletedText.text = $"Reps: {game.RepsCompleted}";
        repsRemainingText.text = $"Remaining: {game.RequiredNumberOfReps - game.RepsCompleted}";
        liftFeedbackText.text = $"Good {game.LiftType}!";
        StartCoroutine(ClearFeedback());
    }

    public void OnSetCompleted()
    {
        liftFeedbackText.text = "Set Complete!";
        repsRemainingText.text = "No more sets left :)";
        repsCompletedText.text = "Great job! Do another.";
        
        ExerciseMiniGameManager.Instance?.startButton.gameObject.SetActive(true);
    }

    private IEnumerator ClearFeedback()
    {
        yield return new WaitForSeconds(1.5f);
        liftFeedbackText.text = "";
    }
}







