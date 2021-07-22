using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    public float hp = 50;
    public float maxHP = 100;
    public int keyItem = 0;
    public int medKit = 0;
    public bool checkPointItem = false;

    public float deployCheckpointTimer = 1;
    [SerializeField] GameObject checkpointItemObject;
    [SerializeField] Transform checkpointSpawnpoint;

    void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        // DeployCheckpoint();
    }

    void Update()
    {
        HealthCheck();
        UseItem();
        DeployCheckpoint();
    }

    void UseItem()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (hp < maxHP)
            {
                if (medKit > 0)
                {
                    hp += 50;
                    medKit -= 1;
                }
            }
        }
    }

    void HealthCheck()
    {
        if (hp > maxHP)
        {
            hp = maxHP;
        }
    }

    void DeployCheckpoint()
    {
        if (checkPointItem)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                deployCheckpointTimer -= Time.deltaTime;
                Debug.Log($"Deploy check point in {deployCheckpointTimer}");
                if (deployCheckpointTimer <= 0)
                {
                    // Debug.Log(true);
                    if (checkPointItem == true)
                    {
                        // Debug.Log(true);
                        Instantiate(checkpointItemObject, checkpointSpawnpoint.position, Quaternion.identity);
                        checkPointItem = false;
                        deployCheckpointTimer = 1;
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                deployCheckpointTimer = 1;
            }
        }
    }
}
