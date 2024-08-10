using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeagueClicker : MonoBehaviour
{
    // trackers
    public int totalLP;
    public int gainLP;
    public int loseLP;

    // button to press to gain lp
    public KeyCode playButton;

    // text elements to display 
    public Text lpText;

    // Start is called before the first frame update
    void Start()
    {
        // every second called loseLP and decay lp
        InvokeRepeating("LoseLP", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // update text
        lpText.text = "LP: " + totalLP.ToString();
        // gain lp when playing games
        if(Input.GetKeyDown(playButton))
        {
            GainLP();
        }
    }

    void GainLP()
    {
        totalLP += gainLP;
    }

    void LoseLP()
    {
        totalLP -= loseLP;
    }
}
