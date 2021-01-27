using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using Bogus;



public class Phone : MonoBehaviour
{
    public Animator panel;
    private string scene = "Warehouse Floor";
    
    public Text text;

    private List<Sprite> bed = new List<Sprite>();
    private List<Sprite> coffee = new List<Sprite>();
    private List<Sprite> fridge = new List<Sprite>();
    private List<Sprite> mask = new List<Sprite>();

    private List<float> bCost = new List<float>();
    private List<float> cCost = new List<float>();
    private List<float> fCost = new List<float>();
    private List<float> mCost = new List<float>();
    
    private List<float> Bbonus = new List<float>();
    private List<float> Cbonus = new List<float>();
    private List<float> Fbonus = new List<float>();
    private List<float> Mbonus = new List<float>();

    private float BedBonus = 10f;
    private float BedBonus1 = 25f;
    private float BedBonus2 = 50f;    
    private float BikeBonus = 20f;
    private float CoffeeBonus = 5f;
    private float CoffeeBonus1 = 10f;
    private float CoffeeBonus2 = 15f;
    private float FridgeBonus = 20f;
    private float FridgeBonus1 = 30f;
    private float FridgeBonus2 = 50f;
    private float MaskBonus = 25;
    private float MaskBonus1 = 50;
    private float MaskBonus2 = 75;
    private float MaskBonus3 = 100;

    public float money = 100f;
   
    public float maxFood = 100f;
    public float food;

    private float Bed1C = 75;
    private float Bed2C = 150;
    private float Bed3C = 200;
    private float AlarmC = 50;
    private float Coffee1C = 75;
    private float Coffee2C = 125;
    private float Coffee3C = 150;
    private float Fridge1C = 90;
    private float Fridge2C = 120;
    private float Fridge3C = 150;
    private float BikeC = 200;
    private float FoodC = 20;
    private float Mask1C = 55;
    private float Mask2C = 80;
    private float Mask3C = 100;
    private float Mask4C = 125;

    private int B;
    private int F;
    private int C;
    private int M;

    public Sprite bed1;
    public Sprite bed2;
    public Sprite bed3;
    public Sprite alarm;
    public Sprite coffee1;
    public Sprite coffee2;
    public Sprite coffee3;
    public Sprite fridge1;
    public Sprite fridge2;
    public Sprite fridge3;
    public Sprite bike;
    public Sprite mask4;
    public Sprite mask1;
    public Sprite mask2;
    public Sprite mask3;


    public Text m;

    public Slider stock;

    public GameObject BikeGO;
    public GameObject FridgeGO;
    public GameObject BedGO;
    public GameObject CoffeeGO;
    public GameObject AlarmGO;
    public GameObject MaskGO;
    
    public SpriteRenderer BikeSprite;
    public SpriteRenderer FridgeSprite;
    public SpriteRenderer BedSprite;
    public SpriteRenderer CoffeeSprite;
    public SpriteRenderer AlarmSprite;

    private bool hasAlarm;
    private bool hasBike;

    public AudioSource door;
    public AudioSource buy;

    // Start is called before the first frame update
    void Start()
    {
        money = GameData.money;
        GameData.Maxenergy = 100f;
        Debug.Log(GameData.firstloadhouse);
        if (!GameData.firstloadhouse)
        {
            GameData.energy = 100f;
            GameData.food = 50f;
            GameData.firstloadhouse = true;

            GameData.maxfood = 150;
            GameData.b = 0;
            GameData.f = 0;
            GameData.c = 0;
            GameData.m = 0;

            B = 0;
            F = 0;
            C = 0;
            M = 0;

            GameData.ase = false;
            GameData.bse = false;
            GameData.bese = false;
            GameData.cse = false;
            GameData.fse = false;

            bed.Add(bed1);
            bed.Add(bed2);
            bed.Add(bed3);
            coffee.Add(coffee1);
            coffee.Add(coffee2);
            coffee.Add(coffee3);

            fridge.Add(fridge1);
            fridge.Add(fridge2);
            fridge.Add(fridge3);

            bCost.Add(Bed1C);
            bCost.Add(Bed2C);
            bCost.Add(Bed3C);
            cCost.Add(Coffee1C);
            cCost.Add(Coffee2C);
            cCost.Add(Coffee3C);
            fCost.Add(Fridge1C);
            fCost.Add(Fridge2C);
            fCost.Add(Fridge3C);
            mask.Add(mask1);
            mask.Add(mask2);
            mask.Add(mask3);
            mask.Add(mask4);

            mCost.Add(Mask1C);
            mCost.Add(Mask2C);
            mCost.Add(Mask3C);
            mCost.Add(Mask4C);

            Mbonus.Add(MaskBonus);
            Mbonus.Add(MaskBonus1);
            Mbonus.Add(MaskBonus2);
            Mbonus.Add(MaskBonus3);


            Bbonus.Add(BedBonus);
            Bbonus.Add(BedBonus1);
            Bbonus.Add(BedBonus2);


            Cbonus.Add(CoffeeBonus);
            Cbonus.Add(CoffeeBonus1);
            Cbonus.Add(CoffeeBonus2);

            Fbonus.Add(FridgeBonus);
            Fbonus.Add(FridgeBonus1);
            Fbonus.Add(FridgeBonus2);

            maxFood = GameData.maxfood;
            food = GameData.food;
            stock.maxValue = maxFood;
            text.text = "Day: " + GameData.day;

            B = GameData.b;
            F = GameData.f;
            C = GameData.c;
            M = GameData.m;

        }
        else
        {
            bed.Add(bed1);
            bed.Add(bed2);
            bed.Add(bed3);
            coffee.Add(coffee1);
            coffee.Add(coffee2);
            coffee.Add(coffee3);

            fridge.Add(fridge1);
            fridge.Add(fridge2);
            fridge.Add(fridge3);

            bCost.Add(Bed1C);
            bCost.Add(Bed2C);
            bCost.Add(Bed3C);
            cCost.Add(Coffee1C);
            cCost.Add(Coffee2C);
            cCost.Add(Coffee3C);
            fCost.Add(Fridge1C);
            fCost.Add(Fridge2C);
            fCost.Add(Fridge3C);
            mask.Add(mask1);
            mask.Add(mask2);
            mask.Add(mask3);
            mask.Add(mask4);

            mCost.Add(Mask1C);
            mCost.Add(Mask2C);
            mCost.Add(Mask3C);
            mCost.Add(Mask4C);

            Mbonus.Add(MaskBonus);
            Mbonus.Add(MaskBonus1);
            Mbonus.Add(MaskBonus2);
            Mbonus.Add(MaskBonus3);


            Bbonus.Add(BedBonus);
            Bbonus.Add(BedBonus1);
            Bbonus.Add(BedBonus2);


            Cbonus.Add(CoffeeBonus);
            Cbonus.Add(CoffeeBonus1);
            Cbonus.Add(CoffeeBonus2);

            Fbonus.Add(FridgeBonus);
            Fbonus.Add(FridgeBonus1);
            Fbonus.Add(FridgeBonus2);

            GameData.food = GameData.food - (70 - Fbonus[F]);
            maxFood = GameData.maxfood;
            food = GameData.food;
            stock.maxValue = maxFood;
            text.text = "Day: " + GameData.day;

            B = GameData.b;
            F = GameData.f;
            C = GameData.c;
            M = GameData.m;
            if(GameData.food < 0)
            {
                GameData.food = 0;
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        AlarmSprite.enabled = GameData.ase;
        BikeSprite.enabled = GameData.bse;
        CoffeeSprite.enabled = GameData.cse;
        FridgeSprite.enabled = GameData.fse;
        BedSprite.enabled = GameData.bese;


        GameData.b = B;
        GameData.f = F;
        GameData.c = C;
        GameData.m = M;
        stock.value = food;

        GameData.money = money;
        GameData.maxfood = maxFood;
        GameData.food = food;
        

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                UpdatePhone(hit);
            }
        }

        m.text = "$" + money;
        if (FridgeGO != null && F <= 2)
        {
            foreach (Transform child in FridgeGO.transform)
            {
                if (child.name == "Icon")
                {
                    
                    Image sprite = child.GetComponent<Image>();
                    sprite.sprite = fridge[F];
                }
                if (child.name == "Description")
                {
                    
                    Text text = child.GetComponent<Text>();
                    text.text = "Increase fridge capacity (+" + Fbonus[F] + "% energy)";
                }
                if (child.name == "Price")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "$" + fCost[F];
                }
            }
            foreach (Transform child in MaskGO.transform)
            {
                if (child.name == "Icon")
                {
                    
                    Image sprite = child.GetComponent<Image>();
                    sprite.sprite = mask[M];
                }
                if (child.name == "Description")
                {
                    
                    Text text = child.GetComponent<Text>();
                    text.text = "Mask to protect you from disease (+" + Mbonus[M] + "% resistance)";
                }
                if (child.name == "Price")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "$" + mCost[M];
                }
            }
        }
        if (BedGO != null && B <= 2)
        {
            foreach (Transform child in BedGO.transform)
            {
                if (child.name == "Icon")
                {
                    Image sprite = child.GetComponent<Image>();
                    sprite.sprite = bed[B];
                }
                if (child.name == "Description")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "Upgrade bed for a better night sleep (+" + Bbonus[B] + "% energy)";
                }
                if (child.name == "Price")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "$" + bCost[B];
                }
            }
        }
        if (CoffeeGO != null && C <= 2)
        {
            foreach (Transform child in CoffeeGO.transform)
            {
                if (child.name == "Icon")
                {
                    Image sprite = child.GetComponent<Image>();
                    sprite.sprite = coffee[C];
                }
                if (child.name == "Description")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "Coffee machine to pep you up (+" + Cbonus[C] + "% energy)";
                }
                if (child.name == "Price")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "$" + cCost[C];
                }
            }
        }
        if (BikeGO != null)
        {
            foreach (Transform child in BikeGO.transform)
            {
                if (child.name == "Description")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "Exercise bike to improve your stamina (+" + BikeBonus + "% energy)";
                }
                if (child.name == "Price")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "$" + BikeC;
                }
            }
        }
        if (AlarmGO != null)
        {
            foreach (Transform child in AlarmGO.transform)
            {
                if (child.name == "Description")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "Alarm clock to make sure you're up at the right time";
                }
                if (child.name == "Price")
                {
                    Text text = child.GetComponent<Text>();
                    text.text = "$" + AlarmC;
                }
            }
        }

    }

    public void UpdatePhone(RaycastHit2D hit)
    {
        var c = hit.collider;
        var x = c.transform.parent.gameObject.name;
        switch (x)
        {
            case ("Alarm"):
                if (AlarmC <= money)
                {
                    buy.Play();
                    hasAlarm = true;
                    money -= AlarmC;
                    GameData.ase = true;
                    Destroy(AlarmGO);
                }
                break;

            case ("ExerciseBike"):
                if (money >= BikeC)
                {
                    buy.Play();
                    hasBike = true;
                    money -= BikeC;
                    GameData.bse = true;
                    Destroy(BikeGO);
                }
                break;
                
            case ("Fridge"):

                if (money >= fCost[F])
                {
                    buy.Play();

                    GameData.fse = true;
                    FridgeSprite.sprite = fridge[F];
                    money -= fCost[F];
                    F += 1;
                    maxFood += Fbonus[F];
                }
                if (F == 3)
                {
                    Destroy(FridgeGO);
                }
                break;

            case ("Bed"):
                if (money >= bCost[B])
                {
                    buy.Play();
                    GameData.bese = true;
                    BedSprite.sprite = bed[B];
                    money -= bCost[B];
                    B += 1;
                }
                if (B == 3)
                {
                    Destroy(BedGO);
                }
                break;

            case ("Coffee"):
                if (money >= cCost[C])
                {

                    buy.Play();
                    GameData.cse = true;
                    CoffeeSprite.sprite = coffee[C];
                    money -= cCost[C];
                    C += 1;
                    
                }
                if (C == 3)
                {
                    Destroy(CoffeeGO);
                }
                break;
            case ("Mask"):
                if (money >= mCost[M])
                {
                    buy.Play();
                    money -= mCost[M];
                    M += 1;
                    GameData.hasmask = true;
                    
                }
                if (M == 4)
                {
                    Destroy(MaskGO);
                }
                break;
            case ("Food"):
                if (FoodC <= money && (GameData.food+40) < GameData.maxfood)
                {
                    buy.Play();
                    money -= FoodC;
                    food += 40;
                }
                break;
        }



        if(hit.collider.gameObject.name == "Door")
        {
            if (GameData.food > 0)
            {
                GameData.dayswofood = 0;
            }
            if(GameData.day >= 3)
            {
                var random = new Bogus.Randomizer();
                int num = random.Number(1, 4);
                if(num == 1)
                {
                    GameData.isill = true;
                }
            }
            else
            {
                GameData.isill = false;
            }
            door.Play();
            CalculateEnergy();
            if (!hasAlarm)
            {
                var random = new Bogus.Randomizer();
                int num = random.Number(1, 4 - GameData.m);
                if(num == 1)
                {
                    GameData.hour = 12;
                    GameData.energy = GameData.Maxenergy;
                    GameData.late = true;
                }
                else
                {
                    GameData.hour = 9;
                    GameData.energy = GameData.Maxenergy * 0.8f;
                    GameData.late = false;
                }
            }
            else
            {
                GameData.hour = 9;
                GameData.energy = GameData.Maxenergy * 0.8f;
                GameData.late = false;
            }
            GameData.day = GameData.day + 1;
            GameData.b = B;
            GameData.f = F;
            GameData.c = C;
            GameData.m = M;
            StartCoroutine(LoadScene());

        }
    }

    public void CalculateEnergy()
    {
        if (hasBike)
        {
            float Cb = (Cbonus[C] + 100f) / 100f;
            float Bb = (Bbonus[B] + 100f) / 100f;
            float bonus = ((Cb + Bb) + 100) / (2 + GameData.dayswofood);
            GameData.Maxenergy = GameData.Maxenergy * bonus;
        }
        else
        {
            float Cb = (Cbonus[C] + 100f) / 100f;
            float Bb = (Bbonus[B] + 100f) / 100f;
            GameData.maxenergy = GameData.maxenergy * (Cb + Bb)/2 + GameData.dayswofood;

            Debug.Log(GameData.maxenergy);
        }
        if (GameData.isill)
        {
            float illbonus = 0.8f;
            GameData.maxenergy = GameData.maxenergy * illbonus;
        }
    }


    IEnumerator LoadScene()
    {

        if (scene == "Warehouse Floor")
        {
            if (GameData.isill)
            {
                text.text = "Day: " + (GameData.day + 1) + "\n Not feeling very well today hope I get better soon";

            }
            else if (GameData.food >= 0)
            {
                GameData.dayswofood += 1;
                text.text = "Day: " + (GameData.day + 1) + "\n God I'm hungry I'll try get food tomorrow";

            }
            else
            {
                text.text = "Day: " + (GameData.day + 1);

            }
            panel.SetTrigger("end");
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
