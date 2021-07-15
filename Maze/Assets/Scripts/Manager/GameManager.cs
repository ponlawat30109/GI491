using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] List<GameObject> playerList = new List<GameObject>();

    private GameObject player;
    [SerializeField] Transform spawnpoint;
    [SerializeField] public string playerName;
    private bool isPlayerExist = false;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        // playerName = UIManager.instance.playerSelectName;

        Debug.Log(playerName);
    }

    void Update()
    {
        playerName = UIManager.instance.playerSelectName;
        if (!isPlayerExist)
        {
            if (playerName == "TuuTuu")
            {
                // playerList[0].SetActive(true);
                player = Instantiate(playerList[0], spawnpoint.position, Quaternion.identity);
                isPlayerExist = true;
            }
            else if (playerName == "PomPom")
            {
                // playerList[1].SetActive(true);
                player = Instantiate(playerList[1], spawnpoint.position, Quaternion.identity);
                isPlayerExist = true;
            }
        }
    }
}
