using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool game_started = false;

    public Rigidbody player;
    public Rigidbody alpha;
    public Rigidbody beta;
    public Rigidbody gamma;

    public float playerPosition;
    public float alphaPosition;
    public float betaPosition;
    public float gammaPosition;

    string pname = "Player";
    string aname = "Alpha";
    string bname = "Beta";
    string gname = "Gamma";

    public List<string> playerNames = new List<string>(capacity: 4);
    public string playerNameString;

    public List<Rigidbody> players = new List<Rigidbody>(4);
    //public ArrayList positionList = new ArrayList(capacity: 4);

    public Button startButton;

    //public GameObject positionPanel;
    public TMP_Text position1;
    public TMP_Text position2;
    public TMP_Text position3;
    public TMP_Text position4;


    // Start is called before the first frame update
    void Start()
    {
        /*positionList.Add(player);
        positionList.Add(alpha);
        positionList.Add(beta);
        positionList.Add(gamma);*/
        


    }

    // Update is called once per frame
    void Update()
    {
        if (!game_started)
        {
            Time.timeScale = 0f;
        }

        players = players.OrderBy(player => -player.position.z).ToList();
        playerNames = players.ConvertAll(player => player.name);
        string playerNameString = string.Join(" ", playerNames.ToArray());
        //Debug.Log(playerNameString);

        playerPosition = player.position.z;
        alphaPosition = alpha.position.z;
        betaPosition = beta.position.z;
        gammaPosition = gamma.position.z;

        position1.text = "1. "+ playerNames[0];
        position2.text = "2. "+ playerNames[1];
        position3.text = "3. " + playerNames[2];
        position4.text = "4. " + playerNames[3];
        //print("Sorted list : " + players[0].position.z + ", " + players[1].position.z + ", " + players[2].position.z + ", " + players[3].position.z);
        //print(playerNames[0] + playerNames[1] + playerNames[2] + playerNames[3]);
        //print("Sorted list : " + positionList[0] + ", " + positionList[1] + ", " + positionList[2] + ", " + positionList[3]);

        

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
