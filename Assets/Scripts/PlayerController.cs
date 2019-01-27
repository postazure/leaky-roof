using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    private Transform tr;
    private PlayerSelectorController selector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        selector = GetComponentInChildren<PlayerSelectorController>();
        if (selector == null)
            Debug.LogError("PlayerSelectorController not found on Player or its children.");
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(-moveHorizontal * 0.1f, 0.0f, -moveVertical * 0.1f);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (!selector.isPushing)
        {
            if (Mathf.Abs(moveVertical) != 0f || Mathf.Abs(moveHorizontal) !=  0f)
            {
                Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = rotation;
            }
        }

    }
}