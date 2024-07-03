using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private int timingcount;
    [SerializeField] private int timingcount1;
    [SerializeField] private Sprite CoinSprite1;
    [SerializeField] private Sprite CoinSprite2;
    [SerializeField] private comboScript combo;
    private GameManager gameManager;
    private bool movingToB = true;
    private float speed;

    [SerializeField] private GameObject winscreen;

    List<int> timeIntervals = new List<int>()
    {
        630,500,333,167,500,500,500,333,1084,416,334,250,500,333,167,500,500,583,500,417,416,167,417,333,250,417,500,583,417,500,333,167,500,500,500,500,1083,500,333,250,417,500,500,333,1000,584,333,167,583,417,166,500,417,833,500,417,167,500,500,500,166,334,1000,666,334,583,500,833,1084,500,416,250,417,333,167,417,500,1000,416,417,167,416,417,167,500,583,917,416,417,167,500,416,167,417,416,1084,500,416,167,500,417,1083,1000,500,333,167,417,416,167,417,500,1000,500,416,167,500,417,583,417,1083,500,333,167,417,500,583,417,1083,500,333,167,417,500,
     };

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        float firstMovementTime = timeIntervals[0] / 1000f; // Convert milliseconds to seconds
        Invoke("ChangeDirection", firstMovementTime);
    }

    void ChangeDirection()
    {
        if (gameManager.currentState == GameManager.GameState.Playing)
        {
            // Change direction
            movingToB = !movingToB;

            // Increment timing count
            if (timingcount < timeIntervals.Count - 1) // Make sure we don't go out of bounds
            {
                timingcount++;
                // Get the time interval for the next movement

                float nextMovementTime = timeIntervals[timingcount] / 1000f; // Convert milliseconds to seconds

                // Set the delay for the next movement
                Invoke("ChangeDirection", nextMovementTime);


            }
            else if (timingcount <= timeIntervals.Count - 1)
            {
                if (combo.missCount <= 10)
                {
                    gameManager.SetGameState(GameManager.GameState.End);
                    winscreen.SetActive(true);

                }
                else
                {
                    gameManager.SetGameState(GameManager.GameState.GameOver);
                }

            
                
            }
        }
        else
        {
            // If the game state is not Playing check again after a short interval
            Invoke("ChangeDirection", 0.1f);
        }
    }

    void Update()
    {
        

        if (gameManager.currentState == GameManager.GameState.Playing)
        {
            if (movingToB)
            {
                MoveTowards(pointB);
                GetComponent<SpriteRenderer>().sprite = CoinSprite1;
            }
            else
            {
                MoveTowards(pointA);
                GetComponent<SpriteRenderer>().sprite = CoinSprite2;
            }

            timingcount1 = 10000 / timeIntervals[timingcount];
            speed = timingcount1;
        }
    }

    void MoveTowards(Transform targetPoint)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
    }
}
