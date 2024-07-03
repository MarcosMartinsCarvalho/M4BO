using UnityEngine;

public class ScaleBasedOnDistance : MonoBehaviour
{
    public Transform target; // The target object to measure the distance from
    public float minSize = 0.5f; // Minimum size for the object
    public float maxSize = 2.0f; // Maximum size for the object
    public float maxDistance = 10.0f; // Maximum distance at which the object is at min size
    public AudioClip soundClip; // Sound clip to play when object is at min size
    public AudioSource audioSource; // Reference to the audio source component
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // Ensure the audio source is assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

    }

    private void Update()
    {
        if (audioSource == null || soundClip == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        // Calculate size factor based on distance
        float sizeFactor = Mathf.Lerp(maxSize, minSize, distance / maxDistance);
        sizeFactor = Mathf.Clamp(sizeFactor, minSize, maxSize);

        // Set the size of the object
        transform.localScale = new Vector3(sizeFactor, sizeFactor, sizeFactor);

        // Play sound if the size is at its minimum
        if (Mathf.Approximately(sizeFactor, maxSize)) {

            if (gameManager.currentState == GameManager.GameState.Playing)
            {
                PlaySound();
            }
        }
    }

    private void PlaySound()
    {
        if (gameManager.currentState == GameManager.GameState.Playing)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundClip;
                audioSource.Play();
            }
        }
        
    }
}
