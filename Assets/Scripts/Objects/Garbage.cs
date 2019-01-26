using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Discoverable
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
            gameObject.transform.Find("closed").gameObject.SetActive(false);
            gameObject.transform.Find("opened").gameObject.SetActive(true);
        }
        return base.Discover();
    }
}
