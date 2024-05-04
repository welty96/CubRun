using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public player player;
    public EnemyMovement enemyPrefab;

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
            EnemyMovement enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);       
            enemy.Player = player;
        }
    }
}
