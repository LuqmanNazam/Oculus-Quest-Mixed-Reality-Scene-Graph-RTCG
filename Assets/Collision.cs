using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Vector3 localScale;
    public List<GameObject> gameObjectsList;
    public List<GameObject> tempList;

    private void Update()
    {

    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        GameObject collideObject = collision.gameObject;

        //Check if the object is collide with deco tag
        if (collideObject.gameObject.tag == "Deco")
        {
            // 1 to 4 is to prevent the bug of object deformation when adding object as a parent of another object 
            // by adding an empty gameObject that have the inverse of the localScale of the parent object.
            // eg: parent --> temp --> child
            // 1  
            GameObject container = new GameObject("temp");

            // 2
            Vector3 myScale = collision.transform.localScale;
            container.transform.localScale = new Vector3(1f / myScale.x, 1f / myScale.y,
                    1f / myScale.z);

            // 3
            // use worldPositionStays=false to keep container's local position zero 
            // & no local rotation
            container.transform.SetParent(collision.transform, false);

            Debug.Log(container);
            // 4
            transform.SetParent(container.transform);

            // Set the object to Deco so that they are the only interactable object
            transform.gameObject.tag = "Deco";


            gameObjectsList.Add(container);
            for (int i = 0; i < gameObjectsList.Count; i++)
            {
                Debug.Log(gameObjectsList[i].transform.childCount);
                if (gameObjectsList[i].transform.childCount == 0)
                {
                    Destroy(gameObjectsList[i]);
                    gameObjectsList.RemoveAt(i);

                }
            }


        }


    }
}