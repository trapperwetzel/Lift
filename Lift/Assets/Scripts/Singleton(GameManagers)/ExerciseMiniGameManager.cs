using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class ExerciseMiniGameManager : MonoBehaviour {
    public static ExerciseMiniGameManager Instance { get; private set; }
    private IExerciseMiniGame currentMiniGame;
    public IExerciseMiniGame CurrentMiniGame => currentMiniGame;

    private ExerciseMiniGameFactory factory = new ExerciseMiniGameFactory();
    private GameFacade gameFacade;

    [SerializeField] private Animator animator;
    private float minTime = 2.1f;
    private float maxTime = 5f;
    private int RequiredReps = 5;
    ExerciseType exerciseType;

    [SerializeField] private TMP_Dropdown setTypeDropdown;
    [SerializeField] public Button startButton;
    [SerializeField] private LiftUIObserver liftUIObserver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("Singleton Instance set: " + Instance.name);
        }
        else
        {
            Debug.Log("Destroying duplicate: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "SquatDay")
        {
            exerciseType = ExerciseType.Squat;
        }
        else
        {
            exerciseType = ExerciseType.Bench;
        }

        setTypeDropdown.ClearOptions();
        setTypeDropdown.AddOptions(new List<string> { "Normal", "Easy Mode", "Hard Mode", "Strength Set", "BodyBuilding Set" });
        setTypeDropdown.interactable = true;

        // Save the CSV file in Assets/Scripts/AdapterPattern
        string filePath = System.IO.Path.Combine(Application.dataPath, "Scripts", "AdapterPattern", "game_stats.csv");
        Debug.Log($"[ExerciseMiniGameManager] CSV file path: {filePath}");
        ISaveData saveData = new CsvFileSaveAdapter(filePath);
        GameStatsLogger statsLogger = new GameStatsLogger(saveData);

        gameFacade = new GameFacade(this, liftUIObserver, statsLogger);
        liftUIObserver.SetGameFacade(gameFacade, filePath);

        startButton.onClick.AddListener(() => gameFacade.StartSet());
    }

    public void OnStartButtonClicked()
    {
        IExerciseMiniGame baseMiniGame = factory.CreateMiniGame(exerciseType, animator, minTime, maxTime, RequiredReps);
        currentMiniGame = ApplySetTypeDecorator(baseMiniGame, setTypeDropdown.value);

        currentMiniGame.AddObserver(liftUIObserver);
        currentMiniGame.Initialize();
        startButton.gameObject.SetActive(false);
        setTypeDropdown.interactable = false;

        currentMiniGame.StartExercise();
    }

    private IExerciseMiniGame ApplySetTypeDecorator(IExerciseMiniGame baseMiniGame, int setTypeIndex)
    {
        switch (setTypeIndex)
        {
            case 0:
            Debug.Log("Selected Normal Game");
            return baseMiniGame;
            case 1:
            Debug.Log("Selected Easy Mode");
            return new EasyModeDecorator(baseMiniGame);
            case 2:
            Debug.Log("Selected Hard Mode");
            return new HardModeDecorator(baseMiniGame);
            case 3:
            Debug.Log("Selected Strength Set");
            return new StrengthSetDecorator(baseMiniGame);
            case 4:
            Debug.Log("Selected BodyBuilding Set");
            return new BodyBuildingSetDecorator(baseMiniGame);
            default:
            Debug.LogWarning("Unknown set type selected, using base mini-game.");
            return baseMiniGame;
        }
    }

    public void Update()
    {
        gameFacade.UpdateSet();
    }

    public void ResetGame()
    {
        if (currentMiniGame != null)
        {
            currentMiniGame.RemoveObserver(liftUIObserver);
            currentMiniGame.Reset();
            currentMiniGame = null;
        }

        if (startButton != null)
        {
            startButton.gameObject.SetActive(true);
            Debug.Log("[ExerciseMiniGameManager] Start button re-enabled.");
        }
        else
        {
            Debug.LogWarning("[ExerciseMiniGameManager] Start button is null!");
        }

        if (setTypeDropdown != null)
        {
            setTypeDropdown.interactable = true;
            Debug.Log("[ExerciseMiniGameManager] Dropdown re-enabled.");
        }
        else
        {
            Debug.LogWarning("[ExerciseMiniGameManager] Dropdown is null!");
        }

        Debug.Log("Game reset, ready for new set.");
    }
}