using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_002 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You got 1 MedKit");
            if (PlayerStatus.instance != null)
            {
                PlayerStatus.instance.medKit += 1;
            }

            Destroy(gameObject);
        }
    }
}
