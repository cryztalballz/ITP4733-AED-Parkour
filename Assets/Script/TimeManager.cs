using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text time0;
    public Text time1;

    void Update()
    {
        if (AEDMode.sec_f > 0)
        {
            time0.gameObject.SetActive(false);
            time1.gameObject.SetActive(true);
        }
        else {
            time0.gameObject.SetActive(true);
            time1.gameObject.SetActive(false);
        }
    }
}
