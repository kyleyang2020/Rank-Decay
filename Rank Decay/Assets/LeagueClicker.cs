using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeagueClicker : MonoBehaviour
{
    [Header ("Teackers")]
    public int currentLP;
    public int totalGainLP;
    public int totalLoseLP;
    public int gamesWon;
    public int gamesLost;

    [Header("Parameters")]
    public KeyCode playButton;
    public Text lpText;
    public int gainLP;
    public int lossLP;
    public int decayLP;

    void Start()
    {
        // every second called loseLP and decay lp
        InvokeRepeating("DecayLP", 0, 1);
    }

    void Update()
    {
        // update text on screen
        lpText.text = "LP: " + currentLP.ToString();

        // play a lol game
        if(Input.GetKeyDown(playButton))
        {
            // roll the dice of gods and see if you win your league game
            float wr = Random.Range(0f, 100f);
            if(wr > 49f)
            {
                GainLP();
            }
            else if(wr < 49f)
            {
                LoseLP();
            }
        }
    }

    void GainLP()
    {
        // add to current lp as WIN, track total gain
        currentLP += gainLP;
        totalGainLP += gainLP;
    }

    void LoseLP()
    {
        // sub to current lp as LOSS, track total loss
        currentLP -= lossLP;
        totalLoseLP -= lossLP;
    }

    void DecayLP()
    {
        // sub to current lp from DECAY, track total loss
        currentLP -= decayLP;
        totalLoseLP -= decayLP;
    }
}
