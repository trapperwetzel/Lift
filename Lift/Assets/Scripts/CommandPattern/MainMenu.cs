using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
    [SerializeField] private MenuButtonInvoker squatButtonInvoker;
    [SerializeField] private MenuButtonInvoker benchButtonInvoker;
    [SerializeField] private MenuButtonInvoker quitButtonInvoker;

    private void Start()
    {
        // Assign Commands
        squatButtonInvoker.SetCommand(new LoadSceneCommand("SquatDay"));
        benchButtonInvoker.SetCommand(new LoadSceneCommand("BenchDay"));
        quitButtonInvoker.SetCommand(new QuitCommand());
    }
}




