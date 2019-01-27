using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakOrigin : MonoBehaviour
{
    public void ActivateLeak(GameObject leakPrefab, Vector3 location)
    {
        Instantiate(leakPrefab, location, Quaternion.identity);
    }
}
