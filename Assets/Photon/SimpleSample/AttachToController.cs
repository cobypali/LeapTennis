using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AttachToController : MonoBehaviour {
    public GameObject racketCopy;

    // Use this for initialization
    void Start () {
        if (GetComponent<PhotonView>().IsMine)
        {
            // Attach to controller
            transform.SetParent(MagicLeap.ControllerTransform.instance.transform, false);
//            Destroy(racketCopy);
                MagicLeap.ControllerFeedbackExample.OnTriggerDown += (MagicLeap.ControllerFeedbackExample example) => {
                    CreateBall();
                };
        }
    }

    public void CreateBall()
    {
        if (TennisBall.instance == null)
        {
            GetComponent<PhotonView>().RPC("RemoteCreateBall", RpcTarget.AllViaServer, null);
        } else
        {
            // Do nothing
        }
    }

    public GameObject ballPrefab;
    [PunRPC]
    void RemoteCreateBall()
    {
        GameObject ball = Instantiate(ballPrefab);

        Vector3 forward = transform.forward;
        forward.y = 0;
        forward = forward.normalized;
        ball.transform.position = new Vector3(0, 5, 0);    //transform.position + new Vector3(0, 0.5f, 0) + forward * 0.25f;
    }

    [PunRPC]
    void RemoteWhack(Vector3 position, Vector3 velocity)
    {
        if (TennisBall.instance != null)
        {
            TennisBall.instance.transform.position = position;
            TennisBall.instance.GetComponent<Rigidbody>().AddForce(velocity);
        }
    }
}
