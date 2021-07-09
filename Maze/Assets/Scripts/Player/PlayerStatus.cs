using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    [SerializeField] int hp = 50;
    [SerializeField] int maxHP = 100;

    public int keyItem = 0;
    public int medKit = 0;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        HealthCheck();
        UseItem();
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
}
