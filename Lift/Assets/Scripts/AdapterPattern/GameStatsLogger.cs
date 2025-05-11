using System;
using UnityEngine;

public class GameStatsLogger {
    private readonly ISaveData saveData;

    public GameStatsLogger(ISaveData saveData)
    {
        this.saveData = saveData;
    }

    public void LogStats(IExerciseMiniGame game)
    {
        if (game == null)
        {
            Debug.LogWarning("[GameStatsLogger] No game to log stats for.");
            return;
        }

        // Format as CSV row: Timestamp,Exercise,Reps,LiftTime,Quality
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        
        string stats = $"{timestamp},{game.LiftType},{game.RepsCompleted}";
        saveData.Save(stats);
    }
}