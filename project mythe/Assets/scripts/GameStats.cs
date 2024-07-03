using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] private int CurrentCombo;
    [SerializeField] private int HighestCombo;
    [SerializeField] private int AmountMissed;
    private HealthManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
