using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float startDuration = 3f;
    private float elapsedTime = 0f;
    public GameState currentState;

    public GameObject[] notePrefabs;
    public float xMin = -5f;
    public float xMax = 5f;
    public float yPosition = 0f;
    [SerializeField] private GameObject metronome;
    [SerializeField] private GameObject music;

    public enum GameState
    {
        Starting,
        Paused,
        Playing,
        GameOver,
        End
    }

    void Start()
    {
        SetGameState(GameState.Starting);
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.Starting:
                elapsedTime += Time.deltaTime;
                metronome.SetActive(true);

                if (elapsedTime >= startDuration)
                {
                    metronome.SetActive(false);
                    StartGame();
                }
                break;

            case GameState.Playing:
                // Add gameplay logic here
                break;

            case GameState.GameOver:
                HandleGameOver();
                metronome.SetActive(false);
                break;

            case GameState.End:
                // Handle end state if needed

                Debug.Log("Game Ended");
                metronome.SetActive(false);
                break;
        }
    }

    public void SetGameState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Game State Changed to: " + newState);
    }

    void StartGame()
    {
        music.SetActive(true);
        SetGameState(GameState.Playing);
        Debug.Log("Game Started");
    }

    void HandleGameOver()
    {
        music.SetActive(false);
        
    }

    public void TriggerGameOver()
    {
        SetGameState(GameState.GameOver);
    }

    public void SpawnNotes(int noteIndex)
    {
        float xPos = Random.Range(xMin, xMax);
        Vector3 spawnPosition = new Vector3(xPos, yPosition, 0f);
        Instantiate(notePrefabs[noteIndex], spawnPosition, Quaternion.identity);
    }
}
