using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakOriginController : MonoBehaviour
{
    public GameObject leakPrefab;
    public List<GameObject> leakOriginLocations;
    public float intervaulDurationSeconds;

    private float lastLeakStartTime = 0f;
    private GameObject leak;

    void Update()
    {
        if(Time.fixedTime - lastLeakStartTime > intervaulDurationSeconds && leakOriginLocations.Count > 0)
        {
            StartNextLeak();
        }
    }

    void StartNextLeak()
    {
        lastLeakStartTime = Time.fixedTime;


        int r = Random.Range(0, leakOriginLocations.Count);
        GameObject location = leakOriginLocations[r];
        leakOriginLocations.RemoveAt(r);

        LeakOrigin leakLocation = location.GetComponent<LeakOrigin>();
        leakLocation.ActivateLeak(leakPrefab, location.transform.position);
    }
}
