using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GoToLicense()
    {
        SceneManager.LoadScene(7);

    }
    public void GoToStart() {
        //Debug.Log("GoToStart");
        SceneManager.LoadScene(0);
    }
}
