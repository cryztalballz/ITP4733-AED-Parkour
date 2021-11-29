using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AedPosition : MonoBehaviour
{
    public Transform correctPosition;   //
    //public static int PADNumber = 0;
    public string objName;

    private void Start()
    {
        correctPosition = GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == objName)
        {
            Debug.Log("I found AED");
            other.transform.position = new Vector3(correctPosition.position.x, correctPosition.position.y, correctPosition.position.z);
            other.transform.rotation = new Quaternion(correctPosition.rotation.x, correctPosition.rotation.y, correctPosition.rotation.z, correctPosition.rotation.w);
            other.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("AED is ok");
            //PADNumber++;
            //Debug.Log("PADNumber = " + PADNumber);
        }


    }
}
