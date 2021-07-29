using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    PlayerStatus playerStat;

    public float deployCheckpointTimer = 2;
    [SerializeField] GameObject checkpointItemObject;
    [SerializeField] Transform checkpointSpawnpoint;

    public Transform checkpointPosition;
    private float ReturnToCheckpointTimer = 2;

    void Start()
    {
        playerStat = PlayerStatus.instance;

        checkpointPosition = GameManager.instance.spawnpoint;
    }

    // Update is called once per frame
    void Update()
    {
        UseItem();
        ReturnToCheckpoint();
        DeployCheckpoint();

        // Debug.Log(gameObject.transform.GetChild(0).localPosition);
    }

    void UseItem()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (playerStat.hp < playerStat.maxHP)
            {
                if (playerStat.medKit > 0)
                {
                    playerStat.hp += 50;
                    playerStat.medKit -= 1;
                }
            }
        }
    }

    void DeployCheckpoint()
    {
        if (playerStat.checkPointItem)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                deployCheckpointTimer -= Time.deltaTime;
                Debug.Log($"Deploy check point in {deployCheckpointTimer}");
                if (deployCheckpointTimer <= 0)
                {
                    var _checkpoint = (GameObject)Instantiate(checkpointItemObject, checkpointSpawnpoint.position, checkpointSpawnpoint.rotation);
                    playerStat.checkPointItem = false;
                    playerStat.isCheckpoint = true;
                    deployCheckpointTimer = 2;

                    checkpointPosition.position = gameObject.transform.position;
                    Debug.Log(checkpointPosition.position);
                }
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                deployCheckpointTimer = 2;
            }
        }
    }

    void ReturnToCheckpoint()
    {
        if (playerStat.isCheckpoint)
        {
            if (Input.GetKey(KeyCode.E))
            {
                ReturnToCheckpointTimer -= Time.deltaTime;
                if (ReturnToCheckpointTimer <= 0)
                {
                    this.gameObject.transform.position = checkpointPosition.position;
                    playerStat.isCheckpoint = false;
                    ReturnToCheckpointTimer = 2;
                }
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                ReturnToCheckpointTimer = 3;
            }
        }
    }
}
