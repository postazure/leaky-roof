﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectorController : MonoBehaviour
{
    private GameObject selectedObject;

    private Rigidbody pushedObject;
    [HideInInspector]
    public bool isPushing { get; private set; }

    private void Start()
    {
        isPushing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObject)
        {
            Trashable trashable = selectedObject.GetComponent<Trashable>();
            if (trashable != null)
            {
                trashable.setTrashing(Input.GetButton("Trash"));
            }

            var discoverable = selectedObject.GetComponent<Discoverable>();
            if (discoverable != null)
            {
                if (Input.GetButtonDown("Interact"))
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

            // Attach an object to push
            if (selectedObject.GetComponent<Pushable>())
            {
                if (Input.GetButtonDown("Interact"))
                {
                    pushedObject = selectedObject.GetComponent<Rigidbody>();
                    pushedObject.GetComponent<Pushable>().AttachToPlayer(transform.parent.gameObject);
                    //pushedObject.constraints = RigidbodyConstraints.FreezeRotation;

                    isPushing = true;

                    float massFromDraggedItem = selectedObject.GetComponentsInChildren<Rigidbody>()[0].mass;
                    FindObjectOfType<PlayerController>().AddMass(massFromDraggedItem / 3f);
                }
            }
        }

        // Let go of an object I'm pushing
        if (isPushing && Input.GetButtonUp("Interact"))
        {
            isPushing = false;
            pushedObject.GetComponent<Pushable>().DetachToPlayer(transform.parent.gameObject);
            //pushedObject.constraints = RigidbodyConstraints.None;
            pushedObject = null;

            FindObjectOfType<PlayerController>().ResetMass();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Selectable"))
        {
            selectedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == selectedObject)
        {
            selectedObject = null;
        }
    }
}
