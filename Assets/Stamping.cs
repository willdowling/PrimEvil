using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bogus;

public class Stamping : MonoBehaviour
{
    public GameObject stamped;
    public GameObject stamp;
    private Vector2 startpos;
    public bool isgrabbed = false;
    public bool approved = true;
    public Sprite red;
    private Sprite green;
    public Sprite a1;
    public Sprite a2;
    public Sprite a3;
    public Sprite r1;
    public Sprite r2;
    public Sprite r3;
    private SpriteRenderer boxRend;
    private SpriteRenderer rend;
    private PackageData data;

    float m_LastPressTime;
    float m_PressDelay = 0f;
    AudioSource snd;

    // Start is called before the first frame update
    void Start()
    {
        stamped = null;
        startpos = stamp.transform.position;
        rend = stamp.GetComponent<SpriteRenderer>();
        green = rend.sprite;
        snd = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider == stamp.GetComponent<BoxCollider2D>())
            {
                stamp.transform.Rotate(0f, 0f, -30f);
                isgrabbed = true;
            }
        }
        if (isgrabbed) {
        
            stamp.transform.position = pos;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (isgrabbed)
            {
                isgrabbed = false;
                stamp.transform.Rotate(0f, 0f, 30f);
                stamp.transform.position = startpos;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.GetComponent<BoxCollider2D>().tag == "Package" && isgrabbed)
        {
            boxRend = c.transform.Find("stamped").gameObject.GetComponent<SpriteRenderer>();
            var x = c.GetComponent<BoxCollider2D>().transform.parent.gameObject;
            data = x.GetComponent("PackageData") as PackageData;
            var random = new Bogus.Randomizer();
            int num = random.Number(1, 3);
            if (approved)
            {
                if (num == 1)
                {
                    boxRend.sprite = a1;
                   
                }
                else if (num == 2)
                {
                    boxRend.sprite = a2;
                }
                else
                {
                    boxRend.sprite = a3;
                }
                snd.Play();
            }
            else
            {
                if (num == 1)
                {
                    boxRend.sprite = r1;
                }
                else if (num == 2)
                {
                    boxRend.sprite = r2;
                }
                else
                {
                    boxRend.sprite = r3;
                }
                snd.Play();
            }
            boxRend.enabled = true;
            data.accepted = approved;

        }
        if (m_LastPressTime + m_PressDelay < Time.unscaledTime)
        {

            m_LastPressTime = Time.unscaledTime;
            if (c.gameObject.name == "Reject Pad" && isgrabbed)
            {
                rend.sprite = red;
                approved = false;
                snd.Play();
            }
            else if (c.gameObject.name == "Approve Pad" && isgrabbed)
            {
                rend.sprite = green;
                approved = true;
                snd.Play();
            }

        }
    }
}
