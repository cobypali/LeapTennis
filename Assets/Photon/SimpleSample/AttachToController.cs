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
            Destroy(racketCopy);
        }
    }
}
