using UnityEngine;

public class noteMoveDown : MonoBehaviour
{

    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float despawnTime = 3f;
    [SerializeField] private float timer;

    void Start()
    {
        timer = 0f;
    }
    void Update()
    {

        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= despawnTime)
        {

            Destroy(gameObject);
        }
    }
}