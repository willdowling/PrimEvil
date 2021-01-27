﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bogus;


public class BoxManager : MonoBehaviour
{
    public List<PackageData> Packages;
    public bool accepted;
    private bool stopSpawning;
    private float timer;
    private Vector3 pos;
    public PackageData data;
    public GameObject package;
    public Animator animate;
    private SpriteRenderer rend;
    private Vector3 p;
    public int correct=0;
    public int incorrect=0;

    public int c=0;

    float m_LastPressTime;
    float m_PressDelay = 20f;

    public AudioSource wrong;
    public AudioSource right;

    // Start is called before the first frame update
    void Start()
    {
        Packages = new List<PackageData>();

    }

    public void SpawnBox(bool co)
    {
        if (!co)
        {
            var x = Instantiate(package, new Vector3(0, 0, 0), Quaternion.identity);
            data = x.GetComponent("PackageData") as PackageData;
            data.coworker = false;
            Packages.Add(data);
        }
        else
        {
            var x = Instantiate(package, new Vector3(-15f, 1.8f, 0f), Quaternion.identity);
            data = x.GetComponent("PackageData") as PackageData;
            data.coworker = true;
            Packages.Add(data);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameData.incorrect = incorrect;
        if (m_LastPressTime + m_PressDelay < Time.unscaledTime && !GameData.coworker && GameData.day>=4)
        {
            SpawnBox(true);

            m_LastPressTime = Time.unscaledTime;
            c++;
        }

        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Packages != null)
        {
            checkPackage(position);
        }
        

        if (Input.GetMouseButtonDown(0) && Packages != null)
        {
            if (Packages != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
                foreach (var p in Packages)
                {
                    if (hit.collider == p.box.GetComponent<BoxCollider2D>() && !p.isAnimated && hit != null)
                    {
                        p.grabbed = true;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            foreach (var p in Packages)
            {
                p.grabbed = false;
                if ((p.box.transform.position.y > -2f || p.box.transform.position.x < -1.5f) && !p.isAnimated)
                {
                    p.box.transform.position = new Vector2(1.4f, 1.8f);
                }
            }
        }

    }

    public void checkPackage(Vector2 position)
    {
        foreach (var p in Packages)
        {
            if (!p.grabbed)
            {
                animate.SetBool("PickedUp", false);
            }
            if (p.isAnimated && !p.coworker)
            {
                if (p.box.transform.position.y > 1.8f)
                {
                    p.box.transform.position -= new Vector3(0f, 0.04f, 0f);
                }
                else if (p.box.transform.position.x > 1.4f)
                {
                    p.box.transform.position -= new Vector3(0.04f, 0f, 0f);
                }
                else
                {
                    p.isAnimated = false;
                }
            }
            else if (p.isAnimated && p.coworker)
            {
                if (p.transform.position.x < -4f)
                {
                    p.transform.position += new Vector3(0.02f, 0f, 0f);
                }
                else
                {
                    p.isAnimated = false;
                }
            }
            if (p.grabbed)
            {
                animate.SetBool("PickedUp", true);
                p.box.transform.position = position;
                if (p.box.transform.position.y < -2f && p.isSmall)
                {
                    p.ChangeBox();
                }
                else if (!p.isSmall)
                {
                    var x = p.gameObject.transform.GetChild(0);
                    x = x.GetChild(0);
                    rend = x.GetComponent<SpriteRenderer>();
                    if (rend.enabled == false && p.box.transform.position.y > -2f)
                    {
                        p.ChangeBox();
                    }
                    else if (rend == true && p.box.transform.position.y > -2f)
                    {

                        
                        animate.SetBool("PickedUp", false);
                        animate.SetTrigger("hasCheckOut");
                        p.ChangeBox();
                        var index = Packages.IndexOf(p);
                        if (p.coworker)
                        {
                            c--;
                        }
                        sendPackage(p);
                        Packages.RemoveAt(index);
                        break;
                    }
                }
            }

            
        }

    }
    public void sendPackage(PackageData box)
    {
        accepted = box.accepted;
        Vector3 start = new Vector3(0.41f, 1.5f, 0f);
        box.box.transform.position = start;
        
        Vector3 move = new Vector3(0.41f, 1.5f, 0f);
        Vector3 move2 = new Vector3(-1.5f, 1.5f, 0f);

        StartCoroutine(moveToX(box.box.transform, move2, 1f, box));
        
        
    }

    bool isMoving = false;
    IEnumerator moveToX(Transform fromPosition, Vector3 toPosition, float duration, PackageData box)
    {
        float counter = 0;

        //Get the current position of the object to be moved
        Vector3 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }
        if (accepted)
        {
            p = new Vector3(-1.5f, 4.45f, 0f);
        }
        else
        {
            p = new Vector3(-1.5f, -1f, 0f);
        }
        StartCoroutine(moveToY(box.box.transform, p, 6f, box));
    }
    IEnumerator moveToY(Transform fromPosition, Vector3 toPosition, float duration, PackageData box)
    {

        float counter = 0;

        //Get the current position of the object to be moved
        Vector3 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }

        Evaluate(box);

    }
    public void Evaluate(PackageData box)
    {
        if (!isMoving)
        {
            if (box.accepted && !box.reject)
            {
                correct++;
                right.Play();
            }
            else if (!box.accepted && box.reject)
            {
                correct++;
                right.Play();
            }
            else
            {
                incorrect++;
                wrong.Play();
            }

            box.DestroyBox();
        }
    }
}