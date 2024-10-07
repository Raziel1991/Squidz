using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button buttStart;
    public Button buttQuit;
    void Start()
    {
        buttStart.onClick.AddListener(StartGame);
        buttQuit.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
