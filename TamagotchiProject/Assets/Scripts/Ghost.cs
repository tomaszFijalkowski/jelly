using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private ParticleSystem ghostRemains;
    [SerializeField] private GameObject nightBonusPrefab;
    [SerializeField] private GameObject minus10EnergyPrefab;
    [SerializeField] private GameObject plus10EnergyPrefab;
    [SerializeField] private GameObject plus20EnergyPrefab;

    private EnergyMiniGame energyMiniGame;
    private StatsController statsController;
    private Transform targetTransform;
    private Horizon horizon;

    private CircleCollider2D ghostCollider;
    private Animator ghostAnimator;

    private const float Speed = 1.5f;

    private void Start()
    {
        var targetGameObject = GameObject.FindWithTag("Player");
        energyMiniGame = GameObject.FindWithTag("EnergyMiniGame").GetComponent<EnergyMiniGame>();
        statsController = GameObject.FindWithTag("Stats").GetComponent<StatsController>();
        horizon = GameObject.FindWithTag("Horizon").GetComponent<Horizon>();
        targetTransform = targetGameObject.GetComponent<Transform>();
        ghostCollider = GetComponent<CircleCollider2D>();
        ghostAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
        FacePlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, Speed * Time.deltaTime);
    }

    private void FacePlayer()
    {
        var offset = targetTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, offset);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoseEnergy();
            ghostAnimator.SetTrigger("GhostAttack");
            StartCoroutine(DestroyGhost());
        }
    }

    private void OnMouseDown()
    {
        if (!GameController.GamePaused)
        {
            GainEnergy();
            ghostAnimator.SetTrigger("GhostDeath");
            StartCoroutine(DestroyGhost());
            ghostRemains.Emit(Random.Range(3, 6));
        }
    }

    private void GainEnergy()
    {
        var position = transform.position;

        if (horizon.IsNight())
        {
            statsController.ChangeStats(StatsController.Stats.Energy, 20);
            // todo NEED TO CLEAR THEM FROM SCENE AFTER SOME TIME
            Instantiate(plus20EnergyPrefab, position, Quaternion.identity);
            StartCoroutine(ShowNightBonus(position));
        }
        else
        {
            statsController.ChangeStats(StatsController.Stats.Energy, 10);
            // todo NEED TO CLEAR THEM FROM SCENE AFTER SOME TIME
            Instantiate(plus10EnergyPrefab, position, Quaternion.identity);
        }
    }

    private void LoseEnergy()
    {
        statsController.ChangeStats(StatsController.Stats.Energy, -10);
        // todo NEED TO CLEAR THEM FROM SCENE AFTER SOME TIME
        Instantiate(minus10EnergyPrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator ShowNightBonus(Vector3 position)
    {
        yield return new WaitForSeconds(0.75f);
        Instantiate(nightBonusPrefab, position, Quaternion.identity);
    }

    private IEnumerator DestroyGhost()
    {
        // todo PARTICLE SYSTEM HERE
        ghostCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        energyMiniGame.DecreaseGhostCount();
        Destroy(gameObject);
    }
}