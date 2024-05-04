using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public SpawnOnDestroyEffect onDestroyEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.score += 1;
            onDestroyEffect.Spawn();
            Destroy(gameObject);

        }
    }
}
