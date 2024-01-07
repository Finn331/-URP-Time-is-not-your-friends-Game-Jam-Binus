using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    private bool Interacted = false;
    private bool isInRange = false;  // Tambahkan variabel isInRange
    public GameObject interactButton;
    private Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1);
    public GameObject targetObject;

    void Start()
    {
        z_Collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);

        // Reset the interaction state on each frame
        Interacted = false;

        foreach (var o in z_CollidedObjects)
        {
            OnCollided(o.gameObject);
        }

        // Check if the player is in range before processing "E" key input
        if (isInRange && Input.GetKey(KeyCode.E) && !Interacted)
        {
            OnInteract();
            StartCoroutine(DeactivateAfterDuration());
        }
    }

    private void OnCollided(GameObject collidedObject)
    {
        
        if (collidedObject.tag == "Player")
        {
            interactButton.SetActive(true);
            // Set isInRange to true when the player is in range
            isInRange = true;
        }
    }

    public void OnInteract()
    {
        Interacted = true;
        Debug.Log("INTERACT WITH " + name);
    }

    IEnumerator DeactivateAfterDuration()
    {
        targetObject.SetActive(true);
        // Wait for the activation duration
        yield return new WaitForSeconds(3f);
        targetObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactButton.SetActive(false);
            targetObject.SetActive(false);
            // Reset isInRange to false when the player exits the collider
            isInRange = false;
        }
    }
}
