using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] List<GameObject> playerList = new List<GameObject>();

    private GameObject player;
    [SerializeField] public Transform spawnpoint;
    [SerializeField] string playerName;
    private bool isPlayerExist = false;
    // private PlayerStatus playerStat;

    [SerializeField] int keyItemCount;

    void Awake()
    {
        instance = this;

        // DontDestroyOnLoad(this);
    }

    void Start()
    {
        playerName = CharacterManager.instance.playerName;

        SpawnPlayer(spawnpoint);
        var keyCout = GameObject.FindGameObjectsWithTag("Key");
        keyItemCount = keyCout.Length;
    }

    void Update()
    {
        // SpawnPlayer();
        HPCheck();
        KeyItemCheck();

        // DeployCheckpoint();
    }

    void SpawnPlayer(Transform spawnPosition)
    {
        // playerName = CharacterManager.instance.playerName;
        if (!isPlayerExist)
        {
            // if (playerName == "TuuTuu")
            // {
            //     // playerList[0].SetActive(true);
            //     player = (GameObject)Instantiate(playerList[0], spawnPosition, Quaternion.identity);
            //     isPlayerExist = true;
            // }
            // else if (playerName == "PomPom")
            // {
            //     // playerList[1].SetActive(true);
            //     player = (GameObject)Instantiate(playerList[1], spawnPosition, Quaternion.identity);
            //     isPlayerExist = true;
            // }

            switch (playerName)
            {
                case "TuuTuu":
                    player = (GameObject)Instantiate(playerList[0], spawnPosition.position, Quaternion.identity);
                    isPlayerExist = true;
                    break;
                case "PomPom":
                    player = (GameObject)Instantiate(playerList[1], spawnPosition.position, Quaternion.identity);
                    isPlayerExist = true;
                    break;
                default:
                    break;
            }
        }
    }

    void KeyItemCheck()
    {
        // player.GetComponent
        if (player != null)
        {
            if (player.GetComponentInChildren<PlayerStatus>().keyItem >= keyItemCount)
            {
                if (player.GetComponentInChildren<PlayerStatus>().isOnGate)
                {
                    Debug.Log(true);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }

    }

    void HPCheck()
    {
        if (player != null)
        {
            if (player.GetComponentInChildren<PlayerStatus>().hp <= 0)
            {
                Destroy(player);
                isPlayerExist = false;

                // player.transform.position = (player.GetComponentInChildren<PlayerAction>().checkpointPosition);
                if (!player.GetComponentInChildren<PlayerStatus>().isCheckpoint)
                {
                    SpawnPlayer(spawnpoint);
                }
                else
                {
                    SpawnPlayer(player.GetComponentInChildren<PlayerAction>().checkpointPosition);
                }
            }
        }
    }

    // void CheckpointPosition()
    // {
    //     if (player.GetComponentInChildren<PlayerStatus>().isCheckpoint)
    //     {
    //         // spawnpoint.position = 
    //     }
    // }

    // void ReturnToCheckpoint()
    // {
    //     player.transform.position = (player.GetComponentInChildren<PlayerAction>().checkpointPosition);
    // }
}
