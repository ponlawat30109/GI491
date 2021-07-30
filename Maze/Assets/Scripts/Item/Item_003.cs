using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_003 : MonoBehaviour //Checkpoint
{
    public AudioClip soundCheckpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You got Checkpoint Item");
            if (PlayerStatus.instance != null)
            {
                PlayerStatus.instance._audioSource.PlayOneShot(soundCheckpoint);
                PlayerStatus.instance.checkPointItem = true;
                PlayerStatus.instance.isCheckpoint = false;
            }

            Destroy(gameObject);
        }
    }
}
