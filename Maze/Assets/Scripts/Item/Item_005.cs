using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_005 : MonoBehaviour //explosiveTrap
{
    [SerializeField] GameObject particleFX;
    [SerializeField] GameObject[] explosivePart;

    [SerializeField] float radius = 2f;
    [SerializeField] float force = 10f;

    public bool isActive = false;

    // void Update()
    // {
    //     if (isActive)
    //     {
    //         StartCoroutine(DelaySpawn());
    //     }
    // }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObj in colliders)
        {
            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        // Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isActive = true;
            Debug.Log("Explosive");

            // Explode();

            if (PlayerStatus.instance != null)
            {
                PlayerStatus.instance.hp -= 50;
            }

            foreach (var part in explosivePart)
            {
                part.SetActive(false);
            }

            particleFX.SetActive(true);
            // Destroy(this.gameObject, 2);

            StartCoroutine(DelaySpawn());
        }
    }

    // IEnumerator DelaySetActive()
    // {
    //     yield return new WaitForSeconds(2);
    //     isActive = true;
    //     // gameObject.SetActive(false);
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         isActive = false;
    //         StartCoroutine(DelaySpawn());
    //     }
    // }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(30);
        foreach (var part in explosivePart)
        {
            part.SetActive(true);
        }
        // gameObject.SetActive(true);
    }
}
