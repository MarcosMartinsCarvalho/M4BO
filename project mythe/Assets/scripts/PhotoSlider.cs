using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhotoSlider : MonoBehaviour
{
    public GameObject ChoiceBar;
    public Image displayImage;
    public Sprite[] photos;
    private int currentIndex = 0;
    int choice;

    void Start()
    {
        if (photos.Length > 0)
        {
            displayImage.sprite = photos[currentIndex];
            ChoiceBar = GetComponent<GameObject>();
        }
        
    }
    public void ShowNextPhoto()
    {
        choice++;
        currentIndex++;
        if (currentIndex >= photos.Length)
        {
            currentIndex = 0;
        }
        displayImage.sprite = photos[currentIndex];

        if (choice >= 5)
        {
            NextChoice();
        }
    }
    public void ShowPreviousPhoto()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = photos.Length - 1;
        }
        displayImage.sprite = photos[currentIndex];
    }

    public void NextChoice()
    {
        ChoiceBar.SetActive(true);
    }
}