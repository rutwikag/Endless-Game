using UnityEngine.SceneManagement;
using UnityEngine;


public class Events : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}  
