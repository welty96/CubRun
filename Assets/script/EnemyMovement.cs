using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _nav;
    private GameObject Player;
    public GameObject Panel_GameOver;
    // Start is called before the first frame update
    void Start()
    {
        _nav = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _nav.SetDestination(Player.transform.position);
        float Dist_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position); 
        if (Dist_Player < 1)
        {
            Player.SetActive(false);
            Panel_GameOver.SetActive(true);
        }
    }
}
