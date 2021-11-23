using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    public GameObject player;
    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    private bool shouldTeleport;
    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleport;
    public GameObject laserPrefab;
    GameObject laser;
    Transform laserTransform;
    Vector3 hitPoint;
    private void Teleport()
    {
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 1;  //y=0 camera’ view will below plane
        cameraRigTransform.position = hitPoint + difference;
    }

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (teleport.GetState(type))
        {
            Vector3 verticalZero = player.transform.position + Camera.main.transform.forward * 5 * Time.deltaTime;
            verticalZero.y = 0;
            player.transform.position = verticalZero;
        }
        //if (teleport.GetState(type))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
        //    {
        //        hitPoint = hit.point;
        //        ShowLaser(hit);
        //        reticle.SetActive(true);
        //        teleportReticleTransform.position = hitPoint + teleportReticleOffset;
        //        shouldTeleport = true;
        //    }
        //}
        //else
        //{
        //    laser.SetActive(false);
        //    reticle.SetActive(false);
        //}
        //if (teleport.GetStateUp(type) && shouldTeleport)
        //{
        //    Teleport();
        //}
    }
    private void ShowLaser(RaycastHit hit)
    {
        Debug.Log("Show Laser");
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }
}