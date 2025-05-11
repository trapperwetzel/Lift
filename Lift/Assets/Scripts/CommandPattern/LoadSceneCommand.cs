using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : ICommand {
    private string sceneName;

    public LoadSceneCommand(string sceneName)
    {
        this.sceneName = sceneName;
    }

    public void Execute()
    {
        SceneManager.LoadScene(sceneName);
    }
}
