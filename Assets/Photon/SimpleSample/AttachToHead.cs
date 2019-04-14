using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class AttachToHead : MonoBehaviour {
    public GameObject headCopy;

	// Use this for initialization
	void Start () {
        if (GetComponent<PhotonView>().IsMine) {
            transform.SetParent(Camera.main.transform, false);
            Destroy(headCopy);
        }
    }
}
