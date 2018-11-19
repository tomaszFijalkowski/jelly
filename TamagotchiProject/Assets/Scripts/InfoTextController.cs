using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextController : MonoBehaviour
{
    [SerializeField] private GameObject infoText;

    [SerializeField] private string label;

    private Animation infoTextAnimation;

    private void Start()
    {
        infoTextAnimation = infoText.GetComponent<Animation>();
    }

    public void ElementEnter()
    {
        foreach (var textComponent in infoText.GetComponentsInChildren<Text>())
        {
            textComponent.text = label;
        }

        infoTextAnimation.Play("InfoTextShow");
    }

    public void ElementExit()
    {
        infoTextAnimation.Play("InfoTextFade");
    }

}