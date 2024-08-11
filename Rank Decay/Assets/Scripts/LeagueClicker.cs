using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static RankUp;

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
                GainLP();
            }
            else if(wr < wrRank)
            {
                LoseLP();
            }
        }
    }

    void GainLP()
    {
        // random lp loss then covert to int
        float lp = Random.Range(rankUp.currentRank.minimumLPLoss, rankUp.currentRank.maximumLPLoss);
        int rankGainLP = (int)lp;

        // add to current lp as WIN, track total gain
        currentLP += rankGainLP;
        totalGainLP += rankGainLP;
        Debug.Log(rankGainLP.ToString());
    }

    void LoseLP()
    {
        // random lp loss then covert to int
        float lp = Random.Range(rankUp.currentRank.minimumLPLoss, rankUp.currentRank.maximumLPLoss);
        int rankLossLP = (int)lp;

        // sub to current lp as LOSS, track total loss
        currentLP -= rankLossLP;
        totalLoseLP -= rankLossLP;
        Debug.Log(rankLossLP.ToString());
    }

    void DecayLP()
    {
        int decayRankLP = rankUp.currentRank.decayLP;

        // sub to current lp from DECAY, track total loss
        currentLP -= decayRankLP;
        totalLoseLP -= decayRankLP;
        Debug.Log(decayRankLP.ToString());
    }
}
