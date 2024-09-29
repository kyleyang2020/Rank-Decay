using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvents : MonoBehaviour
{
    //Managers
    public LeagueClicker leagueClicker;
    private List<Event>events = new List<Event>()
    {
        new Event {Type = EventType.TeammateBoost, Duration = 3, Effect = "2x More LP with teammates"},
        new Event {Type = EventType.MentalFatigue, Duration = 2, Effect = "Two days rest"},
        new Event {Type = EventType.LosingStreak, Duration = 7, Effect = "Loss of LP is significantly increased"}

    };

    [Header("UI Components")]
    public Canvas canvas;
    public TextMeshProUGUI eventText;

    private float eventTimer = 5f;

    private Event randomEvent;

    private int originalGainLP;
    private int originalLossLP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eventTimer -= Time.deltaTime;
        if (eventTimer <= 0f)
        {
            TriggerEvent();
            eventTimer = 10f; // Trigger an event every 30 seconds
        }
    }

    private void TriggerEvent()
    {
        int randomEventIndex = UnityEngine.Random.Range(0, events.Count);
        randomEvent = events[randomEventIndex];
        Debug.Log($"Event triggered: {randomEvent.Type}");

        // Display event text
        DisplayEventText(randomEvent.Type);

        if (leagueClicker.currentLP > 0)
        {
            // Apply the event effects
            switch (randomEvent.Type)
            {
                case EventType.TeammateBoost:
                    // originalGainLP = leagueClicker.totalGainLP;
                    // //Current LP rate increase by 2          HELP ME WITH THIS
                    leagueClicker.currentLP += 100;
                    leagueClicker.totalGainLP += 100;
                    break;
                case EventType.MentalFatigue:
                    // Subtract current LP by -300
                    leagueClicker.currentLP -= 300;
                    leagueClicker.totalLoseLP -= 300;
                    break;
                case EventType.LosingStreak:
                    // // Decrease rate of currentLP by -20
                    // originalLossLP = leagueClicker.totalLoseLP;      HELP ME WITH THIS
                    leagueClicker.currentLP -= 500;
                    leagueClicker.totalLoseLP -= 500;
                    break;
            }
        }
        // Set a timer to end the event
        Invoke(nameof(EndEventDelayed), randomEvent.Duration);
    }

    private void EndEventDelayed()
    {
        EndEvent(randomEvent);
    }
    private void EndEvent(Event endedEvent)
    {
        switch (endedEvent.Type)
        {
            case EventType.TeammateBoost:
                // leagueClicker.totalGainLP = originalGainLP; // Revert gainLP to its original value
                // Debug.Log("Teammeate Boost: gainLP reverted to original value.");                    THIS REVERTS BACK CHANGES FROM TEAMMATEBOOST
                break;
            case EventType.LosingStreak:
                    // leagueClicker.totalLoseLP = originalLossLP;
                    // Debug.Log("Losing Streak: loseLP reverted to original value.");              THIS REVERTS BACK FROM LOSINGSTREAK
                break;
        }
    }

    private void DisplayEventText(EventType eventType)
    {
        string eventMessage = GetEventMessage(eventType);
        eventText.text = eventMessage;
        eventText.color = Color.red;
        eventText.enabled = true;

        // Hide the text after 4 seconds
        Invoke(nameof(HideEventText), 4f);
    }

    private void HideEventText()
    {
        eventText.enabled = false;
    }

    // Function to get event message
    private string GetEventMessage(EventType eventType)
    {
        switch (eventType)
        {
            case EventType.TeammateBoost:
                return "Teammate Boost! +100LP";
            case EventType.MentalFatigue:
                return "You're tired, so you stop playing... -300LP";
            case EventType.LosingStreak:
                return "On a losing streak... -500LP";
            default:
                return "";
        }
    }
}

public enum EventType
{
    TeammateBoost,
    MentalFatigue,
    LosingStreak,
    // ...
}
public class Event
{
    public EventType Type { get; set; }
    public float Duration { get; set; }
    public string Effect { get; set; }
}