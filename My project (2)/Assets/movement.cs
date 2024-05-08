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
        {400, 298, 301, 292, 312, 313, 302, 260, 288, 256, 302, 305, 322, 286, 292, 294, 288, 316, 309, 290, 317, 321, 294, 270, 338, 172, 116, 274, 309, 280, 314, 292, 578, 331, 318, 282, 303, 314, 276, 259, 336, 284, 289, 280, 314, 300, 351, 149, 547, 233, 311, 280, 283, 308, 315, 271, 296, 295, 294, 280, 307, 320, 367, 279, 298, 291, 304, 271, 230, 86, 290, 279, 347, 297, 183, 107, 281, 283, 284, 314, 324, 292, 305, 128, 102, 346, 304, 279, 288, 330, 611, 71, 195, 113, 275, 278, 291, 271, 317, 287, 307, 116, 299, 277, 261, 297, 254, 291, 310, 333, 198, 338, 317, 314, 303, 287, 548, 119, 126, 446, 149, 125, 325, 315, 261, 569, 243, 93, 313, 299, 294, 1092, 688, 649, 312, 607, 305, 248, 179, 153, 268, 299, 343, 304, 554, 563, 584, 599, 625, 57, 264, 126, 319, 381, 1237, 363, 347, 285, 314, 185, 227, 133, 360, 327, 285, 554, 307, 295, 323, 506, 317, 274, 296, 370, 74, 100, 158, 331, 81, 91, 89, 303, 264, 275, 301, 313, 281, 310, 634, 594, 604, 516, 669, 589, 621, 619, 572, 505, 558, 666, 593, 312, 299, 327, 325, 304, 322, 613, 0, 254, 309, 579, 283, 287, 575, 324, 327, 331, 304, 268, 314, 555, 273, 330, 569, 262, 296, 719, 275, 298, 303, 277, 215, 131, 117, 657, 401, 318, 581, 266, 304, 651, 274, 283, 335, 313, 296, 336, 588, 248, 239, 150, 523, 257, 210, 790, 221, 241, 129, 284, 324, 267, 340, 542, 313, 287, 210, 360, 342, 266, 527, 132, 209, 114, 203, 331, 310, 978, 635, 285, 210, 245, 295, 279, 578, 176, 181, 156, 178, 322, 295, 225, 61, 111, 65, 87, 133, 310, 299, 237, 331, 239, 295, 299, 305, 296, 269, 141, 128, 222, 403, 302, 300, 812, 384, 362, 279, 230, 104, 279, 275, 583, 127, 176, 166, 164, 300, 270, 1066, 1381, 1082, 2430, 2318, 2515
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




