using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvents : MonoBehaviour
{
    //Managers
    public LeagueClicker leagueClicker;
    private List<Event>events = new List<Event>()
    {
        new Event {Type = EventType.TeammateBoost, Duration = 15, Effect = "2x More LP with teammates"},
        new Event {Type = EventType.MentalFatigue, Duration = 10, Effect = "Two days rest"},
        new Event {Type = EventType.LosingStreak, Duration = 20, Effect = "Loss of LP is significantly increased"}

    };

    [Header("UI Components")]
    public Canvas canvas;
    public Text eventText;

    private float eventTimer = 10f;

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
            eventTimer = 25f; // Trigger an event every 30 seconds
        }
    }

    private void TriggerEvent()
    {
        int randomEventIndex = UnityEngine.Random.Range(0, events.Count);
        randomEvent = events[randomEventIndex];
        Debug.Log($"Event triggered: {randomEvent.Type}");

        // Display event text
        DisplayEventText(randomEvent.Type);

        // Apply the event effects
        switch (randomEvent.Type)
        {
            case EventType.TeammateBoost:
                originalGainLP = leagueClicker.gainLP;
                leagueClicker.gainLP *= 2;
                break;
            case EventType.MentalFatigue:
                // Subtract LP -500 LP
                leagueClicker.totalLP -= 500;
                break;
            case EventType.LosingStreak:
                // Increase rate of LP loss 5*LoseLP
                originalLossLP = leagueClicker.loseLP;
                leagueClicker.loseLP *= 5;
                break;
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
                leagueClicker.gainLP = originalGainLP; // Revert gainLP to its original value
                Debug.Log("Teammeate Boost: gainLP reverted to original value.");
                break;
            case EventType.LosingStreak:
                leagueClicker.loseLP = originalLossLP;
                Debug.Log("Losing Streak: loseLP reverted to original value.");
                break;
        }
    }

    private void DisplayEventText(EventType eventType)
    {
        string eventMessage = GetEventMessage(eventType);
        eventText.text = eventMessage;
        eventText.color = Color.red;
        eventText.enabled = true;

        // Hide the text after 2 seconds
        Invoke(nameof(HideEventText), 2f);
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
                return "Teammate Boost!";
            case EventType.MentalFatigue:
                return "You're tired, so you stop playing...";
            case EventType.LosingStreak:
                return "On a losing streak...";
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