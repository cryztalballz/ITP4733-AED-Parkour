using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Run : MonoBehaviour
{
    public float speed = 1.5f;
    public SteamVR_Input_Sources Type;
    public SteamVR_Action_Boolean Trigger;
    public SteamVR_Behaviour_Pose RightControllerPose;
    public SteamVR_Behaviour_Pose LeftControllerPose;
    public Transform Camera;
    public Transform Direction;
    private RigidbodyConstraints constraints;
    private Rigidbody rigidbody;
    private bool isChecked;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Trigger.GetLastStateDown(Type))
        {
            Debug.Log("set checked true");
            isChecked = true;
            constraints = rigidbody.constraints;
        }

        if (Trigger.GetLastStateUp(Type))
        {
            Debug.Log("set checked false");
            isChecked = false;
            rigidbody.constraints = constraints;
        }
    }

    private void FixedUpdate()
    {
        if (isChecked)
        {
            Debug.Log("checked");
            Vector3 direction = Direction.transform.forward;
            Vector3 worldDirection = Camera.transform.TransformDirection(direction);
            if (RightControllerPose.GetVelocity().y > 0.1f || RightControllerPose.GetVelocity().y <= 0.1f)
            {
                Vector3 velocity = RightControllerPose.GetVelocity();
                if (velocity.y < 0)
                    velocity.y *= -1;
                worldDirection *= velocity.y * speed;
                rigidbody.constraints = RigidbodyConstraints.FreezePositionY | constraints;
            }
            if (LeftControllerPose.GetVelocity().y > 0.1f || LeftControllerPose.GetVelocity().y <= 0.1f)
            {
                Vector3 velocity = LeftControllerPose.GetVelocity();
                if (velocity.y < 0)
                    velocity.y *= -1;
                worldDirection *= velocity.y * speed;
                rigidbody.constraints = RigidbodyConstraints.FreezePositionY | constraints;
            }
            GetComponent<Rigidbody>().velocity = worldDirection;
        }
    }
}