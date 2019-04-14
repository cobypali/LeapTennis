using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class Racket : MonoBehaviour
{
    public Vector3 lastPosition;
    private void FixedUpdate()
    {
        lastPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = transform.position - lastPosition;
        if (true) // multiplayer
        {
            GetComponentInParent<PhotonView>().RPC("RemoteWhack", RpcTarget.AllViaServer, new object[] { collision.rigidbody.transform.position, velocity });
        } else // single player
        {
            Rigidbody rb = collision.rigidbody;
            rb.AddRelativeForce(velocity, ForceMode.Impulse);
        }
    }
}
