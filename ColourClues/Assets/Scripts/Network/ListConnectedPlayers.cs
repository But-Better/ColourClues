using Network;
using TMPro;
using UnityEngine;

/// <summary>
/// Currently Connected Player vistual Listing 
/// </summary>
public class ListConnectedPlayers : MonoBehaviour
{
    [SerializeField] private CustomLevelLoadNetworkManager networkManager = null;

    [SerializeField] private TMP_Text currentNumPlayersDisplay = null;

    void OnEnable()
    {
        CustomLevelLoadNetworkManager.ConnectionUpdate += UpdateConnectedPlayers;
    }

    private void OnDisable()
    {
        CustomLevelLoadNetworkManager.ConnectionUpdate -= UpdateConnectedPlayers;
    }

    private void UpdateConnectedPlayers()
    {
        var minNeededConnections = networkManager.MinPlayers;
        var currentConnected = networkManager.currentlyConnected;

        currentNumPlayersDisplay.text = $"{currentConnected} / {minNeededConnections}";
    }
}
