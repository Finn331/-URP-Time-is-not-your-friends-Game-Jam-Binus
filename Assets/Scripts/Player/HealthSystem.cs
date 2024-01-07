using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Basement Trigger")]
    public GameObject basementEnter, basementExit;

    [Header("Healing Potion")]
    public GameObject[] healthPotion;

    [Header("Health System")]
    public int maxHealth = 70;
    private int currentHealth;

    public Slider healthSlider; // Reference to the TextMeshPro component for displaying health

    public GameObject gameoverObject;

    private void Start()
    {
        // Basement Trigger Intial
        basementExit.SetActive(false);
        basementEnter.SetActive(true);

        // Array for Healing Potion
        healthPotion = new GameObject[3];
        healthPotion[0] = GameObject.Find("Health Potion 1");
        healthPotion[1] = GameObject.Find("Health Potion 2");
        healthPotion[2] = GameObject.Find("Health Potion 3");

        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            UpdateHealthText();
        }

        //StartCoroutine(ReduceHealthOverTime());
    }

    private IEnumerator ReduceHealthOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait for 10 seconds

            // Reduce health by 1 every minute
            TakeDamage(1);

        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthText(); // Update the displayed health text

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeHeal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 1, maxHealth);

        UpdateHealthText();
        Debug.Log("Healed");
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add any additional actions upon death
        gameoverObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void UpdateHealthText()
    {
        if (healthSlider != null)
        {
            // Calculate the health percentage (0 to 1) and set the slider value
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Basement")
        {
            StartCoroutine("ReduceHealthOverTime");
            basementEnter.SetActive(false);
            basementExit.SetActive(true);
        }
        else if (collision.tag == "BasementExit")
        {
            StopCoroutine("ReduceHealthOverTime");
            basementEnter.SetActive(true);
            basementExit.SetActive(false);
        }

        if (collision.tag == "Heal")
        {
            if (collision.gameObject.name == "Health Potion 1")
            {
                // Your logic to handle the effect of picking up Health Potion 1
                // For example, increase health or perform other actions
                TakeHeal(10);

                // Destroy the specific "Health Potion 1" object
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name == "Health Potion 2")
            {
                // Your logic to handle the effect of picking up Health Potion 1
                // For example, increase health or perform other actions
                TakeHeal(10);

                // Destroy the specific "Health Potion 1" object
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name == "Health Potion 3")
            {
                // Your logic to handle the effect of picking up Health Potion 1
                // For example, increase health or perform other actions
                TakeHeal(10);

                // Destroy the specific "Health Potion 1" object
                Destroy(collision.gameObject);
            }
        }
    }



}