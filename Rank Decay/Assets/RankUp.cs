using System.Collections;
using System.Collections.Generic;
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
    public Text rankText;
    public LeagueClicker leagueClicker;

    [Header("Ranks")]
    // public Rank(int minimumLPGain, int maximumLPGain, int minimumLPLoss, int maximumLPLoss, int decayLP, float winrate)
    public Rank Iron = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank Bronze = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank Silver = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank Gold = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank Platinum = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank Emerald = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank Diamond = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank Master = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank GrandMaster = new Rank(20, 50, 15, 25, 10, 80f);
    public Rank Challenger = new Rank(20, 50, 15, 25, 10, 80f);

    void Start()
    {

    }

    void Update()
    {
        totalLP = leagueClicker.currentLP;
        if (totalLP > challengerLPCap)
        {
            rankText.text = "Rank: Challenger" ;
        }
        else if(totalLP > grandmasterLPCap && totalLP < challengerLPCap)
        {
            rankText.text = "Rank: GrandMaster";
        }
        else if (totalLP > masterLPCap && totalLP < grandmasterLPCap)
        {
            rankText.text = "Rank: Master";
        }
        else if (totalLP > diamondLPCap && totalLP < masterLPCap)
        {
            rankText.text = "Rank: Diamond";
        }
        else if (totalLP > emeraldLPCap && totalLP < diamondLPCap)
        {
            rankText.text = "Rank: Emerald";
        }
        else if (totalLP > platinumLPCap && totalLP < emeraldLPCap)
        {
            rankText.text = "Rank: Platinum";
        }
        else if (totalLP > goldLPCap && totalLP < platinumLPCap)
        {
            rankText.text = "Rank: Gold";
        }
        else if (totalLP > silverLPCap && totalLP < goldLPCap)
        {
            rankText.text = "Rank: Silver";
        }
        else if (totalLP > bronzeLPCap && totalLP < silverLPCap)
        {
            rankText.text = "Rank: Bronze";
        }
        else if (totalLP >= 0)
        {
            rankText.text = "Rank: Iron";
        }

    }
}
