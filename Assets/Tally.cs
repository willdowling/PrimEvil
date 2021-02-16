using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tally : MonoBehaviour
{
    public Sprite zeroG;
    public Sprite oneG;
    public Sprite twoG;
    public Sprite threeG;
    public Sprite fourG;
    public Sprite fiveG;
    public Sprite sixG;
    public Sprite sevenG;
    public Sprite eightG;
    public Sprite nineG;
    public Sprite zeroR;
    public Sprite oneR;
    public Sprite twoR;
    public Sprite threeR;
    public Sprite fourR;
    public Sprite fiveR;
    public Sprite sixR;
    public Sprite sevenR;
    public Sprite eightR;
    public Sprite nineR;


    public Image correct1;
    public Image correct2;
    public Image wrong;

    public BoxManager tally;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Nightmarish clock solution to update the sprite each time the digit changes
    void FixedUpdate()
    {
        switch (tally.incorrect % 10)
        {
            case 0:
                wrong.sprite = zeroR;
                break;
            case 1:
                wrong.sprite = oneR;
                break;
            case 2:
                wrong.sprite = twoR;
                break;
            case 3:
                wrong.sprite = threeR;
                break;
            case 4:
                wrong.sprite = fourR;
                break;
            case 5:
                wrong.sprite = fiveR;
                break;
            case 6:
                wrong.sprite = sixR;
                break;
            case 7:
                wrong.sprite = sevenR;
                break;
            case 8:
                wrong.sprite = eightR;
                break;
            case 9:
                wrong.sprite = nineR;
                break;
        }switch (tally.correct % 10)
        {
            case 0:
                correct2.sprite = zeroG;
                break;
            case 1:
                correct2.sprite = oneG;
                break;
            case 2:
                correct2.sprite = twoG;
                break;
            case 3:
                correct2.sprite = threeG;
                break;
            case 4:
                correct2.sprite = fourG;
                break;
            case 5:
                correct2.sprite = fiveG;
                break;
            case 6:
                correct2.sprite = sixG;
                break;
            case 7:
                correct2.sprite = sevenG;
                break;
            case 8:
                correct2.sprite = eightG;
                break;
            case 9:
                correct2.sprite = nineG;
                break;
        }switch (Mathf.Floor(tally.correct/10))
        {
            case 0:
                correct1.sprite = zeroG;
                break;
            case 1:
                correct1.sprite = oneG;
                break;
            case 2:
                correct1.sprite = twoG;
                break;
            case 3:
                correct1.sprite = threeG;
                break;
            case 4:
                correct1.sprite = fourG;
                break;
            case 5:
                correct1.sprite = fiveG;
                break;
            case 6:
                correct1.sprite = sixG;
                break;
            case 7:
                correct1.sprite = sevenG;
                break;
            case 8:
                correct1.sprite = eightG;
                break;
            case 9:
                correct1.sprite = nineG;
                break;
        }
    }
}
