using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Rigidbody childObj;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        GameObject collideObject = collision.gameObject;

        //Check if the object is collide with Deco tag
        if (collideObject.gameObject.tag == "Deco")
        {
            Debug.Log("same");
            transform.SetParent(collision.transform);

            childObj = transform.GetComponentInChildren<Rigidbody>();

            transform.gameObject.tag = "Deco";

        }


    }
}