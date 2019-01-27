using UnityEngine;

public class Pushable : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void AttachToPlayer(GameObject player)
    {
        FixedJoint joint = player.AddComponent<FixedJoint>();
        joint.connectedBody = rb;
    }

    public void DetachToPlayer(GameObject player)
    {
        Destroy(player.GetComponent<FixedJoint>());
    }
}
