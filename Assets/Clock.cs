using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    public Text correct;
    public Text incorrect;
    public Text money;
    public Animator panel;
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
    public Sprite colonG;
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
    public Sprite colonR;
    public Image colon;
    public Image hour1;
    public Image hour2;
    public Image min1;
    public Image min2;
    private float timer = 0f;
    private float min;
    private float hour;
    private bool runningOut = false;
    private string scene = "Home";
    public BoxManager box;
    bool moneyChanged;
    public Text reas;
    public Text expenses;
    public Text over;
    float prevMoney = 0f;

    // Start is called before the first frame update
    void Start()
    {
        moneyChanged = false;
        BoxManager box = new BoxManager();
        hour = GameData.Hour;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        min = Mathf.Floor(timer*2 % 60);
        hour = Mathf.Floor(timer/30 % 24) + 9;

        if (runningOut)
        {
            colon.sprite = colonR;
            switch (min % 10)
            {
                case 0:
                    min2.sprite = zeroR;
                    break;
                case 1:
                    min2.sprite = oneR;
                    break;
                case 2:
                    min2.sprite = twoR;
                    break;
                case 3:
                    min2.sprite = threeR;
                    break;
                case 4:
                    min2.sprite = fourR;
                    break;
                case 5:
                    min2.sprite = fiveR;
                    break;
                case 6:
                    min2.sprite = sixR;
                    break;
                case 7:
                    min2.sprite = sevenR;
                    break;
                case 8:
                    min2.sprite = eightR;
                    break;
                case 9:
                    min2.sprite = nineR;
                    break;
            }
            switch (Mathf.Floor(min / 10))
            {
                case 0:
                    min1.sprite = zeroR;
                    break;
                case 1:
                    min1.sprite = oneR;
                    break;
                case 2:
                    min1.sprite = twoR;
                    break;
                case 3:
                    min1.sprite = threeR;
                    break;
                case 4:
                    min1.sprite = fourR;
                    break;
                case 5:
                    min1.sprite = fiveR;
                    break;
            }
            switch (hour % 10)
            {
                case 0:
                    hour2.sprite = zeroR;
                    break;
                case 1:
                    hour2.sprite = oneR;
                    break;
                case 2:
                    hour2.sprite = twoR;
                    break;
                case 3:
                    hour2.sprite = threeR;
                    break;
                case 4:
                    hour2.sprite = fourR;
                    break;
                case 5:
                    hour2.sprite = fiveR;
                    break;
                case 6:
                    hour2.sprite = sixR;
                    break;
                case 7:
                    hour2.sprite = sevenR;
                    break;
                case 8:
                    hour2.sprite = eightR;
                    break;
                case 9:
                    hour2.sprite = nineR;
                    break;
            }
            switch (Mathf.Floor(hour / 10))
            {
                case 0:
                    hour1.sprite = zeroR;
                    break;
                case 1:
                    hour1.sprite = oneR;
                    break;
                case 2:
                    hour1.sprite = twoR;
                    break;
            }
        }
        else
        {
            colon.sprite = colonG;
            switch (min%10)
            {
                case 0:
                    min2.sprite = zeroG;
                    break;
                case 1:
                    min2.sprite = oneG;
                    break;
                case 2:
                    min2.sprite = twoG;
                    break;
                case 3:
                    min2.sprite = threeG;
                    break;
                case 4:
                    min2.sprite = fourG;
                    break;
                case 5:
                    min2.sprite = fiveG;
                    break;
                case 6:
                    min2.sprite = sixG;
                    break;
                case 7:
                    min2.sprite = sevenG;
                    break;
                case 8:
                    min2.sprite = eightG;
                    break;
                case 9:
                    min2.sprite = nineG;
                    break;
            }
            switch (Mathf.Floor(min / 10))
            {
                case 0:
                    min1.sprite = zeroG;
                    break;
                case 1:
                    min1.sprite = oneG;
                    break;
                case 2:
                    min1.sprite = twoG;
                    break;
                case 3:
                    min1.sprite = threeG;
                    break;
                case 4:
                    min1.sprite = fourG;
                    break;
                case 5:
                    min1.sprite = fiveG;
                    break;
            }switch (hour%10)
            {
                case 0:
                    hour2.sprite = zeroG;
                    break;
                case 1:
                    hour2.sprite = oneG;
                    break;
                case 2:
                    hour2.sprite = twoG;
                    break;
                case 3:
                    hour2.sprite = threeG;
                    break;
                case 4:
                    hour2.sprite = fourG;
                    break;
                case 5:
                    hour2.sprite = fiveG;
                    break;
                case 6:
                    hour2.sprite = sixG;
                    break;
                case 7:
                    hour2.sprite = sevenG;
                    break;
                case 8:
                    hour2.sprite = eightG;
                    break;
                case 9:
                    hour2.sprite = nineG;
                    break;
            }
            switch (Mathf.Floor(hour / 10))
            {
                case 0:
                    hour1.sprite = zeroG;
                    break;
                case 1:
                    hour1.sprite = oneG;
                    break;
                case 2:
                    hour1.sprite = twoG;
                    break;
            }
        }
        if(hour == 16 && (min == 0 || min == 2 || min == 4))
        {
            runningOut = true;
        }
        else
        {
            runningOut = false;
        }
        if(hour == 17)
        {
            GetMoney();

            Debug.Log("out of time");
            StartCoroutine(LoadScene());
        }
    }

    void GetMoney()
    {
        if (!moneyChanged)
        {
            prevMoney = GameData.money;
        }
        correct.text = "Correct boxes sent: " + box.correct;
        incorrect.text = "Incorrect boxes sent: " + box.incorrect;
        if (GameData.isill)
        {
            if (GameData.incorrect != 0)
            {
                expenses.text = "Expenses: \n Rent -$25 \n Medicine -$5  \n End of day bonus +$50";
                money.text = "$" + prevMoney + " + $" + box.correct * 10 + " - $" + box.incorrect * 5 + " - $25 - $5 + $50" + "\n = $" + GameData.money;
                if (!moneyChanged)
                {
                    GameData.money = GameData.money + ((box.correct * 10 - box.incorrect * 5) + 20);
                    moneyChanged = true;
                }
                if (GameData.money < 0)
                {
                    GameData.dayswomedicine += 1;
                    GameData.daysnprent += 1;
                }
                else
                {
                    GameData.dayswomedicine = 0;
                    GameData.daysnprent = 0;
                }
            }
            else if (GameData.incorrect == 0)
            {
                expenses.text = "Expenses: \n Rent -$25 \n Medicine -$5  \n End of day bonus +$50 \n No mistakes bonus + $15";
                money.text = "$" + prevMoney + " + $" + box.correct * 10 + " - $" + box.incorrect * 5 + " - $25 - $5 + $50 + $15" + "\n = $" + GameData.money;
                if (!moneyChanged)
                {
                    GameData.money = GameData.money + ((box.correct * 10 - box.incorrect * 5) + 35);
                    moneyChanged = true;
                }
                if (GameData.money < 0)
                {
                    GameData.dayswomedicine += 1;
                    GameData.daysnprent += 1;
                }
                else
                {
                    GameData.dayswomedicine = 0;
                    GameData.daysnprent = 0;
                }
            }
        }
        else if (GameData.incorrect == 0)
        {
            if (GameData.incorrect != 0)
            {
                expenses.text = "Expenses: \n Rent -$25 \n End of day bonus +$50";
                money.text = "$" + prevMoney + " + $" + box.correct * 10 + " - $" + box.incorrect * 5 + " - $25 + $50" + "\n = $" + GameData.money;
                if (!moneyChanged)
                {
                    GameData.money = GameData.money + ((box.correct * 10 - box.incorrect * 5) + 25);
                    moneyChanged = true;
                }
                if (GameData.money < 0)
                {
                    GameData.daysnprent += 1;
                }
                else
                {
                    GameData.daysnprent = 0;
                }
            }
            else
            {
                expenses.text = "Expenses: \n Rent -$25 \n End of day bonus +$50 \n No mistakes bonus +$15";
                money.text = "$" + prevMoney + " + $" + box.correct * 10 + " - $" + box.incorrect * 5 + " - $25 + $50 + $15" + "\n = $" + GameData.money;
                if (!moneyChanged)
                {
                    GameData.money = GameData.money + ((box.correct * 10 - box.incorrect * 5) + 40);
                    moneyChanged = true;
                }
                if (GameData.money < 0)
                {
                    GameData.daysnprent += 1;
                }
                else
                {
                    GameData.daysnprent = 0;
                }
            }
        }
    }

    IEnumerator LoadScene()
    {
        if (GameData.day == 7)
        {
            over.text = "Congratulations";
            reas.text = "you've made it and been furloughed for now \n Press space to play again";
            yield return new WaitForSeconds(2f);
            panel.SetTrigger("Over");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameData.firstload = false;
                GameData.firstloadhouse = false;
                SceneManager.LoadScene("Warehouse Floor", LoadSceneMode.Single);
            }
        }
        else if (GameData.daysnprent > 3)
        {
            over.text = "GameOver";
            reas.text = "you've not paid rent for too long \n Press space to retry";
            yield return new WaitForSeconds(2f);
            panel.SetTrigger("Over");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameData.firstload = false;
                GameData.firstloadhouse = false;
                SceneManager.LoadScene("Warehouse Floor", LoadSceneMode.Single);
            }
        }
        else if (GameData.dayswomedicine > 3)
        {
            over.text = "GameOver";
            reas.text = "you've been sick for too long \n Press space to retry";
            yield return new WaitForSeconds(2f);
            panel.SetTrigger("Over");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameData.firstload = false;
                GameData.firstloadhouse = false;
                SceneManager.LoadScene("Warehouse Floor", LoadSceneMode.Single);
            }
        }
        else if (GameData.dayswofood > 3)
        {
            over.text = "GameOver";
            reas.text = "You've not eaten for days and are too weak to work \n Press space to retry";
            yield return new WaitForSeconds(2f);
            panel.SetTrigger("Over");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameData.firstload = false;
                GameData.firstloadhouse = false;
                SceneManager.LoadScene("Warehouse Floor", LoadSceneMode.Single);
            }
        }
        else
        {

            yield return new WaitForSeconds(4f);
            panel.SetTrigger("end");
            yield return new WaitForSeconds(9.8f);
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
