using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle : MonoBehaviour
{

    public bool held = false;
    private Vector2 startpos;
    public BoxCollider2D col;
    public GameObject b;
    public AudioSource snd;

    // Start is called before the first frame update
    void Start()
    {

        startpos = b.gameObject.transform.position;
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
            b.transform.position = pos;
        }
        if (Input.GetMouseButtonUp(0) || b.transform.position.y > 0f)
        {
            held = false;

            b.transform.position = startpos;
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.GetComponent<BoxCollider2D>().tag == "Metaball_liquid" && held)
        {
            snd.Play();
            var x = c.GetComponent<BoxCollider2D>().transform.parent.gameObject;
            Destroy(x);
        }
    }
}
