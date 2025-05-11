using System.Collections.Generic;
using UnityEngine;
public interface WorkoutComponent {
    void Perform();
}

public class ExerciseLeaf : WorkoutComponent {
    private IExerciseMiniGame exercise;

    public ExerciseLeaf(IExerciseMiniGame exercise)
    {
        this.exercise = exercise;
    }

    public void Perform()
    {
        exercise.StartExercise();
    }
}

public class WorkoutDayComposite : WorkoutComponent {
    private List<WorkoutComponent> components = new List<WorkoutComponent>();
    private string dayName;

    public WorkoutDayComposite(string dayName)
    {
        this.dayName = dayName;
    }

    public void Add(WorkoutComponent component)
    {
        components.Add(component);
    }

    public void Perform()
    {
        Debug.Log($"Starting {dayName}...");
        foreach (var component in components)
        {
            component.Perform();
        }
    }
}