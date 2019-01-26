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
            float scale = 1 - percentTrashed;
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
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
