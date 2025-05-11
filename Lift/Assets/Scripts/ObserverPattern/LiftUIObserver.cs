using System.Collections;
using TMPro;
using UnityEngine;

public class LiftUIObserver : MonoBehaviour, ILiftObserver {
    [SerializeField] private TextMeshProUGUI repsCompletedText;
    [SerializeField] private TextMeshProUGUI repsRemainingText;
    [SerializeField] private TextMeshProUGUI liftCommandText;
    [SerializeField] private TextMeshProUGUI statsDisplayText;
    private GameFacade gameFacade;
    private GameStatsLoader statsLoader;

    public void SetGameFacade(GameFacade facade, string statsFilePath)
    {
        this.gameFacade = facade;
        this.statsLoader = new GameStatsLoader(statsFilePath);
    }

    public void OnLiftStarted()
    {
        var game = ExerciseMiniGameManager.Instance.CurrentMiniGame;
        if (game == null) return;

        repsCompletedText.text = "Reps: 0";
        repsRemainingText.text = $"Remaining: {game.RequiredNumberOfReps}";
        liftCommandText.text = "";
        if (statsDisplayText != null)
        {
            statsDisplayText.text = "";
        }
    }

    public void OnCommandIssued()
    {
        liftCommandText.text = "PRESS!";
        StartCoroutine(ClearCommandTextAfterDelay(1f));
    }

    public void OnLiftFailed()
    {
        liftCommandText.text = "TOO SLOW!";
    }

    public void OnLiftCompleted()
    {
        var game = ExerciseMiniGameManager.Instance.CurrentMiniGame;
        if (game == null) return;

        repsCompletedText.text = $"Reps: {game.RepsCompleted}";
        repsRemainingText.text = $"Remaining: {game.RequiredNumberOfReps - game.RepsCompleted}";
    }

    public void OnSetCompleted()
    {
        liftCommandText.text = "Set Complete!";
        Debug.Log("[LiftUIObserver] Logging stats immediately.");
        gameFacade.LogGameStats(); // Log stats immediately before reset
        StartCoroutine(ResetGameAfterDelay(2f));
    }

    private IEnumerator ClearCommandTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        liftCommandText.text = "";
    }

    private IEnumerator ResetGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameFacade != null)
        {
            Debug.Log("[LiftUIObserver] Calling ResetSet on GameFacade.");
            gameFacade.ResetSet();
            DisplayStats();
        }
        else
        {
            Debug.LogWarning("[LiftUIObserver] GameFacade reference is null!");
        }
    }

    private void DisplayStats()
    {
        if (statsDisplayText != null && statsLoader != null)
        {
            string stats = statsLoader.LoadStats();
            statsDisplayText.text = stats;
        }
        else
        {
            Debug.LogWarning("[LiftUIObserver] Stats display text or loader is not assigned!");
        }
    }
}