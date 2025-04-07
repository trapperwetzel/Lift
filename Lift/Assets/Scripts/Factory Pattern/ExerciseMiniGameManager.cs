using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExerciseMiniGameManager : MonoBehaviour
{
    private IExerciseMiniGame currentMiniGame;
    private ExerciseMiniGameFactory factory = new ExerciseMiniGameFactory();

    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI repText;
    [SerializeField] private float minTime = 2.1f;
    [SerializeField] private float maxTime = 5f;
    [SerializeField] private int requiredReps = 5;
    [SerializeField] private ExerciseType currentExercise = ExerciseType.Squat;
    [SerializeField] private TMP_Dropdown exerciseDropdown;
    [SerializeField] private Button startButton;

    private void Awake()
    {
        // Ensure the dropdown options match ExerciseType enum
        exerciseDropdown.ClearOptions();
        exerciseDropdown.AddOptions(new List<string> { "Squat", "Bench", "Deadlift" });

        // Add listener to the Start button
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        // Map dropdown value to ExerciseType
        ExerciseType selectedExercise = (ExerciseType)exerciseDropdown.value;
        currentMiniGame = factory.CreateMiniGame(selectedExercise, animator, minTime, maxTime, requiredReps, repText);
        currentMiniGame.Initialize();
        currentMiniGame.StartExercise();
    }

    public void Update()
    {
        if (currentMiniGame != null)
        {
            currentMiniGame.DoExercise();
        }
    }

}
