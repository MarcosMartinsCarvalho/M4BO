using UnityEngine;

public class ScaleBasedOnDistance : MonoBehaviour
{
    public Transform target; // The target object to measure the distance from
    public float minSize = 0.5f; // Minimum size for the object
    public float maxSize = 2.0f; // Maximum size for the object
    public float maxDistance = 10.0f; // Maximum distance at which the object is at min size

    private void Update()
    {
        

        // Calculate the distance between this object and the target
        float distance = Vector3.Distance(transform.position, target.position);

        // Calculate the size based on the distance
        float sizeFactor = Mathf.Clamp((maxDistance + distance) / maxDistance, minSize, maxSize);

        // Set the size of the object
        transform.localScale = new Vector3(sizeFactor, sizeFactor, sizeFactor);
    }
}
