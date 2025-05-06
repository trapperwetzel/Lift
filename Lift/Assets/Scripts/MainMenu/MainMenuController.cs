
using UnityEngine;
using TinyGiantStudio.Text;// Tiny Giant Studio
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    [Header("Buttons")]
  //  [SerializeField] MText_UI_Button playButton;
    //[SerializeField] MText_UI_Button optionsButton;
   // [SerializeField] MText_UI_Button quitButton;

    [Header("Panels")]
    [SerializeField] GameObject optionsPanel;

    void Awake()
    {
        //playButton.onClick.AddListener(() => SceneManager.LoadScene("SquatMiniGame")); // TODO: change scene name
        //optionsButton.onClick.AddListener(() => optionsPanel.SetActive(!optionsPanel.activeSelf));
       // quitButton.onClick.AddListener(() => QuitGame());
    }

    void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
