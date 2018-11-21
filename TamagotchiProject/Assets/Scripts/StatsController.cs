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

    private readonly Dictionary<Stats, int> stats = new Dictionary<Stats, int>
    {
        {Stats.Health, 100},
        {Stats.Energy, 100},
        {Stats.Hunger, 100},
        {Stats.Thirst, 100},
        {Stats.Amusement, 100}
    };

    private bool isAlive = true; // could be used later
    private float multiplier = 1f;

    private void Start()
    {
        StartStatsDecrease();
    }

    private void Update()
    {
        SetMultiplier();
    }

    private void SetMultiplier()
    {
        var average = (stats.Values.Sum() - stats[Stats.Health]) / (stats.Count - 1f);
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

    private IEnumerator DecreaseStat(Stats stat, float repeatRate)
    {
        while (isAlive)
        {
            var secondsToWait = stat == Stats.Health ? repeatRate * multiplier : repeatRate;
            
            yield return new WaitForSeconds(secondsToWait);

            if (stats[stat] > 0)
            {
                stats[stat] -= 1;
            }

            GameObject.FindWithTag(stat + "Bar").GetComponent<Slider>().value = stats[stat]; // could be optimized
        }
    }
}