using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degradeable : MonoBehaviour
{
    [Range(0, 1)]
    public float percentDegraded = 0;

    [Range(0, 1)]
    public float degradePerSecond = 0.1f;

    public bool isDegrading;

    public Color degradedColor;

    private Color initialColor;


    // Start is called before the first frame update
    void Start()
    {
        initialColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        var currentColor = Color.Lerp(initialColor, degradedColor, percentDegraded);
        GetComponent<Renderer>().material.color = currentColor;
    }

    private void FixedUpdate()
    {
        if (isDegrading)
        {
            percentDegraded += Time.fixedDeltaTime * degradePerSecond;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter for cube");
        var puddle = other.gameObject.GetComponent<Puddle>();
        if (puddle)
        {
            //Debug.Log("Collided with puddle");
            isDegrading = true;
        }
    }
}
