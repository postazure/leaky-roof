using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashable : MonoBehaviour
{
    private bool isTrashing;

    public float trashTime = 3f;
    public float percentTrashed = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isTrashing)
        {
            percentTrashed += Time.fixedDeltaTime / trashTime;
            CheckIfFullyTrashed();
        }
    }

    private void OnMouseDown()
    {
        isTrashing = true;
    }

    private void OnMouseUp()
    {
        isTrashing = false;
    }

    private void CheckIfFullyTrashed()
    {
        if (percentTrashed >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
