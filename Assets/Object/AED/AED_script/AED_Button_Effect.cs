using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AED_Button_Effect : MonoBehaviour
{
    public AudioClip AED_Turn_Effect;
    public AudioClip AED_Help_Effect;
    public AudioClip AED_Stock_Effect;
    public AudioClip AED_After_Stock_Effect;
    public AudioClip Success_Effect;
    public bool stocked = false;
    public bool turned = false;
    public bool readyToStock = false;
    public int turnedOn = 0;
    AudioSource audioSource;
    public bool turnOn = false;
    //GameObject computer;
    public static bool patientWakeUp = false;
    GameObject StartPointer;
    public GameObject ShockPointer;
    public GameObject ShockEffect;
    public GameObject cross1;
    public GameObject cross2;
    public GameObject cross3;
    public GameObject cross4;
    public GameObject cross5;
    public static int AEDround = 0;
    public GameObject WinText;
    //GameObject Player;
    


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartPointer = GameObject.Find("ButtonText/Start_Button_Pointer");
        //StartPointer.gameObject.SetActive(false);
        //ShockPointer = GameObject.Find("ButtonText/SHOCK_Button_Pointer");
        ShockPointer.gameObject.SetActive(false);
        cross1 = GameObject.Find("AED_Menu/step1/cross1");
        cross1.gameObject.SetActive(false);
        cross2 = GameObject.Find("AED_Menu/step2/cross2");
        cross2.gameObject.SetActive(false);
        cross3 = GameObject.Find("AED_Menu/step3/cross3");
        cross3.gameObject.SetActive(false);
        cross4 = GameObject.Find("AED_Menu/step4/cross4");
        cross4.gameObject.SetActive(false);
        cross5 = GameObject.Find("AED_Menu/step5/cross5");
        cross5.gameObject.SetActive(false);
        //Player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
    {
        

        if (turned && turnedOn == 0) {
            turnOnAED();
            turnedOn++;
        }

        //if the player stick 2 pad, show the next audio and show thw stock button
        if (check_pad_is_correct.PADNumber == 4 && !readyToStock)
        {
            readyToStock = true;
        }
        else if (check_pad_is_correct.PADNumber == 4 && readyToStock)
        {
            afterStickThePAD();
            check_pad_is_correct.PADNumber = 5;
        }
        

        //if the stock is done, call the next audio
        if (stocked && turnedOn==1) {
            afterStock();
            turnedOn++;
        }
    }

    public void turnOnAED()
    {
        if (!turnOn) {
            Debug.Log("I turned on you");
            StartPointer.gameObject.SetActive(false);
            audioSource.PlayOneShot(AED_Turn_Effect);
            audioSource.PlayOneShot(AED_Help_Effect);
            //Patient.startShowPadPosition();
            turnOn = true;
            cross1.gameObject.SetActive(true);
        }
       
        //show the pads and the position
    }

    public void afterStickThePAD() {
        cross2.gameObject.SetActive(true);
        cross3.gameObject.SetActive(true);
        audioSource.PlayOneShot(AED_Stock_Effect);
        GameObject computer = GameObject.Find("Man_a");
        computer.GetComponent<Computer_Position>().Stop_and_clear();
        ShockPointer.gameObject.SetActive(true);

    }

    public void afterStock() {
        cross4.gameObject.SetActive(true);
        audioSource.PlayOneShot(AED_After_Stock_Effect);
        //ShockPointer = GameObject.Find("ButtonText/SHOCK_Button_Pointer");
        ShockPointer.gameObject.SetActive(false);

        ShockEffect.gameObject.SetActive(true);
        AEDround++;

        if (AEDround==2) {
            patientWakeUp = true;
        }

        if (!patientWakeUp)
        {
            GameObject computer = GameObject.Find("Man_a");
            computer.GetComponent<Computer_Position>().CPU_Action();
            Invoke("afterStickThePAD", 18);
        }
        else {
            Debug.Log("You win");
            GameObject patient = GameObject.Find("DM3");
            Animator patientA = patient.GetComponent<Animator>();
            patientA.Play("WakeUp");
            WinText.gameObject.SetActive(true);
            audioSource.PlayOneShot(Success_Effect);

        }
        //if still can not wake up, 
        //  computer continue animation


        //shock


        //if wake up, win
    }



    //player press turned button


    //機: 立即.......  , spawn pad x 2  ,show stick position

    //解衣物

    //衣服setactive = false

    //提示貼pad 

    //if pad = 4, said leave patient >>分析中 

    //機: leave patient, ready to stock 

    //player press stock 

    //stock , 機: finish stock 

    //player keep to do CPR, after 5 around, will call player and computer to leave patient 



    //player >>take AED >> press button >> take off patient>> stick pad>> leave patient>> press stock>>wait 5 round>> press stock
    //AED                   turn on >> pad set active>>         check pad number            
    //patient   fall down       show pad position    cloth off                             random 1-2 time will car come
    //computer  keep doing CPR                                             leave patient               CPR again 
    

}
