using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_004 : MonoBehaviour //ThornTrap
{
    public AudioClip soundThornTrap;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ThornTrap");
            if (PlayerStatus.instance != null)
            {
                PlayerStatus.instance._audioSource.PlayOneShot(soundThornTrap);
                PlayerStatus.instance.hp -= 20 * Time.deltaTime;
            }
        }
    }
}
