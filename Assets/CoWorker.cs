using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bogus;

public class CoWorker : MonoBehaviour
{
    public GameObject box;

    float m_LastPressTime;
    float m_PressDelay = 10f;

    public List<GameObject> boxes;
    public Animator Co;
    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        boxes = new List<GameObject>();

        if (GameData.comask)
        {
            Co.SetBool("HasMask", true);
        }
        else
        {
            Co.SetBool("HasMask", false);
        }
        if (!GameData.coworker)
        {
            rend.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameData.coworker)
        {
            rend.enabled = true;
        }
        if (m_LastPressTime + m_PressDelay < Time.unscaledTime && GameData.coworker)
        {
            var x = Instantiate(box, new Vector3(-15f, 1.8f, 0f), Quaternion.identity);

            m_LastPressTime = Time.unscaledTime;

            boxes.Add(x);
        }
        if (boxes != null)
        {
            foreach(var b in boxes)
            {
                if (b.transform.position.x < -4f)
                {
                    b.transform.position += new Vector3(0.05f, 0f, 0f);
                    if (b.transform.position.x > -5f && b.transform.position.x < -4.98f) {
                        Debug.Log("try");
                        Co.SetTrigger("DropOff");
                    }
                }
                else if(b.transform.position.x < -1.5)
                {
                    
                    b.transform.position += new Vector3(0.04f, 0f, 0f);


                }
                else
                {
                    var random = new Bogus.Randomizer();
                    int num = random.Number(1, 2);
                    if (num == 1)
                    {
                        b.transform.position += new Vector3(0f, 0.04f, 0f);
                    }
                    else
                    {
                        b.transform.position += new Vector3(0f, 0.04f, 0f);
                    }
                }
                if (b.transform.position.y < -1 || b.transform.position.y > 4)
                {
                    Destroy(b);
                    var index = boxes.IndexOf(b);
                  
                    boxes.RemoveAt(index);
                    break;
                }
            }
        }
    }
}
