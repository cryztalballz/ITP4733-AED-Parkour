using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject hand;
    public SteamVR_Action_Boolean frontType;
    public SteamVR_Action_Boolean leftType;
    public SteamVR_Action_Boolean rightType;
    public SteamVR_Action_Boolean backType;
    public SteamVR_Action_Boolean grab;
    public SteamVR_Input_Sources type;
    [SerializeField]int speed;
    Vector3 handPos, distance;
    bool grabed, recorded;
    private void Start()
    {
        grabed = recorded = false;
    }
    void Update()
    {
        if (frontType.GetState(type))
        {
            Vector3 verticalZero = player.transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
            verticalZero.y = 0;
            player.transform.position = verticalZero;
        }
        if (leftType.GetState(type))
        {
            Vector3 verticalZero = player.transform.position + Camera.main.transform.right * -speed * Time.deltaTime;
            verticalZero.y = 0;
            player.transform.position = verticalZero;
        }
        if (rightType.GetState(type))
        {
            Vector3 verticalZero = player.transform.position + Camera.main.transform.right * speed * Time.deltaTime;
            verticalZero.y = 0;
            player.transform.position = verticalZero;
        }
        if (backType.GetState(type))
        {
            Vector3 verticalZero = player.transform.position + Camera.main.transform.forward * -speed * Time.deltaTime;
            verticalZero.y = 0;
            player.transform.position = verticalZero;
        }
        if (grab.GetLastStateDown(type))
        {
            grabed = true;
        }
        if (grab.GetLastStateUp(type))
        {
            grabed = false;
        }
    }
    private void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.CompareTag("ClimbingAdapter"))
        {
            if (grab.GetLastStateDown(type))
            {
                Debug.Log("grabed");
                if (!recorded)
                {
                    handPos = hand.transform.position;
                    recorded = true;
                }
                distance = hand.transform.position - handPos;
                player.transform.position += distance;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        recorded = false;
        handPos = distance = Vector3.zero;
    }
}
