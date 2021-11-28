using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VelocityInteractable : XRGrabInteractable
{
    private ControllerVelocity controllerVelocity = null;
    private MeshRenderer meshRenderer = null;

    private XRController climbingHand;
    private CharacterController character;

    protected override void Awake()
    {
        base.Awake();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override  void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        controllerVelocity = interactor.GetComponent<ControllerVelocity>();

    }

    protected override  void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        controllerVelocity = null;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if(isSelected)
        {
            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
                Climb();

        }
    }

    private void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity,
            out Vector3 velocity);         
        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}

