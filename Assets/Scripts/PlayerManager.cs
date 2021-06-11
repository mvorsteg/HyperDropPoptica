using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player[] players;
    private int playerIdx;

    private void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(false);
        }
        players[0].SetActive(true);
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPlayers();
        }
    }

    private void SwitchPlayers()
    {
        players[playerIdx].SetActive(false);
        playerIdx = (playerIdx + 1) % players.Length;
        players[playerIdx].SetActive(true);
    }
}