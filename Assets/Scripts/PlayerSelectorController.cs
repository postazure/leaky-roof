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
        if (selectedObject)
        {
            Trashable trashable = selectedObject.GetComponent<Trashable>();
            if (trashable != null)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    trashable.setTrashing(true);
                }
                else if (Input.GetKeyUp(KeyCode.F))
                {
                    trashable.setTrashing(false);
                }
            }

            var discoverable = selectedObject.GetComponent<Discoverable>();
            if (discoverable != null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    var wasDiscovered = discoverable.Discover();
                    if (wasDiscovered)
                    {
                        print("You discovered an item.");
                    }
                    else
                    {
                        print("There is nothing left to discover about this item.");
                    }
                }
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
