using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnifyer : MonoBehaviour
{
    public BoxCollider2D col;
    public GameObject Mag;

    public Text zip;
    public Text address;
    public Text name;
    public Text item;

    public string z = null;
    public string a = null;
    public string n = null;
    public string i = null;

    public bool held = false;
    private Vector2 startpos;

    // Start is called before the first frame update
    void Start()
    {
        name.text = "Name: " + n;
        address.text = "Address: " + a;
        zip.text = "Zip: " + z;
        item.text = "Item: " + i;
        startpos = Mag.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider == col)
            {
                held = true;

            }
        }
        if (held == true)
        {
            Mag.transform.position = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            held = false;

            Mag.transform.position = startpos;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.GetComponent<BoxCollider2D>().tag == "Package" && held)
        {
            var x = c.GetComponent<BoxCollider2D>().transform.parent.gameObject;

            ChangeText(x.GetComponent("PackageData") as PackageData);
        }
    }

    public void ChangeText(PackageData pack)
    {
        n = pack.nameA;
        z = pack.zipA;
        a = pack.addressA;
        i = pack.itemA;

        name.text = "Name: " + n;
        address.text = "Address: " + a;
        zip.text = "Zip: " + z;
        item.text = "Item: " + i;
    }
}
