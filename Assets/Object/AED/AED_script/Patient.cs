using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public Animator animator;
    public GameObject cloth;
    public static GameObject pad01_position;
    public static GameObject pad02_position;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pad01_position = GameObject.Find("pad01_correct_position");
        pad02_position = GameObject.Find("pad02_correct_position");
        //pad01_position.gameObject.SetActive(false);
        //pad02_position.gameObject.SetActive(false);
    }

    //

    //cloth anim
    public void OnDisable()
    {
       // cloth.gameObject.SetActive(false);
    }
    //if the player click the cloth, the cloth will disable 

    public static void startShowPadPosition() {
        pad01_position.gameObject.SetActive(true);
        pad02_position.gameObject.SetActive(true);
    }



}
