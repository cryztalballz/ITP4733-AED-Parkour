using UnityEngine;
using Valve.VR;
public class ClimberHand : MonoBehaviour
{
    public SteamVR_Input_Sources Hand;
    public int TouchedCount;
    public bool grabbing;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ClimbingAdapter"))
        {
            TouchedCount++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ClimbingAdapter"))
        {
            TouchedCount--;
        }
    }
}