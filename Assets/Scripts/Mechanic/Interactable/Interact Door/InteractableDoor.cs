using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactButton;
    private Animator anim;
    public AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactButton.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactButton.SetActive(false);
        }
    }

    private void Update()
    {
        if (interactButton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            // Set animator parameter isRunning to true
            if (anim != null)
            {
                anim.SetBool("isOpening", true);
                audioSource.Play();
            }

            interactButton.SetActive(false);

            // Matikan collider
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            // Tambahkan logika pembukaan di sini
            // Misalnya, aktifkan animasi pembukaan atau lakukan tindakan tertentu.
        }
    }
}
