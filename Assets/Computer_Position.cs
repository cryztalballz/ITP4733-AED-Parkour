using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer_Position : MonoBehaviour
{

    public Transform computerPosition;
    Animator animator;
    bool playerSeen = false;
    public AnimationClip stand;
    public AnimationClip check;

    const string CHECK = "Check";
    const string STANDUP_AND_DO_NOTHING = "StandUp_and_do_nothing";
    const string HELP = "Help";
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(computerPosition.transform.position.x, computerPosition.transform.position.y, computerPosition.transform.position.z);
        animator = GetComponent<Animator>();
        Invoke("callForHelp",1);
       // Invoke("Stand", 15);

        //Invoke("heartOutPush", 35);
        
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player") {

            Debug.Log("I feel player");
            //change from can people to talk to player
            Invoke("RaiseChin", 2);
            Invoke("PulseCheck", 6);
            Invoke("callAmbulance", 9);
            Invoke("readyToPush", 12);
            Invoke("heartOutPush", 14);
            //Invoke("Stop_and_clear", 16);

            //player the voice 


        }
    }

    void ChangeAnimationState(string newState) {
        animator.Play(newState);
    }

    public void Stand() {
        //ChangeAnimationState("STANDUP_AND_DO_NOTHING");
        animator.Play("StandUp_and_do_nothing");
        Debug.Log("I am standing");

    }

    public void Check() {
        //ChangeAnimationState("CHECK");
        animator.Play("Check");
        Debug.Log("I am checking");

    }

    public void callForHelp() {
        animator.Play("Help");
        Debug.Log("Help!!!");
    }

    public void callAmbulance() {
        animator.Play("callAmbulance");
    }

    public void PulseCheck() {
        animator.Play("PulseCheck");
    }

    public void RaiseChin() {
        animator.Play("RaiseChin");
        GameObject patient = GameObject.Find("DM3");
        Animator patientA = patient.GetComponent<Animator>();
        patientA.Play("Head_Up");
    }

    public void heartOutPush() {
        animator.Play("heartOutPush");
    }

    public void readyToPush() {
        animator.Play("readyToPush");
    }

    public void Stop_and_clear() {
        animator.Play("Stop_and_clear");
    }

    public void CPU_Action() {
        Invoke("readyToPush", 1);
        Invoke("heartOutPush", 3);

    }

}
