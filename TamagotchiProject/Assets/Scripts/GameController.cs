using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool doubleTempo;

    public void ChangeTempo()
    {
        Time.timeScale = doubleTempo ? 1 : 2;
        doubleTempo = !doubleTempo;
    }
    
}