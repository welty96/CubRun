using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyParticles : MonoBehaviour
{
    public ParticleSystem particles;
    public AudioSource source;

    [Header("Parameters")]
    public Material material;
    public AudioClip clip;     
    public void Start()
    {
        source.clip = clip;
        source.Play();

        particles.GetComponent<Renderer>().material = material;
        Invoke(nameof(DestroyObject), 2f);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
