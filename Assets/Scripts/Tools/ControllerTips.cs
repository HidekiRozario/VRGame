using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTips : MonoBehaviour
{
    public enum RightHighlights { RightA, RightB, RightTrigger, RightGrip, RightStick, RightMenu, Default};
    public enum LeftHighlights { LeftX, LeftY, LeftTrigger, LeftGrip, LeftStick, LeftMenu, Default};
    public RightHighlights rightHighlight;
    public LeftHighlights leftHighlight;

    public Animator animator;

    void Update(){
        animator.Play(rightHighlight.ToString(), 0);
        animator.Play(leftHighlight.ToString(), 1);
    }
}
