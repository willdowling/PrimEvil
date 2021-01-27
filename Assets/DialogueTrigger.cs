using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public BoxManager box;
    public Player_manager player;
    public Animator panel;
    public string scene = "Home";


    public Text correct;
    public Text incorrect;
    public Text expenses;
    public Text money;
    public Text over;

    float prevMoney = 0f;
    
    public Text Continue;

    private bool bad1;
    private bool bad2;
    private bool bad3;
    private bool bad4;

    public string og;
    public string reason;

    public GameObject dBox;
    public GameObject gameInfo;

    public bool c = true;

    public bool space;
    bool moneyChanged;
    public Text reas;

    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue.days[GameData.day]);
    }

    void Start()
    {
        moneyChanged = false;
        og = Continue.text;
        bad1 = false;
        bad2 = false;
        bad3 = false;
        bad4 = false;
        space = false;
        Debug.Log(GameData.day);
        TriggerDialogue();
        if (GameData.day == 3  && !c)
        {
            GameData.coworker = false;
        }
    }

    public void Update()
    {
        if (box.incorrect == 8 && !bad1)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue.days[7]);
            bad1 = true;
        }
        if (player.pissed > 500 && !bad2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue.days[8]);
            bad2 = true;
        }
        if (GameData.late && !bad3)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue.days[9]);
            bad3 = true;
            TriggerDialogue();
        }
        if (box.c==8 && !bad4)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue.days[11]);
            bad4 = true;
            TriggerDialogue();
        }

        if ((box.incorrect == 9 || player.pissed > 600 || box.c==10) && !space)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue.days[10]);

            GetMoney();
            space = true;
            StartCoroutine(LoadScene());
        }

        if (GameData.day == 2 && !space)
        {
            Continue.text = "y for yes, n for no";
            if (Input.GetKeyDown("y"))
            {
                if (GameData.money >= 50)
                {
                    space = true;

                    Continue.text = "Press Space to continue";
                    GameData.money -= 50f;
                    GameData.comask = true;
                    TriggerBranch(0);
                }
                else
                {
                    TriggerBranch(2);
                    space = true;
                }
                
            }
            if (Input.GetKeyDown("n"))
            {
                space = true;

                Continue.text = "Press Space to continue";
                TriggerBranch(1);
                c = false;
            }
        }

        if (GameData.day == 3 && !space)
        {
            if (GameData.comask)
            {
                TriggerBranch(0);
                space = true;
            }
            else
            {
                TriggerBranch(1);
                space = true;
                GameData.coworker = false;
            }
        }if (GameData.day == 4 && !space)
        {
            if (!GameData.coworker)
            {
                TriggerBranch(0);
                space = true;
            }
            else
            {
                TriggerBranch(1);
                space = true;
            }
        }if (GameData.day == 5 && !space)
        {
            if (!GameData.coworker)
            {
                TriggerBranch(0);
                space = true;
            }
            else
            {
                TriggerBranch(1);
                space = true;
            }
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
                expenses.text = "Expenses: \n Rent -$25 \n Medicine -$5";
                money.text = "$" + prevMoney + " + $" + box.correct * 10 + " - $" + box.incorrect * 5 + " - $25 - $5" + "\n = $" + GameData.money;
                if (!moneyChanged)
                {
                    GameData.money = GameData.money + ((box.correct * 10 - box.incorrect * 5) - 30);
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
                expenses.text = "Expenses: \n Rent -$25 \n Medicine -$5 \n No mistakes bonus + $15";
                money.text = "$" + prevMoney + " + $" + box.correct * 10 + " - $" + box.incorrect * 5 + " - $25 - $5 + $15" + "\n = $" + GameData.money;
                if (!moneyChanged)
                {
                    GameData.money = GameData.money + ((box.correct * 10 - box.incorrect * 5) - 15);
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
        else
        {
            Debug.Log(GameData.incorrect);
            if (GameData.incorrect != 0)
            {
                expenses.text = "Expenses: \n Rent -$25";
                money.text = "$" + prevMoney + " + $" + box.correct * 10 + " - $" + box.incorrect * 5 + " - $25" + "\n = $" + GameData.money;
                if (!moneyChanged)
                {
                    GameData.money = GameData.money + ((box.correct * 10 - box.incorrect * 5) - 25);
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
            else if (GameData.incorrect == 0)
            {
                expenses.text = "Expenses: \n Rent -$25 \n No mistakes bonus +$15";
                money.text = "$" + prevMoney + " + $" + box.correct * 10 + " - $" + box.incorrect * 5 + " - $25 + $15" + "\n = $" + GameData.money;
                if (!moneyChanged)
                {
                    GameData.money = GameData.money + ((box.correct * 10 - box.incorrect * 5) - 10);
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

    void TriggerBranch(int n)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue.days[GameData.day].days[n]);
        dBox.SetActive(true);
        gameInfo.SetActive(false);
    }
}
