using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_001 : MonoBehaviour //File
{
    public AudioClip soundFile;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You got 1 File");
            if (PlayerStatus.instance != null)
            {
                GameManager.instance.currentKeyItem += 1;
            }

            Destroy(gameObject);
        }
    }
}
