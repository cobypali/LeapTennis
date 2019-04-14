using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPositioner : MonoBehaviour
{

    public static BallPositioner instance;

    private void Awake()
    {
        instance = this;
    }

}
