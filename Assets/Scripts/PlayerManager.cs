using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player[] players;
    private int playerIdx;

    private void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].gameObject.activeSelf)
                players[i].SetActive(true);
                players[i].gameObject.SetActive(false);
        }
        players[0].gameObject.SetActive(true);
        //players[0].SetActive(true);
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && players[playerIdx].canThrow)
        {
            SwitchPlayers();
        }
    }

    private void SwitchPlayers()
    {
        //Vector3 pos = players[playerIdx].transform.position;
        //players[playerIdx].SetActive(false);
        players[playerIdx].gameObject.SetActive(false);
        playerIdx = (playerIdx + 1) % players.Length;
        players[playerIdx].gameObject.SetActive(true);
        //players[playerIdx].SetPosition(pos);
        //players[playerIdx].SetActive(true);
    }
}