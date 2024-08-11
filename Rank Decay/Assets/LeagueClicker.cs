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
    // set by other script
    public int gainRankLP;
    public int lossRankLP;
    public int decayRankLP;
    public int wrRank;

    [Header("Parameters")]
    public RankUp rankUp;
    public KeyCode playButton;
    public Text lpText;

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
            if(wr > wrRank)
            {
                GainLP(gainRankLP);
            }
            else if(wr < wrRank)
            {
                LoseLP(lossRankLP);
            }
        }
    }

    void GainLP(int rankGainLP)
    {
        // add to current lp as WIN, track total gain
        currentLP += rankGainLP;
        totalGainLP += rankGainLP;
        Debug.Log(rankGainLP.ToString());
    }

    void LoseLP(int rankLossLP)
    {
        // sub to current lp as LOSS, track total loss
        currentLP -= rankLossLP;
        totalLoseLP -= rankLossLP;
        Debug.Log(rankLossLP.ToString());
    }

    void DecayLP()
    {
        // sub to current lp from DECAY, track total loss
        currentLP -= decayRankLP;
        totalLoseLP -= decayRankLP;
        Debug.Log(decayRankLP.ToString());
    }

    void SetDecayLP(int rankDecayLP)
    {
        decayRankLP = rankDecayLP;
    }
}
