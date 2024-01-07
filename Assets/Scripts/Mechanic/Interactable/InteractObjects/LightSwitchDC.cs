using UnityEngine;

public class LightSwitchDC : MonoBehaviour
{
    public GameObject[] lamps;
    public GameObject interactButton;
    // public AudioClip switchOnSound;
    private int currentLampIndex = 0;
    public AudioSource audioSource;
    public AudioClip interactSound;  // Tambahkan AudioClip interactSound

    void Start()
    {
        interactButton.SetActive(false);
        SetLampState(false);
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
        SetLampState(!lamps[currentLampIndex].activeSelf);
        currentLampIndex = (currentLampIndex + 1) % lamps.Length;

        // Memainkan suara interactSound pada AudioSource
        if (audioSource != null && interactSound != null)
        {
            audioSource.PlayOneShot(interactSound);
        }
    }

    void SetLampState(bool state)
    {
        foreach (var lamp in lamps)
        {
            lamp.SetActive(state);
        }
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
