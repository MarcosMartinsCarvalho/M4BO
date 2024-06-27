using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    private PhotoSlider photoslider;
    void Start()
    {
        photoslider = GetComponent<PhotoSlider>();
    }
}
