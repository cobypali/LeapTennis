using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class saber : MonoBehaviour
{
    private MLInputController controller;
    private void Update()
    {
        print("updating");
    }

    private void Awake()
    {
        controller = MLInput.GetController(MLInput.Hand.Left);
    }
    private void OnCollisionStay(Collision collision)
    {
        MLInputControllerFeedbackIntensity intensity = MLInputControllerFeedbackIntensity.High;
        controller.StartFeedbackPatternVibe(MLInputControllerFeedbackPatternVibe.Buzz, intensity);
    }
    private void OnCollisionEnter(Collision collision)
    {

        print("COLLISION!!!!");


        //if (collision.gameObject.tag == "saber" || collision.gameObject.name == "SABER") {
        //Handheld.Vibrate();
        MLInputControllerFeedbackIntensity intensity = MLInputControllerFeedbackIntensity.High;
        controller.StartFeedbackPatternVibe(MLInputControllerFeedbackPatternVibe.Buzz, intensity);
            print("SABERS touched something");
        //}
    }


}
