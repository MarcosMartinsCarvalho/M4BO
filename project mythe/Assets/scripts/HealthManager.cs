using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthAmount = 100;
    [SerializeField] private GameObject failScreen;
    public GameManager gameManager;

    private float currentHealthAmount;
    private float lerpSpeed = 5f;

    void Start()
    {
        currentHealthAmount = healthAmount;
        failScreen.SetActive(false);
    }

    void Update()
    {
        currentHealthAmount = Mathf.Lerp(currentHealthAmount, healthAmount, lerpSpeed * Time.deltaTime);
        healthBar.fillAmount = currentHealthAmount / 100;

        if (healthAmount < 1 && gameManager.currentState == GameManager.GameState.Playing)
        {
            gameManager.TriggerGameOver();
            failScreen.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
    }

    public void Heal(float healAmount)
    {
        healthAmount += healAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }
}
