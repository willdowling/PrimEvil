using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBoxButton : MonoBehaviour
{
    public GameObject bttn;
    public Sprite pressed; 
    public Sprite up; 
    float m_LastPressTime;
    float m_PressDelay = 2f;
    private bool held;
    public BoxManager box;
    private SpriteRenderer rend;
    private BoxCollider2D col;
    AudioSource snd;
    // Start is called before the first frame update
    void Start()
    {
        col = bttn.GetComponent<BoxCollider2D>();
        rend = bttn.GetComponent<SpriteRenderer>();

        up = rend.sprite;

        snd = GetComponent<AudioSource>();
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
                if (m_LastPressTime + m_PressDelay < Time.unscaledTime)
                {
                    held = true;
                    box.SpawnBox(false);
                    snd.Play();
                    m_LastPressTime = Time.unscaledTime;
                }

            }
        }
       
        if (held == true)
        {
            rend.sprite = pressed;
        }
        else
        {
            rend.sprite = up;
        }
        if (Input.GetMouseButtonUp(0))
        {
            held = false;

        }
    }
}
