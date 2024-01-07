using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lampu;
    public GameObject interactButton;

    void Start()
    {
        interactButton.SetActive(false);
        lampu.SetActive(false);
    }

    void Update()
    {
        if (interactButton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            ToggleLamp();
        }
    }

    void ToggleLamp()
    {
        lampu.SetActive(!lampu.activeSelf);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactButton.SetActive(false);
        }
    }
}
