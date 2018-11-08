using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    public static WaveSystem instace;
    [Header("Enemy value")]
    public float currentAmountOfEnemies;
    [SerializeField] GameObject[] enemies;
    [SerializeField] float amountOfEnemies;
    [SerializeField] float upEnemies;
    [SerializeField] float downTime;

    [Header("Type Enemy")]
    [SerializeField] float Enemy1;
    [SerializeField] float Enemy2;
    [SerializeField] float Enemy3;
    public List<Transform> Enemy1SpawnPoints = new List<Transform>();
    public List<Transform> Enemy2SpawnPoints = new List<Transform>();
    public List<Transform> enemy3SpawnPoints = new List<Transform>();

    [Header("Wave")]
    [SerializeField] Text wave;
    [SerializeField] Text waveShadow;
    public int waveAmount;
    bool resetHealth;
    bool flagCheck;
    Transform randomspawnEnemy1;
    Transform randomspawnEnemy2;
    Transform randomspawnEnemy3;

    [Header("Amount Of Enemies")]
    [SerializeField] Text totalEnemies;

    [Header("SpawnRate")]
    [SerializeField] float spawnWait;
    [SerializeField] float spawnLeastWait;
    [SerializeField] float spawnMostWait;
    [SerializeField] bool stop;

    void Awake()
    {
        instace = this;
    }

    void Start()
    {
        resetHealth = true;
        flagCheck = false;
        Create();
        currentAmountOfEnemies = amountOfEnemies;
        StartCoroutine(SpawnRate());
    }

    void Update()
    {
        if (Input.GetButtonDown("I"))
        {
            currentAmountOfEnemies = 0;
        }
        //totalEnemies.text = ("Left" + "/" + currentAmountOfEnemies);
        string s = ("Wave " + waveAmount.ToString());
        wave.text = s;
        waveShadow.text = s;
        if (currentAmountOfEnemies <= 0)
        {
            flagCheck = true;
            CheckEnemy();
        }
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        randomspawnEnemy1 = Enemy1SpawnPoints[Random.Range(0, Enemy1SpawnPoints.Count)];
        randomspawnEnemy2 = Enemy2SpawnPoints[Random.Range(0, Enemy2SpawnPoints.Count)];
        randomspawnEnemy3 = enemy3SpawnPoints[Random.Range(0, enemy3SpawnPoints.Count)];
    }
    void CheckEnemy()
    {
        if (flagCheck)
        {
            flagCheck = false;
            amountOfEnemies += upEnemies;
            currentAmountOfEnemies = amountOfEnemies;

            /*
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyHealth>().UpEnemyHealth(upHealth);
            }
            */

            Create();
            waveAmount++;
            StartCoroutine(SpawnRate());
            spawnLeastWait = spawnLeastWait / downTime;
            spawnMostWait = spawnMostWait / downTime;
        }
    }

    public void EnemyCheck(float enemy)
    {
        Mathf.RoundToInt(currentAmountOfEnemies -= enemy);
    }

    void Create()
    {

        if (waveAmount > 0)
        {
            if (currentAmountOfEnemies <= 0)
            {
                amountOfEnemies = Mathf.RoundToInt(amountOfEnemies + upEnemies);
            }
        }
    }
    IEnumerator SpawnRate()
    {

        Enemy1 = Mathf.RoundToInt(amountOfEnemies * .5f);
        Enemy2 = Mathf.RoundToInt(amountOfEnemies * .3f);
        Enemy3 = Mathf.RoundToInt(amountOfEnemies * .2f);

        yield return new WaitForSeconds(spawnWait);

        for (int i = 0; i < Enemy1; i++)
        {
            Instantiate(enemies[0], randomspawnEnemy1.transform);
            yield return new WaitForSeconds(spawnWait);
        }
        yield return new WaitForSeconds(spawnWait);

        for (int i = 0; i < Enemy2; i++)
        {
            Instantiate(enemies[1], randomspawnEnemy2.transform);
            //print(Enemy2SpawnPoints);
            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(spawnWait);

        for (int i = 0; i < Enemy3; i++)
        {
            Instantiate(enemies[2], randomspawnEnemy3.transform);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
