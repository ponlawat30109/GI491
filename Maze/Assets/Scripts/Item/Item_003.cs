using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_003 : MonoBehaviour //Checkpoint
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You got Checkpoint Item");
            if (PlayerStatus.instance != null)
            {
                PlayerStatus.instance.checkPointItem = true;
            }

            Destroy(gameObject);
        }
    }
}
