using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class NetworkedHorrorAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public string PlayerTag = "Player";
    public Transform[] points;
    public float DetectionRange = 5f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetWanderDestination();
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag(PlayerTag);
            GameObject target = null;

            if (players.Length > 0)
            {
                float minDistance = float.MaxValue;
                foreach (GameObject player in players)
                {
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        target = player;
                    }
                }
            }

            if (target != null && Vector3.Distance(transform.position, target.transform.position) < DetectionRange)
            {
                Chase(target.transform.position);
            }
            else
            {
                Wander();
            }
        }
    }

    void Wander()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetWanderDestination();
        }
    }

    void SetWanderDestination()
    {
        if (points.Length == 0)
            return;

        int destPoint = Random.Range(0, points.Length);
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void Chase(Vector3 targetPosition)
    {
        agent.destination = targetPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
    }
}
