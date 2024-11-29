using System.Collections.Generic;
using UnityEngine;

public class TournamentManager : MonoBehaviour
{
    public class Participant
    {
        public string Name { get; private set; }
        public int TotalScore { get; private set; }
        public Dictionary<string, int> EventScores { get; private set; }

        public Participant(string name)
        {
            Name = name;
            TotalScore = 0;
            EventScores = new Dictionary<string, int>();
        }

        public void AddScore(string eventName, int score)
        {
            if (EventScores.ContainsKey(eventName))
                TotalScore -= EventScores[eventName];
            EventScores[eventName] = score;
            TotalScore += score;
        }
    }

    public List<Participant> individualParticipants = new List<Participant>();
    public List<Participant> teamParticipants = new List<Participant>();
    public List<string> eventList = new List<string>();

    public void AddParticipant(string name, bool isTeam = false)
    {
        if (isTeam)
            teamParticipants.Add(new Participant(name));
        else
            individualParticipants.Add(new Participant(name));
    }

    public void InitializeEvents()
    {
        eventList.Clear();
    }

    public List<string> GetParticipantNames()
    {
        List<string> names = new List<string>();
        foreach (var participant in individualParticipants)
            names.Add(participant.Name);
        foreach (var team in teamParticipants)
            names.Add(team.Name);
        return names;
    }

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

    private int CalculateScore(int rank)
    {
        
        return 100 - (rank - 1) * 10; 
    }
}
