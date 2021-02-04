using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_manager : MonoBehaviour
{
    public Text correct;
    public Text incorrect;
    public Text expenses;
    public Text money;
    public Text over;
    public Text reas;
    public float maxenergy;
    public float energy;
    public float piss = 0f;
    private float maxpiss = 100f;
    public float pissed = 0f;
    public GameObject pisser;
    public Water2D.Water2D_Spawner water;
    private bool pissing = false;
    public StatsMeter meter;
    public BoxManager box;
    private string scene = "Home";
    public Animator panel;
    public Animator player;
    AudioSource snd;
    public AudioSource end;
    bool playSound = true;
    float prevMoney = 0f;
    bool moneyChanged;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameData.firstload);
        moneyChanged = false;
        snd = GetComponent<AudioSource>();
        if (!GameData.firstload)
        {
            energy = 100f;
            maxenergy = 100f;
            GameData.firstload = true;
            GameData.day = 0;
            GameData.money = 50f;
            GameData.coworker = true;
            panel.SetTrigger("start");
        }
        else
        {
            energy = GameData.energy;
            maxenergy = GameData.maxenergy;
        }

        BoxManager box = new BoxManager();

        Water2D.Water2D_Spawner.instance.Restore();
        Water2D.Water2D_Spawner.instance.initSpeed = new Vector2(-3, 3);
        meter.SetMaxEnergy(maxenergy);
        meter.SetMaxBladder(maxpiss);
        if (GameData.hasmask)
        {
            player.SetBool("Masked", true);
        }
    }

        // Update is called once per frame
    void FixedUpdate()
    {
        
        energy -= 0.01f;
        if (!pissing)
        {
            piss += .02f;
            Water2D.Water2D_Spawner.instance.Restore();
            Water2D.Water2D_Spawner.instance.initSpeed = new Vector2(-3, 3);
        }
        else
        {
            StartPiss();
        }

        if (piss >= 100f)
        {
            pissing = true;
        }

        if (piss <= 0)
        {
            pissing = false;
        }
        meter.SetEnergy(energy);
        meter.SetBladder(piss);

        if (energy <= 0)
        {
            if (playSound)
            {
                snd.Play();
                playSound = false;
            }
            GetMoney();
            StartCoroutine(LoadScene());
        }
    }

    public void StartPiss()
    {
        Water2D.Water2D_Spawner.instance.Start();
        float height = 3f * Mathf.PerlinNoise(Time.time * 1f, 0.0f);
        Vector3 pos = pisser.transform.position;
        pos.y = height;
        pisser.transform.position = pos;

        float x = -8f * Mathf.PerlinNoise(Time.time * 2f, 0.0f);
        float y = 8f * Mathf.PerlinNoise(Time.time * 2f, 0.0f);
        x -= 1;

        Water2D.Water2D_Spawner.instance.initSpeed = new Vector2(x, y);
        piss -= .5f;
        
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
            else if(GameData.incorrect == 0)
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
            else if(GameData.incorrect == 0)
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
            player.SetTrigger("PassOut");
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
            player.SetTrigger("PassOut");
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
            player.SetTrigger("PassOut");
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

            player.SetTrigger("PassOut");
            panel.SetTrigger("end");
            yield return new WaitForSeconds(9.8f);
            SceneManager.LoadScene(scene, LoadSceneMode.Single);

        }
    }

}
