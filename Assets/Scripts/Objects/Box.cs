using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Discoverable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Discover()
    {
        if (!isDiscovered)
        {
            gameObject.transform.Find("cardboardBox_closed").gameObject.SetActive(false);
            gameObject.transform.Find("cardboardBox_opened").gameObject.SetActive(true);
        }
        return base.Discover();
    }
}
