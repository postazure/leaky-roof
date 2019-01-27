using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashable : MonoBehaviour
{
    private bool isTrashing;
    private Vector3 initialScale;

    public float trashTime = 3f;
    public float percentTrashed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTrashing(bool isTrashing)
    {
        this.isTrashing = isTrashing;
    }

    private void FixedUpdate()
    {
        if (isTrashing)
        {
            percentTrashed += Time.fixedDeltaTime / trashTime;
            CheckIfFullyTrashed();
            float scale =  (1 - percentTrashed) * 0.5f + 0.5f;
            gameObject.transform.localScale = new Vector3(scale * initialScale.x, scale * initialScale.y, scale * initialScale.z);
        }
    }

    private void CheckIfFullyTrashed()
    {
        if (percentTrashed >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
