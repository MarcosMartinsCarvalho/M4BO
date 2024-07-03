using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] private int bpm;

    private AudioSource audioSource;
    private float interval;
    private float timer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        
    }

    void Update()
    {
        interval = 60f / bpm;
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            audioSource.Play();
            timer = interval;
        }
    }
}
