using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerCoin : MonoBehaviour
{
    public GameObject _coin;


    public float timeSpawn = 2;
    private float timer;

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            Instantiate(_coin, transform);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 1.5f , Random.Range(-10, 11));
            Instantiate(_coin, randomSpawnPosition, Quaternion.identity);

        }
    }
}
