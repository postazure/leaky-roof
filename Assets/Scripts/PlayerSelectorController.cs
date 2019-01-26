using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectorController : MonoBehaviour
{
    private GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (selectedObject)
            {
                print("Engage was pressed with a selection");
            }
            else
            {
                print("Engage was pressed without a selection");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        selectedObject = other.gameObject;    
    }

    private void OnTriggerExit(Collider other)
    {
        selectedObject = null;
    }
}
