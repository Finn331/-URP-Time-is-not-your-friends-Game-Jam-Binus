using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip walkingSound;
    public Transform footTransform;

    private AudioSource audioSource;

    private Vector3 lastPosition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        // Check for player input to determine if walking
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            PlayFootstepSound(walkingSound);
        }
        else if (IsPlayerStationary())
        {
            // Player is stationary, stop the footstep sound
            audioSource.Stop();
        }
    }

    private void PlayFootstepSound(AudioClip footstepSound)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = footstepSound;
            audioSource.Play();
        }
    }

    private bool IsPlayerStationary()
    {
        // Check if the player is not moving by comparing current position with the last position
        return transform.position == lastPosition;
    }
}
