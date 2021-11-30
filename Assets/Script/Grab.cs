using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Grab : MonoBehaviour
{
    public SteamVR_Input_Sources Type;
    public SteamVR_Action_Boolean GrabGrip;
    public SteamVR_Behaviour_Pose ControllerPose;
    public GameObject CameraRig;
    [SerializeField]
    public Rigidbody CameraRigConstraints;
    private bool IsGrabed = false;
    private static int GrabCount = 0;
    // Update is called once per frame
    void Update()
    {
        if (GrabGrip.GetLastStateUp(Type))
        {
            IsGrabed = false;
            CameraRig.GetComponent<Rigidbody>().constraints = CameraRigConstraints.constraints;
            Release();
        }

        if (IsGrabed)
        {
            CameraRig.GetComponent<Rigidbody>().velocity = -ControllerPose.GetVelocity();
            CameraRig.GetComponent<Rigidbody>().angularVelocity = new Vector3(200 * ControllerPose.GetAngularVelocity().x,
                200 * ControllerPose.GetAngularVelocity().y);
        }

        if (GrabCount <= 0)
        {
            CameraRig.GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            CameraRig.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public bool GetGrab()
    {
        return GrabGrip.GetState(Type);
    }
    public void Release()
    {
        if (GrabCount > 0)
            GrabCount--;
    }

    public void OnTriggerStay(Collider col)
    {
        if (IsGrabed && col.tag == "GrabUpPoint")
        {
            CameraRig.transform.position = col.transform.position;
        }
        if (!IsGrabed)
        {
            if (col.tag == "wall")
            {
                // first grab
                if (GetGrab())
                {
                    GrabCount++;
                    CameraRig.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
                    IsGrabed = true;
                }
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.tag == "wall")
        {
            IsGrabed = false;
            CameraRig.GetComponent<Rigidbody>().constraints = CameraRigConstraints.constraints;
            Release();
        }
    }
}