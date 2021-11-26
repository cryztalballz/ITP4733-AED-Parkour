using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public SteamVR_Action_Boolean frontType;
    public SteamVR_Action_Boolean leftType;
    public SteamVR_Action_Boolean rightType;
    public SteamVR_Action_Boolean backType;
    public SteamVR_Input_Sources type;
    [SerializeField]int speed;
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
    }
}
