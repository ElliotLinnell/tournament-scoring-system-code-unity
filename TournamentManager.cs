using System.Collections.Generic;
using UnityEngine;

public class TournamentManager : MonoBehaviour
/// <summary>
/// Represents a participant in the tournament.
/// </summary>
public class Participant
{
    /// <summary>
    /// Gets the name of the participant.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the total score of the participant.
    /// </summary>
    public int TotalScore { get; private set; }

    /// <summary>
    /// Gets the event scores of the participant.
    /// </summary>
    public Dictionary<string, int> EventScores { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Participant"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the participant.</param>
    public Participant(string name)
    {
        Name = name;
        TotalScore = 0;
        EventScores = new Dictionary<string, int>();
    }

    /// <summary>
    /// Adds a score for the specified event to the participant's total score.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="score">The score to add.</param>
    public void AddScore(string eventName, int score)
    {
        if (EventScores.ContainsKey(eventName))
            TotalScore -= EventScores[eventName];
        EventScores[eventName] = score;
        TotalScore += score;
    }
}

/// <summary>
/// Manages the tournament, including participants and events.
/// </summary>
public class TournamentManager
{
    /// <summary>
    /// List of individual participants.
    /// </summary>
    public List<Participant> individualParticipants = new List<Participant>();

    /// <summary>
    /// List of team participants.
    /// </summary>
    public List<Participant> teamParticipants = new List<Participant>();

    /// <summary>
    /// List of events in the tournament.
    /// </summary>
    public List<string> eventList = new List<string>();

    /// <summary>
    /// Adds a participant to the tournament.
    /// </summary>
    /// <param name="name">The name of the participant.</param>
    /// <param name="isTeam">Indicates whether the participant is a team.</param>
    public void AddParticipant(string name, bool isTeam = false)
    {
        if (isTeam)
            teamParticipants.Add(new Participant(name));
        else
            individualParticipants.Add(new Participant(name));
    }

    /// <summary>
    /// Initializes the list of events.
    /// </summary>
    public void InitializeEvents()
    {
        eventList.Clear();
    }

    /// <summary>
    /// Gets the names of all participants.
    /// </summary>
    /// <returns>A list of participant names.</returns>
    public List<string> GetParticipantNames()
    {
        List<string> names = new List<string>();
        foreach (var participant in individualParticipants)
            names.Add(participant.Name);
        foreach (var team in teamParticipants)
            names.Add(team.Name);
        return names;
    }

    /// <summary>
    /// Sets the rankings for a specific event and updates participant scores.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="rankings">A dictionary of participant names and their rankings.</param>
    public void SetEventRankings(string eventName, Dictionary<string, int> rankings)
    {
        foreach (var ranking in rankings)
        {
            int score = CalculateScore(ranking.Value);
            Participant participant = individualParticipants.Find(p => p.Name == ranking.Key) ??
                                      teamParticipants.Find(p => p.Name == ranking.Key);
            participant?.AddScore(eventName, score);
        }
    }

    /// <summary>
    /// Calculates the score based on the rank.
    /// </summary>
    /// <param name="rank">The rank of the participant.</param>
    /// <returns>The calculated score.</returns>
    private int CalculateScore(int rank)
    {
        return 100 - (rank - 1) * 10;
    }
}
