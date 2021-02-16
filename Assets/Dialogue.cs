using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dialogue component to easily edit what is said by who and when.
[System.Serializable]
public class Dialogue
{
    
    public Dialogue[] days;
    [TextArea(3,10)]
    public string[] sentences;
    public string name;
    public Sprite profile;

}
