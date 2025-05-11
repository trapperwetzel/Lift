using UnityEngine;

public class GameFacade {
    private readonly ExerciseMiniGameManager manager;
    private readonly LiftUIObserver uiObserver;
    private readonly GameStatsLogger statsLogger;

    public GameFacade(ExerciseMiniGameManager manager, LiftUIObserver uiObserver, GameStatsLogger statsLogger)
    {
        this.manager = manager;
        this.uiObserver = uiObserver;
        this.statsLogger = statsLogger;
    }

    public void StartSet()
    {
        Debug.Log("[GameFacade] Starting set.");
        manager.OnStartButtonClicked();
    }

    public void UpdateSet()
    {
        if (manager.CurrentMiniGame != null)
        {
            manager.CurrentMiniGame.DoExercise();
            manager.CurrentMiniGame.EndExercise();
        }
    }

    public void ResetSet()
    {
        Debug.Log("[GameFacade] Resetting set.");
        manager.ResetGame();
    }

    public void LogGameStats()
    {
        if (manager.CurrentMiniGame != null)
        {
            statsLogger.LogStats(manager.CurrentMiniGame);
        }
        else
        {
            Debug.LogWarning("[GameFacade] No current mini-game to log stats for.");
        }
    }
}