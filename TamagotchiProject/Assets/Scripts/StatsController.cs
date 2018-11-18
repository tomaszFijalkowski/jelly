using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    private enum Stats
    {
        Health,
        Energy,
        Hunger,
        Thirst,
        Amusement
    };

    private readonly Dictionary<Stats, int> statistics = new Dictionary<Stats, int>
    {
        {Stats.Health, 100},
        {Stats.Energy, 100},
        {Stats.Hunger, 100},
        {Stats.Thirst, 100},
        {Stats.Amusement, 100}
    };

    private HorizonController horizon;
    private bool isAlive = true;
    private float multiplier = 1f;

    void Start()
    {
        horizon = GameObject.FindWithTag("Horizon").GetComponent<HorizonController>();
        StartStatsDecrease();
    }

    void Update()
    {
        SetMultiplier();
    }

    private void SetMultiplier()
    {
        float average = (statistics.Values.Sum() - statistics[Stats.Health]) / (statistics.Count - 1f);
        multiplier = Math.Max(0.1f, average / 100f);
    }

    private void StartStatsDecrease()
    {
        StartCoroutine(DecreaseStat(Stats.Health, 2f));
        StartCoroutine(DecreaseStat(Stats.Energy, 0.5f));
        StartCoroutine(DecreaseStat(Stats.Hunger, 0.33f));
        StartCoroutine(DecreaseStat(Stats.Thirst, 0.25f));
        StartCoroutine(DecreaseStat(Stats.Amusement, 0.2f));
    }

    IEnumerator DecreaseStat(Stats stat, float repeatRate)
    {
        while (isAlive)
        {
            float secondsToWait = repeatRate;

            switch (stat)
            {
                case Stats.Health:
                    secondsToWait = repeatRate * multiplier;
                    break;
                case Stats.Energy:
                    secondsToWait = horizon.IsNight() ? repeatRate / 2f : repeatRate;
                    break;
            }

            yield return new WaitForSeconds(secondsToWait);

            if (statistics[stat] > 0)
            {
                statistics[stat] -= 1;
            }

            GameObject.FindWithTag(stat + "Bar").GetComponent<Slider>().value = statistics[stat];
        }
    }
}