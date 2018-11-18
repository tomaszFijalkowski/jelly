using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animation buttonAnimation;

    public void ButtonEnter()
    {
        if (!buttonAnimation.IsPlaying("ButtonDoubleTempoIdle"))
        {
            buttonAnimation.Play("ButtonEnter");
        }
    }
    
    public void ButtonExit()
    {
        if (!buttonAnimation.IsPlaying("ButtonDoubleTempoIdle"))
        {
        buttonAnimation.Play("ButtonExit");
        }
    }

    public void ButtonDoubleTempoIdle()
    {
        if (!buttonAnimation.isPlaying)
        {
            buttonAnimation.Play("ButtonDoubleTempoIdle");
        }
        else
        {
            buttonAnimation.Stop();
            buttonAnimation.Play("ButtonEnter");
        }
    }
}