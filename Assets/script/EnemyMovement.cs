using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _nav;
    public player Player;

    private WaitForSeconds wfs = new WaitForSeconds(0.1f);

    void Start()
    {
        _nav = gameObject.GetComponent<NavMeshAgent>();

        StartCoroutine(Movement());
    }

    private IEnumerator Movement()
    {
        while (true) 
        {
            _nav.SetDestination(Player.transform.position);

            yield return wfs;
        }
    }
}
