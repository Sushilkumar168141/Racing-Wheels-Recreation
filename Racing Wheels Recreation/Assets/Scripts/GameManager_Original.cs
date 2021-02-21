using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_Original: MonoBehaviour
{
    public bool game_started = false;

    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_started)
        {
            Time.timeScale = 0f;
        }
    }

    public void startGame()
    {
        //startButton.enabled = false;
        game_started = true;
        Time.timeScale = 1f;
        Destroy(startButton.gameObject);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitGame()
    {
        Debug.Log("Application Quitted");
        Application.Quit();
        //Debug.Log(Application.isPlaying);
    }

    


}
