using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedPee : MonoBehaviour
{
    public Player_manager p;
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -8.5f)
        {
            p.pissed += 1;
            Destroy(this);
        }
    }
}
