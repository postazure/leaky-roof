using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float speedMultiplier = 1f; // used to slow player down when dragging a heavy thing

    private Rigidbody rb;
    private Transform tr;
    private PlayerSelectorController selector;
    private float initialMass;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        initialMass = rb.mass;

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

        rb.AddForce(movement * speed * speedMultiplier);

        if (!selector.isPushing)
        {
            if (Mathf.Abs(moveVertical) != 0f || Mathf.Abs(moveHorizontal) !=  0f)
            {
                Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = rotation;
            }
        }
    }

    public void AddMass(float mass)
    {
        rb.mass += mass;
    }

    public void ResetMass()
    {
        rb.mass = initialMass;
    }
}