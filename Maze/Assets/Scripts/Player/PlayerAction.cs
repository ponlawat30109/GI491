using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    PlayerStatus playerStat;

    public float deployCheckpointTimer = 3;
    [SerializeField] GameObject checkpointItemObject;
    [SerializeField] Transform checkpointSpawnpoint;

    public Vector3 checkpointPosition = new Vector3(0, 0, 0);
    private float ReturnToCheckpointTimer = 3;

    void Start()
    {
        playerStat = PlayerStatus.instance;
    }

    // Update is called once per frame
    void Update()
    {
        UseItem();
        DeployCheckpoint();
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
                // if (deployCheckpointTimer <= 0)
                // {
                // Debug.Log(true);
                if (playerStat.checkPointItem == true)
                {
                    // Debug.Log(true);
                    Instantiate(checkpointItemObject, checkpointSpawnpoint.position, Quaternion.identity);
                    playerStat.checkPointItem = false;
                    playerStat.isCheckpoint = true;
                    deployCheckpointTimer = 3;

                    checkpointPosition = checkpointSpawnpoint.position;
                }
                // }
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                deployCheckpointTimer = 3;
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
                    this.gameObject.transform.position = checkpointPosition;
                }
            }
        }
    }
}
