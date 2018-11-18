using UnityEngine;
using UnityEngine.UI;

public class HorizonController : MonoBehaviour
{
    [SerializeField] private Transform sun;

    [SerializeField] private Transform moon;

    [SerializeField] private ParticleSystem stars;

    [SerializeField] private Text dayCounterText;

    private bool isNight;
    private int dayCounter;

    void Start()
    {
        StartHorizonCycle();
    }

    public bool IsNight()
    {
        return isNight;
    }

    private void StartHorizonCycle()
    {
        InvokeRepeating("SunCycle", 0f, 60f);
        InvokeRepeating("MoonCycle", 30f, 60f);
    }

    private void SunCycle()
    {
        Debug.Log("Day starts!");
        ShowDayCounter();
        stars.Stop();
        sun.GetComponent<Animation>().Play();
        isNight = false;
    }

    private void MoonCycle()
    {
        Debug.Log("Night starts!");
        stars.Play();
        moon.GetComponent<Animation>().Play();
        isNight = true;
    }

    void ShowDayCounter()
    {
        dayCounterText.text = "Day " + ++dayCounter;
        dayCounterText.GetComponent<Animation>().Play("ShowDayCounter");
    }
}