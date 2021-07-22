using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_004 : MonoBehaviour //ThornTrap
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ThornTrap");
            if (PlayerStatus.instance != null)
            {
                PlayerStatus.instance.hp -= (PlayerStatus.instance.maxHP/20) * Time.deltaTime;
            }
        }
    }
}
