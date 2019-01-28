using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashable : MonoBehaviour
{
    private bool isTrashing;
    public float trashTime = 1f;

    private Vector3 initialScale;
    private float percentTrashed = 0f;

    private float clipLength = 3f;
    private float waitTillClipEnds = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    public void setTrashing(bool isTrashing)
    {
        this.isTrashing = isTrashing;

        Shakeable shakeable = GetComponent<Shakeable>();
        if (shakeable)
        {
            shakeable.IsShaking = isTrashing;
        }
    }

    private void FixedUpdate()
    {
        if (isTrashing)
        {
            percentTrashed += Time.fixedDeltaTime / trashTime;
            PlayVFX();
            DestroyIfFullyTrashed();
            //float scale =  (1 - percentTrashed) * 0.5f + 0.5f;
            //gameObject.transform.localScale = new Vector3(scale * initialScale.x, scale * initialScale.y, scale * initialScale.z);
        }
    }

    private void DestroyIfFullyTrashed()
    {
        if (percentTrashed >= 1f)
        {
            Destroy(gameObject);
        }
    }

    private void PlayVFX()
    {
        if (waitTillClipEnds <= 0f)
        {
            if (CompareTag("Trash Bag"))
            {
                AudioManager.instance.PlayVFX(AudioManager.VFX.TrashBreakdown);
            }
            else
                AudioManager.instance.PlayVFX(AudioManager.VFX.BoxBreakdown);
            waitTillClipEnds = clipLength;
        }
        else
        {
            waitTillClipEnds -= Time.fixedDeltaTime;
        }
    }
}
