using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieIfYouHitTheFloor : MonoBehaviour
{
    public GameObject floor;
    public GameObject ball;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == floor)
        {
            Vector3 ballPosition = new Vector3(0.0f, 0.271f, -0.263f);
            ball.transform.position = ballPosition;
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
