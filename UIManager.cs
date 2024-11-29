using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TournamentManager tournamentManager;
    public TMP_InputField participantNameInput;
    public Button addIndividualButton;
    public Button addTeamButton;
    public TextMeshProUGUI leaderboardText;
    public TextMeshProUGUI eventListText;
    public GameObject eventPopupPanel;
    public TMP_InputField newEventInputField;
    public Button confirmAddEventButton;
    public GameObject rankingsPopupPanel;
    public TextMeshProUGUI rankingsEventTitleText;
    public List<TMP_Dropdown> rankingsDropdowns;
    public Button confirmRankingsButton;
    public Button setRankingsButton;
    public TMP_Dropdown eventDropdown;
    private string currentEventName;

    void Start()
    {
        addIndividualButton.onClick.AddListener(() => AddParticipant(false));
        addTeamButton.onClick.AddListener(() => AddParticipant(true));
        tournamentManager.InitializeEvents();
        UpdateEventList();
        
        confirmAddEventButton.onClick.AddListener(OnAddEventConfirm);
        confirmRankingsButton.onClick.AddListener(OnConfirmRankings);
        setRankingsButton.onClick.AddListener(OpenRankingsPanel);
    }

    public void AddParticipant(bool isTeam)
    {
        string name = participantNameInput.text;
        if (!string.IsNullOrEmpty(name))
        {
            tournamentManager.AddParticipant(name, isTeam);
            UpdateLeaderboard();
            participantNameInput.text = "";
        }
    }

    public void UpdateLeaderboard()
    {
        leaderboardText.text = "Leaderboard:\n";
        if (tournamentManager.individualParticipants.Count == 0 && tournamentManager.teamParticipants.Count == 0)
        {
            leaderboardText.text += "No participants yet.";
            return;
        }

        foreach (var participant in tournamentManager.individualParticipants)
        {
            leaderboardText.text += $"{participant.Name}: {participant.TotalScore} points\n";
        }
        foreach (var team in tournamentManager.teamParticipants)
        {
            leaderboardText.text += $"{team.Name} (Team): {team.TotalScore} points\n";
        }
    }

    public void UpdateEventList()
    {
        eventListText.text = "Event List:\n";
        foreach (var eventName in tournamentManager.eventList)
        {
            eventListText.text += $"{eventName}\n";
        }
        UpdateEventDropdown();
    }

    private void UpdateEventDropdown()
    {
        eventDropdown.ClearOptions();
        eventDropdown.AddOptions(new List<string>(tournamentManager.eventList));
    }

    public void OnEventPanelClick()
    {
        eventPopupPanel.SetActive(true);
        newEventInputField.text = "";
    }

    private void OnAddEventConfirm()
    {
        string newEventName = newEventInputField.text;
        if (!string.IsNullOrEmpty(newEventName))
        {
            tournamentManager.eventList.Add(newEventName);
            UpdateEventList();
            eventPopupPanel.SetActive(false);
        }
    }

    private void OpenRankingsPanel()
    {
        if (eventDropdown.options.Count > 0)
        {
            currentEventName = eventDropdown.options[eventDropdown.value].text;
            rankingsEventTitleText.text = $"Set Rankings for {currentEventName}";

            List<string> participantNames = tournamentManager.GetParticipantNames();

            for (int i = 0; i < rankingsDropdowns.Count; i++)
            {
                rankingsDropdowns[i].ClearOptions();
                rankingsDropdowns[i].AddOptions(participantNames);

                if (participantNames.Count > 0)
                {
                    rankingsDropdowns[i].value = 0;
                }
            }
            rankingsPopupPanel.SetActive(true);
        }
    }

    private void OnConfirmRankings()
    {
        Dictionary<string, int> rankings = new Dictionary<string, int>();

        for (int i = 0; i < rankingsDropdowns.Count; i++)
        {
            string participantName = rankingsDropdowns[i].options[rankingsDropdowns[i].value].text;
            rankings[participantName] = i + 1;
        }

        tournamentManager.SetEventRankings(currentEventName, rankings);
        UpdateLeaderboard();
        rankingsPopupPanel.SetActive(false);
    }
}
