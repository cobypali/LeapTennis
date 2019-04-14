using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    public static TennisBall instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public void Update()
    {

        if(transform.position.y < 0)
        {
            Destroy(gameObject);
            //print("Got to here");
            //Vector3 ballPosition = new Vector3(0.0f, 0.271f, -0.263f);
            //transform.position = ballPosition;
            //GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
