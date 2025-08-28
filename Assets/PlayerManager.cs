using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;// Corrected to GameObject (with capital G)
    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public TMP_Text coinsText;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
       // gameOverPanel.SetActive(false);
       isGameStarted=false;
        numberOfCoins = 0;
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0; // Pause the game
            gameOverPanel.SetActive(true); // Display the game over panel
        }
        coinsText.text = "Coins : " + numberOfCoins;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isGameStarted= true;
            Destroy(startingText);
        }
    }
}  

