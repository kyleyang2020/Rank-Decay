using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class RankSprite : MonoBehaviour
{
    public Image img;

    [Header("RANKS")]
    public Sprite iron;
    public Sprite bronze;
    public Sprite silver;
    public Sprite gold;
    public Sprite platinum;
    public Sprite emerald;
    public Sprite diamond;
    public Sprite master;
    public Sprite grandmaster;
    public Sprite challenger;

    public LeagueClicker leagueClicker;
    private int totalLP;
    public RankUp rankUp;

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        totalLP = leagueClicker.currentLP;
        if (totalLP > rankUp.challengerLPCap)
        {
            img.sprite = challenger;
        }
        else if (totalLP > rankUp.grandmasterLPCap && totalLP < rankUp.challengerLPCap)
        {
            img.sprite = grandmaster;
        }
        else if (totalLP > rankUp.masterLPCap && totalLP < rankUp.grandmasterLPCap)
        {
            img.sprite = master;
        }
        else if (totalLP > rankUp.diamondLPCap && totalLP < rankUp.masterLPCap)
        {
            img.sprite = diamond;
        }
        else if (totalLP > rankUp.emeraldLPCap && totalLP < rankUp.diamondLPCap)
        {
            img.sprite = emerald;
        }
        else if (totalLP > rankUp.platinumLPCap && totalLP < rankUp.emeraldLPCap)
        {
            img.sprite = platinum;
        }
        else if (totalLP > rankUp.goldLPCap && totalLP < rankUp.platinumLPCap)
        {
            img.sprite = gold;
        }
        else if (totalLP > rankUp.silverLPCap && totalLP < rankUp.goldLPCap)
        {
            img.sprite = silver;
        }
        else if (totalLP > rankUp.bronzeLPCap && totalLP < rankUp.silverLPCap)
        {
            img.sprite = bronze;
        }
        else if (totalLP >= 0)
        {
            img.sprite = iron;
        }
    }
}
