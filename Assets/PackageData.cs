using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bogus;

public class PackageData : MonoBehaviour
{
    public bool isAnimated = true;
    public bool grabbed = false;
    public bool accepted;
    public bool reject;
    public Vector3 pos;
    public string zip;
    public int ID;
    public string address;
    public string name;
    public string item;
    public string zipA;
    public int IDA;
    public string addressA;
    public string nameA;
    public string itemA;
    public bool isSmall = true;
    public GameObject box;
    public GameObject Small_box;
    public GameObject Big_box;
    public Sprite b;
    public Sprite b1;
    public Sprite b2;
    public Sprite b3;
    public bool coworker;


    // Start is called before the first frame update
    public void Start()
    {
        //When initialized must determine what game flags are so certain types of boxes can be spawned

        box = Small_box;
        var random = new Bogus.Randomizer();
        int num = random.Number(1, 2);
        if (num == 1 && !coworker)
        {
            pos = new Vector3(9.5f, 9f, 0f);
        }
        else if(num == 2 && !coworker)
        {
            pos = new Vector3(11.5f, 9f, 0f);
        }
        else if (coworker)
        {
            //if the coworker is missing spawn a box on his line
            pos = new Vector3(-15f, 1.8f, 0f);
        }
        num = random.Number(1, 2);
        GeneratePackage();

        GenerateAnswer(num);
        //pick a random box sprite to look as and instantiate
        num = random.Number(1, 4);
        switch (num)
        {
            case 1:
                box.GetComponent<SpriteRenderer>().sprite = b;
                break;
            case 2:
                box.GetComponent<SpriteRenderer>().sprite = b1;
                break;
            case 3:
                box.GetComponent<SpriteRenderer>().sprite = b2;
                break;
            case 4:
                box.GetComponent<SpriteRenderer>().sprite = b3;
                break;
        }
        box = Instantiate(box, pos, Quaternion.identity);
        box.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //keep updating pos from the box class
        pos = box.transform.position;
    }

    public void GeneratePackage()
    {
        //assigns random data to the box the player must check matches screen
        var random = new Bogus.Randomizer();
        var data = new Bogus.DataSets.Commerce("en_GB");
        var local = new Bogus.DataSets.Address("en_GB");
        var user = new Bogus.DataSets.Name("en_GB");
        zip = local.ZipCode();
        address = local.StreetAddress();
        ID = random.Number(1, 9999);
        item = data.Product();
        name = user.FullName();
    }
    public void ChangeBox()
    {
        //when called swaps the gameobjects for a workstation box or a small one
        if (isSmall)
        {
            Destroy(box);
            box = Instantiate(Big_box, pos, Quaternion.identity);

            box.transform.parent = transform;
            isSmall = false;
        }
        else
        {
            Destroy(box);
            box = Instantiate(Small_box, pos, Quaternion.identity);

            box.transform.parent = transform;
            isSmall = true;
        }
    }
    public void GenerateAnswer(int num)
    {
        //if num is 1 generate 1 false answer if not set the answer to the values already asssigned
        var random = new Bogus.Randomizer();
        var data = new Bogus.DataSets.Commerce("en");
        var local = new Bogus.DataSets.Address("en");
        var user = new Bogus.DataSets.Name("en");

        reject = false;
        zipA = zip;
        addressA = address;
        nameA = name;
        IDA = ID;
        itemA = item;
        if (num==1)
        {
            reject = true;
            int numb = random.Number(1, 5);
            if(numb == 1)
            {
                zipA = zip = local.ZipCode();
            }
            if(numb == 2)
            {
                address = local.StreetAddress();
            }
            if(numb == 3) 
            {
                ID = random.Number(1, 9999);
            }
            if(numb == 4)
            {
                item = data.Product();
            }
            else
            {
                name = user.FullName();
            }
        }
    }

    public void DestroyBox()
    {
        Destroy(box);
        Destroy(this.gameObject);
    }
}
