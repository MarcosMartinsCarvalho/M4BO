using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/VisualNovelText")]
public class VisualNovelText : ScriptableObject 
{
    public Sprite Background;
    public Sprite Scroll;

    //Robin
    public Sprite BodyR;
    public Sprite EyesR;
    public Sprite MouthR;
    public Sprite OtherR;

    //Harold
    public Sprite BodyH;
    public Sprite EyesH;
    public Sprite MouthH;
    public Sprite OtherH;

    //Guy
    public Sprite BodyG;
    public Sprite EyesG;
    public Sprite MouthG;
    public Sprite OtherG;

    //Npc
    public Sprite BodyNpc;
    public Sprite HairNpc;
    public Sprite FaceNpc;

    public string TChar;
    public string text;

    public string Option1;
    public string Option2;
    public string Option3;

    public int[] choices = new int[3];

    //next/previous override
    public int next = -1;
    public int prev = -1;
}