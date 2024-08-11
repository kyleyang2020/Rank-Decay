using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankUp : MonoBehaviour
{
    public class Rank
    {
        public int minimumLPGain, maximumLPGain, minimumLPLoss, maximumLPLoss, decayLP;
        public float winrate;

        public Rank(int _minimumLPGain, int _maximumLPGain, int _minimumLPLoss, int _maximumLPLoss, int _decayLP, float _winrate)
        {
            minimumLPGain = _minimumLPGain;
            maximumLPGain = _maximumLPGain;
            minimumLPLoss = _minimumLPLoss;
            maximumLPLoss = _maximumLPLoss;
            decayLP = _decayLP;
            winrate = _winrate;
        }
    }

    [Header("Trackers")]
    public int totalLP;
    public Rank currentRank;

    [Header ("Parameters")]
    // lp amounts to rank up
    public int bronzeLPCap;
    public int silverLPCap;
    public int goldLPCap;
    public int platinumLPCap;
    public int emeraldLPCap;
    public int diamondLPCap;
    public int masterLPCap;
    public int grandmasterLPCap;
    public int challengerLPCap;
    public TextMeshProUGUI rankText;
    public LeagueClicker leagueClicker;

    [Header("Ranks")]
    // public Rank(int minimumLPGain, int maximumLPGain, int minimumLPLoss, int maximumLPLoss, int decayLP, float winrate)
    public Rank Iron = new Rank(20, 55, 15, 25, 2, 80f);
    public Rank Bronze = new Rank(20, 50, 15, 25, 4, 80f);
    public Rank Silver = new Rank(20, 50, 15, 25, 4, 80f);
    public Rank Gold = new Rank(18, 40, 15, 25, 4, 70f);
    public Rank Platinum = new Rank(18, 40, 15, 25, 6, 70f);
    public Rank Emerald = new Rank(18, 35, 15, 25, 6, 70f);
    public Rank Diamond = new Rank(17, 35, 15, 25, 6, 60f);
    public Rank Master = new Rank(17, 30, 15, 25, 8, 60f);
    public Rank GrandMaster = new Rank(17, 30, 15, 25, 8, 60f);
    public Rank Challenger = new Rank(16, 25, 15, 25, 8, 51f);

    void Start()
    {
        currentRank = Iron;
    }

    void Update()
    {
        totalLP = leagueClicker.currentLP;
        if (totalLP > challengerLPCap)
        {
            rankText.text = "Rank: Challenger";
            currentRank = Challenger;
        }
        else if(totalLP > grandmasterLPCap && totalLP < challengerLPCap)
        {
            rankText.text = "Rank: GrandMaster";
            currentRank = GrandMaster;
        }
        else if (totalLP > masterLPCap && totalLP < grandmasterLPCap)
        {
            rankText.text = "Rank: Master";
            currentRank = Master;
        }
        else if (totalLP > diamondLPCap && totalLP < masterLPCap)
        {
            rankText.text = "Rank: Diamond";
            currentRank = Diamond;
        }
        else if (totalLP > emeraldLPCap && totalLP < diamondLPCap)
        {
            rankText.text = "Rank: Emerald";
            currentRank = Emerald;
        }
        else if (totalLP > platinumLPCap && totalLP < emeraldLPCap)
        {
            rankText.text = "Rank: Platinum";
            currentRank = Platinum;
        }
        else if (totalLP > goldLPCap && totalLP < platinumLPCap)
        {
            rankText.text = "Rank: Gold";
            currentRank = Gold;
        }
        else if (totalLP > silverLPCap && totalLP < goldLPCap)
        {
            rankText.text = "Rank: Silver";
            currentRank = Silver;
        }
        else if (totalLP > bronzeLPCap && totalLP < silverLPCap)
        {
            rankText.text = "Rank: Bronze";
            currentRank = Bronze;
        }
        else if (totalLP >= 0)
        {
            rankText.text = "Rank: Iron";
            currentRank = Iron;
        }

    }
}
