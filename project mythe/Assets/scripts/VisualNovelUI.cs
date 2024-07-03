using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VisualNovelUI : MonoBehaviour
{
    private int index;
    [SerializeField] private VisualNovelText[] visualnovels;

    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;

    [SerializeField] private TMP_Text Option1;
    [SerializeField] private TMP_Text Option2;
    [SerializeField] private TMP_Text Option3;

    [SerializeField] private TMP_Text TChar;
    [SerializeField] private TMP_Text text;
    

    [SerializeField] private Image BackGround;
    [SerializeField] private Image Scroll;

    //Robin
    [SerializeField] private Image BodyR;
    [SerializeField] private Image EyesR;
    [SerializeField] private Image MouthR;
    [SerializeField] private Image OtherR;

    //Harold
    [SerializeField] private Image BodyH;
    [SerializeField] private Image EyesH;
    [SerializeField] private Image MouthH;
    [SerializeField] private Image OtherH;

    //Guy
    [SerializeField] private Image BodyG;
    [SerializeField] private Image EyesG;
    [SerializeField] private Image MouthG;
    [SerializeField] private Image OtherG;

    //Npc
    [SerializeField] private Image BodyNpc;
    [SerializeField] private Image HairNpc;
    [SerializeField] private Image FaceNpc;
    private void Start()
    {
        RenderVN();
    }

    public void Next()
    {
        if (visualnovels[index].next >= 0)
        {
            index = visualnovels[index].next;
        }
        
        else if(visualnovels[index].next == -2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            index++;
        }
        RenderVN();
    }

    public void Previous() 
    {
        if (visualnovels[index].prev >= 0)
        {
            index = visualnovels[index].prev;
        }
        else
        {
            index--;
        }

        RenderVN();
    }

    private void RenderVN()
    {
        text.text = visualnovels[index].text;
        TChar.text = visualnovels[index].TChar;

        if (visualnovels[index].Option1 == "")
        {
            button1.SetActive(false);
        }
        else
        {
            button1.SetActive(true);
            Option1.text = visualnovels[index].Option1;
        }

        if (visualnovels[index].Option2 == "")
        {
            button2.SetActive(false);
        }
        else
        {
            button2.SetActive(true);
            Option2.text = visualnovels[index].Option2;
        }

        if (visualnovels[index].Option3 == "")
        {
            button3.SetActive(false);
        }
        else
        {
            button3.SetActive(true);
            Option3.text = visualnovels[index].Option3;
        }

        BackGround.sprite = visualnovels[index].Background;
        Scroll.sprite = visualnovels[index].Scroll;

        BodyR.sprite = visualnovels[index].BodyR;
        EyesR.sprite = visualnovels[index].EyesR;
        MouthR.sprite = visualnovels[index].MouthR;
        OtherR.sprite = visualnovels[index].OtherR;

        BodyH.sprite = visualnovels[index].BodyH;
        EyesH.sprite = visualnovels[index].EyesH;
        MouthH.sprite = visualnovels[index].MouthH;
        OtherH.sprite = visualnovels[index].OtherH;

        BodyG.sprite = visualnovels[index].BodyG;
        EyesG.sprite = visualnovels[index].EyesG;
        MouthG.sprite = visualnovels[index].MouthG;
        OtherG.sprite = visualnovels[index].OtherG;

        BodyNpc.sprite = visualnovels[index].BodyNpc;
        HairNpc.sprite = visualnovels[index].HairNpc;
        FaceNpc.sprite = visualnovels[index].FaceNpc;
    }

    public void choiceButton(int buttonIndex)
    {
        index = visualnovels[index].choices[buttonIndex];
        RenderVN();
    }

    public void SkipVN1()
    {
        SceneManager.LoadScene("gameplay1");
    }
    public void SkipVN2()
    {
        SceneManager.LoadScene("gameplay2");
    }
    public void SkipVN3()
    {
        SceneManager.LoadScene("gameplay3");
    }
}
