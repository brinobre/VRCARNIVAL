using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportController : MonoBehaviour
{
    public XRController rightTeleportRay;
    public XRController leftTeleportRay;
    public InputHelpers.Button teleportActivationButton;

    void Start()
    {
        rightTeleportRay.gameObject.SetActive(false);
        leftTeleportRay.gameObject.SetActive(false);
    }

    bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated);
        return isActivated;
    }

    // Update is called once per frame
    void Update()
    {
        rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay) && !leftTeleportRay.gameObject.activeInHierarchy);
        leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay) && !rightTeleportRay.gameObject.activeInHierarchy);
    }
}
