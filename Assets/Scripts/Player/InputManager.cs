using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private XRNode xrNodeLeft = XRNode.LeftHand;
    [SerializeField]
    private XRNode xrNodeRight = XRNode.RightHand;

    private List<InputDevice> rightDevices = new List<InputDevice>();
    private List<InputDevice> leftDevices = new List<InputDevice>();

    private InputDevice deviceRight;
    private InputDevice deviceLeft;

    //BUTTONS
    public bool primaryButtonRight;
    public bool primaryButtonLeft;
    public bool secondaryButtonRight;
    public bool secondaryButtonLeft;

    public bool joystickClickRight;
    public bool joystickClickLeft;

    public bool selectButtonRight;
    public bool selectButtonLeft;

    public bool triggerClickRight;
    public bool triggerClickLeft;


    void GetDevice(){
        InputDevices.GetDevicesAtXRNode(xrNodeLeft, leftDevices);
        deviceLeft = leftDevices.FirstOrDefault();

        InputDevices.GetDevicesAtXRNode(xrNodeRight, rightDevices);
        deviceRight = rightDevices.FirstOrDefault();
    }

    void OnEnable(){
        if(!deviceRight.isValid || !deviceLeft.isValid){
            GetDevice();
        }
    }

    void Update()
    {
        OnEnable();

        //PRIMARYBUTTON
        InputFeatureUsage<bool> primaryBtnUsage = CommonUsages.primaryButton;

        if(deviceLeft.TryGetFeatureValue(primaryBtnUsage, out primaryButtonLeft) && primaryButtonLeft){

        }
        if(deviceRight.TryGetFeatureValue(primaryBtnUsage, out primaryButtonRight) && primaryButtonRight){

        }

        //SECONDARYBUTTON

        InputFeatureUsage<bool> secondaryBtnUsage = CommonUsages.secondaryButton;

        if(deviceLeft.TryGetFeatureValue(secondaryBtnUsage, out secondaryButtonLeft) && secondaryButtonLeft){

        }
        if(deviceRight.TryGetFeatureValue(secondaryBtnUsage, out secondaryButtonRight) && secondaryButtonRight){

        }

        //JOYSTICKPRESS

        InputFeatureUsage<bool> joystickPressUsage = CommonUsages.primary2DAxisClick;

        if(deviceLeft.TryGetFeatureValue(joystickPressUsage, out joystickClickLeft) && joystickClickLeft){

        }
        if(deviceRight.TryGetFeatureValue(joystickPressUsage, out joystickClickRight) && joystickClickRight){

        }

        //SELECTBUTTON
        InputFeatureUsage<bool> selectUsage = CommonUsages.gripButton;

        if(deviceLeft.TryGetFeatureValue(selectUsage, out selectButtonLeft) && selectButtonLeft){

        }
        if(deviceRight.TryGetFeatureValue(selectUsage, out selectButtonRight) && selectButtonRight){

        }

        //TRIGGERCLICK
        InputFeatureUsage<bool> triggerUsage = CommonUsages.triggerButton;

        if(deviceLeft.TryGetFeatureValue(triggerUsage, out triggerClickLeft) && triggerClickLeft){

        }
        if(deviceRight.TryGetFeatureValue(triggerUsage, out triggerClickRight) && triggerClickRight){

        }
    }
}
