using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDoor : MonoBehaviour
{
    public GameObject interactButton;
    // private Animator anim;

    void Start()
    {
        // anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactButton.SetActive(false);
        }
    }

    private void Update()
    {
        // if (interactButton.activeSelf && Input.GetKeyDown(KeyCode.E))
        // {
        //     // Set animator parameter isRunning to true
        //     // if (anim != null)
        //     // {
        //     //     anim.SetBool("isOpening", true);
        //     // }
        //         Debug.Log("main animasi");

        //     // interactButton.SetActive(false);

        //     // // Matikan collider
        //     // Collider2D collider = GetComponent<Collider2D>();
        //     // if (collider != null)
        //     // {
        //     //     collider.enabled = false;
        //     // }

        //     // Tambahkan logika pembukaan di sini
        //     // Misalnya, aktifkan animasi pembukaan atau lakukan tindakan tertentu.
        // }
    }
}
