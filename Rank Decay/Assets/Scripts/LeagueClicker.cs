using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static RankUp;

public class LeagueClicker : MonoBehaviour
{
    [Header ("Teackers")]
    public int currentLP;
    public int totalGainLP;
    public int totalLoseLP;
    public int gamesWon = 1;
    public int totalGames = 1;
    // set by other script
    public int gainRankLP;
    public int lossRankLP;
    public int decayRankLP;
    public float wrRankPercent;

    [Header("Parameters")]
    public RankUp rankUp;
    public KeyCode playButton;
    public TextMeshProUGUI lpText;
    public TextMeshProUGUI lpGainText;
    public TextMeshProUGUI lpLostText;
    public TextMeshProUGUI wrText;

    void Start()
    {
        // every second called loseLP and decay lp
        InvokeRepeating("DecayLP", 0, 1);
    }

    void Update()
    {
        // update winrate
        wrRankPercent = rankUp.currentRank.winrate;
        // update text on screen
        lpText.text = "LP: " + currentLP.ToString();
        lpGainText.text = "Total LP Gained: " + totalGainLP.ToString();
        lpLostText.text = "Total LP Lost: " + totalLoseLP.ToString();
        wrText.text = "Winrate: " + (((float)gamesWon/(float)totalGames) * 100).ToString() + "%";

        // play a lol game
        if (Input.GetKeyDown(playButton))
        {
            // roll the dice of gods and see if you win your league game
            float wr = Random.Range(0f, 100f);
            if(wr < wrRankPercent)
            {
                GainLP();
                gamesWon++;
                totalGames++;
            }
            else if(wr > wrRankPercent)
            {
                LoseLP();
                totalGames++;
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
