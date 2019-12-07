using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    private GameObject[] spawnAreas;

    [SerializeField] private GameObject enemyPrefab;

    private Vector3 spwAreas;

    public float delay = 5;

    // Start is called before the first frame update
    void Start()
    {
        spawnAreas = GameObject.FindGameObjectsWithTag("Spawn");
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("EnemySpawn", delay);
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            spwAreas = spawnAreas[UnityEngine.Random.Range(0, spawnAreas.Length)].transform.position;

            Vector2 rdmPos = UnityEngine.Random.insideUnitCircle * 0.5f;
            Vector3 spwPos = new Vector3(rdmPos.x + spwAreas.x, 2.5f, rdmPos.y + spwAreas.z);

            Instantiate(enemyPrefab, spwPos, enemyPrefab.transform.rotation);

            yield return new WaitForSeconds(delay);
        }
    }
}