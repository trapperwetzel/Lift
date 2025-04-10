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
    
     private float minTime = 2.1f;
     private float maxTime = 5f;
     private int RequiredReps = 5;
   // [SerializeField] private ExerciseType currentExercise = ExerciseType.Squat;
    [SerializeField] private TMP_Dropdown exerciseDropdown;
    [SerializeField] private TMP_Dropdown setTypeDropdown;
    [SerializeField] private Button startButton;
    [SerializeField] private SquatUIObserver squatUIObserver;
    // These two above can be added to the observer.
    private void Awake()
    {
        // Populate exercise type dropdown
        exerciseDropdown.ClearOptions();
        exerciseDropdown.AddOptions(new List<string> { "Squat", "Bench", "Deadlift" });

        // Populate set type dropdown
        setTypeDropdown.ClearOptions();
        setTypeDropdown.AddOptions(new List<string> { "Normal", "Easy Mode", "Hard Mode", "Strength Set", "BodyBuilding Set" });

        // Add listener to the Start button
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        // Map dropdown value to ExerciseType
        ExerciseType selectedExercise = (ExerciseType)exerciseDropdown.value;

        // Create the base mini-game
        IExerciseMiniGame baseMiniGame = factory.CreateMiniGame(selectedExercise, animator, minTime, maxTime, RequiredReps);

        // Apply the selected set type decorator
        currentMiniGame = ApplySetTypeDecorator(baseMiniGame, setTypeDropdown.value);

        // Set up observer and start the game
        squatUIObserver.exerciseMiniGame = currentMiniGame;
        currentMiniGame.AddObserver(squatUIObserver);
        currentMiniGame.Initialize();
        startButton.gameObject.SetActive(false); // Disable button instead of destroying it

        currentMiniGame.StartExercise();
    }

    private IExerciseMiniGame ApplySetTypeDecorator(IExerciseMiniGame baseMiniGame, int setTypeIndex)
    {
        switch (setTypeIndex)
        {
            case 0: // Normal (no decorator)
            Debug.Log("Selected Normal Game");
            return baseMiniGame;
            case 1: // Easy Mode
            Debug.Log("Selected Easy Game");
            return new EasyModeDecorator(baseMiniGame); //
            case 2: // Hard Mode
            Debug.Log("Selected Hard Game");
            return new HardModeDecorator(baseMiniGame); // 
            case 3: // Strength Set
            Debug.Log("Selected Strength Set");
            return new StrengthSetDecorator(baseMiniGame); // Sets reps to 3
            case 4: // BodyBuilding Set
            Debug.Log("Selected BodyBuilding Set");
            return new BodyBuildingSetDecorator(baseMiniGame); // Sets reps to 10
            default:
            Debug.LogWarning("Unknown set type selected, using base mini-game.");
            return baseMiniGame;
        }
    }

    public void Update()
    {
        if (currentMiniGame != null)
        {
            currentMiniGame.DoExercise();
        }
    }

}



    

    

    

    