using UnityEngine;

public class JudgementScript : MonoBehaviour
{
    [SerializeField] private Transform object2;
    [SerializeField] private float judgement1; // Set default values if necessary
    [SerializeField] private float judgement2;
    [SerializeField] private float judgement3;
    [SerializeField] private float judgement4;
    private HealthManager Manager;

    private void Start()
    {
        // Find the HealthManager script in the scene
        Manager = FindObjectOfType<HealthManager>();
        

        
    }

    private void Update()
    {
        

        // Calculate the x-distance between the objects
        float xDistance = Mathf.Abs(transform.position.x - object2.position.x);

        // Check if the x-distance is within certain thresholds and print corresponding messages
        if (xDistance <= judgement1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Manager.Heal(10f);
            }

        }
        else if (xDistance <= judgement2)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Manager.Heal(5f);

            }

        }
        else if (xDistance <= judgement3)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Manager.TakeDamage(3f);

            }

        }
        else if (xDistance <= judgement4)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("missed");
                Manager.TakeDamage(35f);
            }
        }
    }
}
