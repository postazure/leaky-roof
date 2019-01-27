using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shakeable : MonoBehaviour
{
    public float secPerShake = 0.05f;
    public float shakeIntensity = 0.05f;
    public bool isShaking = false;

    private Vector3 originPosition;
    private float lastDirectionChangeTime;
    private Vector3 currentDestination;

    void Start()
    {
        originPosition = transform.position;
    }

    void Update()
    {
        if (!isShaking) return;

        float now = Time.fixedTime;

        if (now - lastDirectionChangeTime >= secPerShake)
        {
            currentDestination = RandomDestination();
            lastDirectionChangeTime = now;
        }

        float distance = Vector3.Distance(transform.position, currentDestination);
        float step = distance / secPerShake * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, step);
    }

    private Vector3 RandomDestination()
    {
        Vector3 random = Random.insideUnitSphere * shakeIntensity;
        random.y = 0;

        return originPosition + random;
    }
}
