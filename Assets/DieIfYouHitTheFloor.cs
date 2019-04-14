using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieIfYouHitTheFloor : MonoBehaviour
{
    private void update()
    {
        print("hello");
        if(transform.position.y < 0)
        {
            print("Got to here");
            Vector3 ballPosition = new Vector3(0.0f, 0.271f, -0.263f);
            transform.position = ballPosition;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
