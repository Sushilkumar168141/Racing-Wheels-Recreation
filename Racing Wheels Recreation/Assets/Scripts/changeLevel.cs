using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class changeLevel : MonoBehaviour
{
    public GameObject gameEndPanel;
    public GameManager gm;

    public GameObject positionPanel;
    public GameObject finalPositionPanel;

    public TMP_Text position1;
    public TMP_Text position2;
    public TMP_Text position3;
    public TMP_Text position4;


    // Start is called before the first frame update
    void Start()
    {
        finalPositionPanel.SetActive(false);
        /*if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameEndPanel.SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gm.playerNames[0]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWheel")
        {
            Debug.Log("Collided with wheel");
            positionPanel.SetActive(false);
            finalPositionPanel.SetActive(true);
            position1.text = "1. " + gm.playerNames[0];
            position2.text = "2. " + gm.playerNames[1];
            position3.text = "3. " + gm.playerNames[2];
            position4.text = "4. " + gm.playerNames[3];
        }
    }

    public void changeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            finalPositionPanel.SetActive(false);
            gm.game_started = false;
            gameEndPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
