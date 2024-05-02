using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
   [SerializeField] private Transform pointA;         // Point A
   [SerializeField] private Transform pointB;         // Point B
   [SerializeField] private float speed = 10f;       // Initial speed of the object
   [SerializeField] private bool movingToB = true;   // Flag to determine direction of movement
   [SerializeField] private int timingcount = 0;     // Variable to count direction changes
   [SerializeField] private float timingcount1;
   [SerializeField] private AudioSource kickback; // audio...
                    private SpriteRenderer HitobjectColor; // the object prop
   [SerializeField] private Color FastColor;
   [SerializeField] private Color SlowColor; // color of the object if if speed goes above if statement
                    private TrailRenderer SpeedTrail; // trail when its going fast
   


    // list of timings that make the object go faster
    List<int> timeIntervals = new List<int>()
        {
           1000,
441,
588,
441,
294,
589,
441,
588,
735,
589,
441,
588,
294,
294,
588,
441,
735,
588,
588,
147,
294,
294,
294,
294,
294,
294,
294,
294,
441,
147,
294,
294,
294,
294,
294,
441,
147,
294,
294,
294,
294,
294,
294,
147,
441,
441,
147,
294,
294,
294,
294,
294,
147,
294,
294,
294,
294,
294,
294,
294,
441,
441,
147,
294,
294,
294,
441,
441,
147,
294,
294,
294,
294,
294,
441,
147,
294,
294,
294,
294,
294,
294,
147,
441,
441,
294,
294,
294,
147,
441,
441,
294,
294,
294,
147,
441,
441,
147,
294,
294,
294,
294,
294,
294,
147,
441,
441,
147,
294,
294,
294,
441,
441,
147,
294,
294,
294,
147,
441,
441,
147,
294,
294,
294,
294,
294,
441,
147,
294,
294,
294,
294,
294,
294,
294,
294,
441,
441,
147,
294,
294,
294,
294,
294,
294,
294,
294,
294,
147,
294,
294,
294,
294,
294,
147,
441,
441,
294,
294,
294,
294,
294,
147,
441,
147,
294,
294,
294,
441,
441,
294,
294,
294,
294,
294,
147,
441,
147,
294,
294,
294,
294,
294,
294,
147,
441,
441,
294,
294,
294,
147,
441,
441,
294,
294,
294,
147,
441,
441,
294,
294,
294,
147,
441,
441,
294,
294,
294,
147,
441,
441,
294,
294,
294,
147,
441,
441,
147,
294,
294,
294,
147,
294,
294,
147,
294,
294,
147,
294,
294,
147,
294,
441,

        };

    void Start()
    {
        SpeedTrail = GetComponent<TrailRenderer>();
        HitobjectColor = GetComponent<SpriteRenderer>();


        // Set the initial delay for the first movement
        if (timeIntervals.Count > 0)
        {
            float firstMovementTime = timeIntervals[0] / 1000f; // Convert milliseconds to seconds
            Invoke("ChangeDirection", firstMovementTime);
        }
    }

    // Function to change the direction of movement after a delay
    void ChangeDirection()
    {
        
        // Change direction
        movingToB = !movingToB;

        // Increment timing count
        

        // Check if timing count is within the bounds of the timeIntervals list
        if (timingcount < timeIntervals.Count)
        {
            timingcount++;
            // Get the time interval for the next movement
            float nextMovementTime = timeIntervals[timingcount] / 1000f; // Convert milliseconds to seconds

            // Set the delay for the next movement
            Invoke("ChangeDirection", nextMovementTime);
        }

        // Adjust speed based on the new timing count
        
    }

    void Update()
    {
        // change collor if object is going faster than (insert speed) :)

        if(speed >= 40)
        {
            SpeedTrail.enabled = true;
            HitobjectColor.color = FastColor;
        }
        else if (speed <= 40)
        {
            HitobjectColor.color = SlowColor;
            SpeedTrail.enabled = false;
        }
        

        // Check if the object is moving towards point B
        if (movingToB)
        {
            MoveTowards(pointB);
        }
        else // Otherwise, move towards point A
        {
            MoveTowards(pointA);
        }

        // calculation for the speed and assign it after
        timingcount1 = 10000 / timeIntervals[timingcount];
        speed = timingcount1;
    }

    // Function to move the object towards a target point
    void MoveTowards(Transform targetPoint)
    {
        // Calculate the distance to the target point
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
    }

    
}




