using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroyEffect : MonoBehaviour
{
    public AudioClip sound;
    public Material material;
    public OnDestroyParticles effectPrefab;

    public void Spawn()
    {
        var effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        effect.material = material;
        effect.source.clip = sound;
    }
}
