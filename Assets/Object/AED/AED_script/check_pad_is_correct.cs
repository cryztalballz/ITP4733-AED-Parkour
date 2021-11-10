using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_pad_is_correct : MonoBehaviour
{
    public Transform correctPosition;   //
    public static int PADNumber = 0;
    public string objName;

    private void Start()
    {
        correctPosition = GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == objName)
        {
            Debug.Log("I found PAD1");
            other.transform.position = new Vector3(correctPosition.position.x, correctPosition.position.y, correctPosition.position.z);
            other.transform.rotation = new Quaternion(correctPosition.rotation.x, correctPosition.rotation.y, correctPosition.rotation.z, correctPosition.rotation.w);
            other.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("PAD1 is ok");
            PADNumber++;
            Debug.Log("PADNumber = " + PADNumber);
        }


    }
}
