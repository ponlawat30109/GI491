using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_002 : MonoBehaviour //Medkit
{
    public AudioClip soundMedKit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You got 1 MedKit");
            if (PlayerStatus.instance != null)
            {
                GameManager.instance._audioSource.PlayOneShot(soundMedKit);
                PlayerStatus.instance.medKit += 1;
            }

            Destroy(gameObject);
        }
    }
}
