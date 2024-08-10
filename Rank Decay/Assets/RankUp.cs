using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankUp : MonoBehaviour
{
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

    // rank text and lp tracker
    public Text rankText;
    public LeagueClicker leagueClicker;
    public int totalLP;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        totalLP = leagueClicker.totalLP;
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
