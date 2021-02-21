using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPosition : MonoBehaviour
{
    public GameObject positionPanel;
    public Text position1;
    public Text position2;
    public Text position3;
    public Text position4;
    //public Text[] positions;

    //public List<string> sortedPlayerNames = new List<string>();
    //public string playerNameString;

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gm.playerNameString;
        //Debug.Log(gm.playerNameString);

        /*
        position1.text = sortedPlayerNames[0];
        position2.text = sortedPlayerNames[1];
        position3.text = sortedPlayerNames[2];
        //position4.text = sortedPlayerNames[3];*/
    }
}
