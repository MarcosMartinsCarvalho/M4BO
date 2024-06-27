//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class movement : MonoBehaviour
//{
//   [SerializeField] private Transform pointA;         // Point A
//   [SerializeField] private Transform pointB;         // Point B
//   [SerializeField] private float speed = 10f;       // Initial speed of the object
//   [SerializeField] private bool movingToB = true;   // Flag to determine direction of movement
//   [SerializeField] private int timingcount = 0;     // Variable to count direction changes
//   [SerializeField] private float timingcount1;
//                    private SpriteRenderer HitobjectColor; // the object prop
//   [SerializeField] private Color FastColor;
//   [SerializeField] private Color SlowColor; // color of the object if if speed goes above if statement
//                    private TrailRenderer SpeedTrail; // trail when its going fast




//    // list of timings that make the object go faster
//    List<int> timeIntervals = new List<int>()
//    {2000, 93, 91, 89, 84, 85, 85, 122, 55, 76, 90, 92, 71, 89, 80, 82, 89, 82, 89, 79, 95, 93, 93, 72, 82, 72, 98, 74, 98, 65, 96, 65, 97, 72, 102, 104, 70, 60, 101, 65, 96, 66, 100, 60, 98, 66, 104, 56, 110, 96, 75, 43, 112, 48, 110, 53, 106, 55, 109, 52, 111, 51, 98, 62, 125, 40, 111, 76, 98, 48, 111, 62, 109, 63, 105, 60, 112, 128, 42, 59, 107, 58, 106, 78, 98, 63, 111, 52, 120, 45, 119, 136, 46, 35, 137, 26, 155, 21, 156, 1, 316, 365, 301, 316, 715, 417, 488, 475, 484, 586, 179, 151, 190, 164, 354, 131, 195, 131, 190, 514, 464, 513, 445, 470, 544, 553, 357, 179, 146, 380, 137, 156, 153, 159, 320, 401, 1, 316, 305, 151, 134, 151, 151, 151, 135, 157, 149, 147, 150, 142, 152, 145, 152, 145, 153, 146, 144, 142, 155, 283, 145, 155, 161, 151, 199, 110, 158, 148, 144, 221, 114, 66, 134, 72, 62, 69, 88, 89, 74, 102, 69, 114, 55, 134, 33, 137, 138, 56, 42, 140, 28, 145, 19, 149, 8, 164, 4, 150, 24, 133, 92, 64, 101, 65, 112, 56, 125, 44, 151, 10, 175, 3, 177, 78, 66, 70, 99, 95, 78, 107, 58, 114, 33, 141, 11, 143, 319, 148, 291, 336, 174, 152, 162, 302, 165, 171, 303, 322, 164, 371, 398, 161, 165, 296, 172, 158, 145, 578, 369, 309, 326, 325, 302, 337, 330, 359, 293, 356, 312, 297, 345, 406, 1861, 731, 161, 167, 311, 201, 174, 376, 158, 377, 184, 184, 165, 150, 261, 156, 154, 311, 306, 347, 361, 653, 170, 160, 308, 352, 145, 295, 152, 331, 158, 341, 161, 342, 149, 179, 133, 160, 304, 335, 369, 587, 447, 145, 291, 144, 422, 153, 371, 351, 157, 159, 165, 222, 165, 163, 299, 267, 331, 332, 660, 151, 153, 427, 224, 154, 329, 140, 373, 271, 166, 159, 421, 127, 155, 159, 151, 294, 322, 364, 164, 136, 140, 110, 54, 155, 82, 106, 87, 89, 112, 80, 125, 66, 126, 81, 146, 62, 112, 65, 134, 60, 141, 67, 137, 76, 133, 60, 154, 52, 147, 102, 114, 83, 120, 73, 127, 55, 132, 85, 123, 65, 114, 79, 108, 72, 139, 53, 125, 48, 131, 40, 161, 55, 143, 40, 122, 75, 97, 107, 100, 98, 101, 110, 94, 108, 97, 106, 91, 105, 89, 106, 80, 95, 80, 108, 78, 102, 82, 104, 79, 103, 77, 112, 71, 109, 70, 103, 110, 69, 82, 93, 81, 98, 80, 99, 113, 111, 108, 103, 146, 338, 692, 1252, 617, 698, 613, 350, 288, 318, 337, 351, 323, 336, 338, 310, 350, 347, 295, 327, 166, 150, 330, 312, 366, 333, 282, 346, 328, 177, 117, 304, 159, 149, 287, 374, 373, 326, 341, 309, 291, 149, 173, 350, 274, 316, 321, 484, 471, 495, 541, 339, 306, 151, 168, 277, 346, 152, 176, 337, 336, 323, 167, 141, 310, 319, 316, 138, 182, 129, 205, 139, 201, 349, 173, 164, 179, 149, 198, 129, 287, 157, 182, 143, 240, 70, 155, 348, 177, 191, 186, 141, 180, 125, 181, 161, 134, 142, 144, 167, 136, 115, 225, 179, 112, 273, 312, 95, 102, 85, 105, 88, 111, 89, 97, 88, 109, 92, 105, 88, 105, 88, 105, 81, 102, 104, 65, 84, 85, 77, 103, 84, 101, 82, 111, 88, 113, 104, 104, 97, 97, 97, 110, 81, 102, 84, 98, 91, 115, 481, 331, 321, 86, 101, 120, 86, 105, 100, 116, 120, 84, 107, 181, 138, 94, 83, 105, 87, 138, 209, 103, 93, 85, 98, 149, 133, 109, 90, 121, 101, 121, 93, 116, 94, 105, 104, 110, 76, 107, 87, 156, 283, 315, 331, 446, 180, 145, 162, 156, 159, 150, 146, 151, 260, 310, 329, 470, 156, 162, 155, 178, 167, 202, 112, 327, 329, 392, 276, 312, 175, 166, 196, 131, 162, 144, 329, 350, 312, 157, 173, 337, 185, 146, 154, 163, 155, 154, 297, 318, 344, 98, 128, 112, 100, 168, 59, 346, 99, 95, 100, 86, 155, 113, 320, 133, 184, 326, 105, 139, 48, 89, 133, 125, 188, 98, 93, 82, 84, 84, 95, 77, 147, 352, 98, 198, 194, 176, 181, 181, 167, 151, 167, 265, 150, 160, 177, 284, 202, 173, 172, 176, 172, 159, 184, 170, 166, 144, 257, 161, 163, 333, 139, 168, 151, 177, 275, 342, 170, 158, 155, 126, 314, 355, 152, 168, 170, 156, 171, 180, 169, 183, 189, 149, 176, 118, 287, 334, 317, 377, 148, 174, 181, 181, 138, 128, 162, 136, 129, 179, 138, 203, 142, 180, 149, 152, 166, 149, 159, 132, 173, 173, 130, 177, 131, 150, 137, 117, 124, 116, 84, 229, 76, 100, 100, 76, 237, 76, 74, 209, 63, 70, 254, 70, 84, 139, 54, 90, 245, 26, 315, 76, 219, 60, 87, 128, 50, 77, 112, 109, 43, 83, 86, 114, 55, 87, 164, 42, 97, 241, 20, 49, 66, 94, 352, 289, 53, 110, 135, 49, 70, 190, 64, 102, 91, 111, 88, 63, 174, 151, 0, 163, 37, 92, 101, 74, 57, 54, 240, 108, 89, 146, 68, 75, 85, 72, 78, 75, 101, 81, 88, 85, 203, 329, 296, 333, 270, 279, 353, 329, 344, 348, 337, 342, 322, 386, 308, 311, 511, 32, 31
//    };
//        void Start()
//    {
        
//        SpeedTrail = GetComponent<TrailRenderer>();
//        HitobjectColor = GetComponent<SpriteRenderer>();


//        // Set the initial delay for the first movement
//        if (timeIntervals.Count > 0)
//        {
//            float firstMovementTime = timeIntervals[0] / 1000f; // Convert milliseconds to seconds
//            Invoke("ChangeDirection", firstMovementTime);
//        }
//    }

//    // Function to change the direction of movement after a delay
//     void ChangeDirection()
//    {

//        // Change direction
//        movingToB = !movingToB;

//        // Increment timing count


//        // Check if timing count is within the bounds of the timeIntervals list
//        if (timingcount < timeIntervals.Count)

//        {
            
//            timingcount++;
//            // Get the time interval for the next movement
//            float nextMovementTime = timeIntervals[timingcount] / 1000f; // Convert milliseconds to seconds

//            // Set the delay for the next movement
//            Invoke("ChangeDirection", nextMovementTime);
//        }

//        // Adjust speed based on the new timing count

//    }


//    void Update()
//    {
//        // change collor if object is going faster than (insert speed) :)

//        if(speed >= 40)
//        {
//            SpeedTrail.enabled = true;
//            HitobjectColor.color = FastColor;
//        }
//        else if (speed <= 40)
//        {
//            HitobjectColor.color = SlowColor;
//            SpeedTrail.enabled = false;
//        }
        

//        // Check if the object is moving towards point B
//        if (movingToB)
//        {
//            MoveTowards(pointB);
//        }
//        else // Otherwise, move towards point A
//        {
//            MoveTowards(pointA);
//        }

//        // calculation for the speed and assign it after
//        timingcount1 = 10000 / timeIntervals[timingcount];
//        speed = timingcount1;
//    }

//    // Function to move the object towards a target point
//    void MoveTowards(Transform targetPoint)
//    {
//        // Calculate the distance to the target point
//        float step = speed * Time.deltaTime;
//        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
//    }

    
//}




