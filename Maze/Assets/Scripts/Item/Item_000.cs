using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_000 : MonoBehaviour //Gate
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You are in the Gate");
            if (PlayerStatus.instance != null)
            {
                PlayerStatus.instance.isOnGate = true;
            }

            // Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You exit the Gate");
            if (PlayerStatus.instance != null)
            {
                PlayerStatus.instance.isOnGate = false;
            }

            // Destroy(gameObject);
        }
    }
}
