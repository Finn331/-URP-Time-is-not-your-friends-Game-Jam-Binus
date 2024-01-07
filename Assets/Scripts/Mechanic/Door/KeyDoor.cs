using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject Door;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Key Pickedup");

            Door.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
