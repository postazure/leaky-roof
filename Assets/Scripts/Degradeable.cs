using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degradeable : MonoBehaviour
{
    [Range(0, 1)]
    public float percentDegraded = 0;

    private float degradePerSecond = 0.05f; // 20sec

    public bool isDegrading;
    public bool isDegraded;

    private Color degradedColor = new Color(.3f, .3f, .3f);

    private Color initialColor;

    Renderer GetRenderer()
    {
        //// for prefab objects like Box, which have multiple different
        //// meshes as children for the different states, there will not be 
        //// a top-level renderer
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            renderer = GetComponentInChildren<Renderer>();
        }
        return renderer;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialColor = GetRenderer().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        var currentColor = Color.Lerp(initialColor, degradedColor, percentDegraded);
        GetRenderer().material.color = currentColor;
    }

    private void FixedUpdate()
    {
        if (isDegrading && !isDegraded)
        {
            percentDegraded += Time.fixedDeltaTime * degradePerSecond;
            if (percentDegraded >= 1f)
            {
                isDegraded = true;

                //// change to "soggy" state if exists
                Transform soggy = gameObject.transform.Find("soggy");
                if (soggy != null)
                {
                    //// deactivate all the other states
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        Transform transform = gameObject.transform.GetChild(i);
                        if (!transform.Equals(soggy))
                        {
                            transform.gameObject.SetActive(false);
                        }
                    }
                    //// set the soggy state active
                    soggy.gameObject.SetActive(true);
                }
            }
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
