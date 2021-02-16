using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RFID : MonoBehaviour
{
    public GameObject scan;
    public Text zip;
    public Text address;
    public Text name;
    public Text item;
    public string z = null;
    public string a = null;
    public string n = null;
    public string i=null;
    public BoxCollider2D col;

    public AudioSource snd;


    bool play;
    // Start is called before the first frame update
    void Start()
    {
        name.text = "Name: " + n;
        address.text = "Address: " + a;
        zip.text = "Zip: " + z;
        item.text = "Item: " + i;
        play = true;
        snd = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //if the scanner scans  box play a sound and update the text to the one corresponding to box
        if (c.GetComponent<BoxCollider2D>().tag == "Package")
        {
            if (play)
            {
                snd.Play();
            }

            play = false;
            var x = c.GetComponent<BoxCollider2D>().transform.parent.gameObject;

            ChangeText(x.GetComponent("PackageData") as PackageData);
        }
        else
        {
            play = true;
        }
    }


    public void ChangeText(PackageData pack)
    {
        n = pack.name;
        z = pack.zip;
        a = pack.address;
        i = pack.item;

        name.text = "Name: " + n;
        address.text = "Address: " + a;
        zip.text = "Zip: " + z;
        item.text = "Item: " + i;
    }
}
