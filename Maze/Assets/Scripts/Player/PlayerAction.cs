using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    PlayerStatus playerStat;

    public float deployCheckpointTimer = 2;
    [SerializeField] GameObject checkpointItemObject;
    [SerializeField] Transform checkpointSpawnpoint;

    public Vector3 checkpointPosition = new Vector3(0, 0, 0);
    private float ReturnToCheckpointTimer = 2;

    void Start()
    {
        playerStat = PlayerStatus.instance;
    }

    // Update is called once per frame
    void Update()
    {
        UseItem();
        ReturnToCheckpoint();
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
                if (deployCheckpointTimer <= 0)
                // {
                // Debug.Log(true);
                // if (playerStat.checkPointItem == true)
                {
                    // Debug.Log(true);
                    var _checkpoint = Instantiate(checkpointItemObject, checkpointSpawnpoint.position, Quaternion.identity);
                    playerStat.checkPointItem = false;
                    playerStat.isCheckpoint = true;
                    deployCheckpointTimer = 2;

                    checkpointPosition = _checkpoint.transform.position;
                }
                // }
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
                    this.gameObject.transform.position = checkpointPosition;
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
