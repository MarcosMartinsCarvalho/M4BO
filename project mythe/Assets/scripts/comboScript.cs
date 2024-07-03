using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class comboScript : MonoBehaviour
{
    [SerializeField] private int currentCombo;
    [SerializeField] public int missCount;
    [SerializeField] private int highestCombo;
    [SerializeField] private TextMeshPro combotext;
    [SerializeField] private TextMeshPro misscounttext;

    void Start()
    {
        currentCombo = 0;
        highestCombo = 0;
    }

    void Update()
    {
        combotext.text = currentCombo.ToString();
        misscounttext.text = missCount.ToString();

    }

    public void IncreaseCombo()
    {
        currentCombo++;
        if (currentCombo > highestCombo)
        {
            highestCombo = currentCombo;
        }
    }

    public void ResetCombo()
    {
        currentCombo = 0;
    }
}
