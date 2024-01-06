using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lampu;
    private bool isLightOn = true;
    public GameObject interactButton;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleLight();
        }
    }

    public void ToggleLight()
    {
        // Ubah status lampu berdasarkan kondisi sebelumnya
        isLightOn = !isLightOn;
        Debug.Log("Lampu Hidup");

        // Aktifkan atau nonaktifkan lampu berdasarkan status
        lampu.SetActive(isLightOn);
        Debug.Log("Lampu Mati");
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
}
