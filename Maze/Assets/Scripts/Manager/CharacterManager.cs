using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    public string playerName;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        playerName = UIManager.instance.playerSelectName;
    }
}
