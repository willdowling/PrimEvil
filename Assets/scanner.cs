using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scanner : MonoBehaviour
{
    public GameObject scan;
    public GameObject holstered;
    public BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        holstered.GetComponent<SpriteRenderer>().enabled = true;
        scan.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if scanner is clicked it needs to follow the mouse until released then return to toolbelt
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider == col)
            {
                scan.GetComponent<SpriteRenderer>().enabled = true;
                holstered.GetComponent<SpriteRenderer>().enabled = false;

            }
        }
        if (scan.GetComponent<SpriteRenderer>().enabled == true)
        {
            scan.transform.position = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            scan.GetComponent<SpriteRenderer>().enabled = false;
            holstered.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
