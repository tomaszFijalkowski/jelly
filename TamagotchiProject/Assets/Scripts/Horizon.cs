using UnityEngine;
using UnityEngine.UI;

public class Horizon : MonoBehaviour
{
    [SerializeField] private GameObject sunGameObject;

    [SerializeField] private GameObject moonGameObject;

    [SerializeField] private GameObject dayCounterGameObject;
    
    [SerializeField] private ParticleSystem stars;

    private Animation sunAnimation;
    private Animation moonAnimation;
    private Animation dayCounterAnimation;
    private Text dayCounterText;

    private bool isNight;
    private int dayCounter;

    private void Start()
    {
        StartHorizonCycle();
        sunAnimation = sunGameObject.GetComponent<Animation>();
        moonAnimation = moonGameObject.GetComponent<Animation>();
        dayCounterAnimation = dayCounterGameObject.GetComponent<Animation>();
        dayCounterText = dayCounterGameObject.GetComponent<Text>();
    }

    public bool IsNight() // could be useful later
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
        ShowDayCounter();
        stars.Stop();
        sunAnimation.Play();
        isNight = false;
    }

    private void MoonCycle()
    {
        stars.Play();
        moonAnimation.Play();
        isNight = true;
    }

    private void ShowDayCounter()
    {
        dayCounterText.text = "Day " + ++dayCounter;
        dayCounterAnimation.Play("ShowDayCounter");
    }
}