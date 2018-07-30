using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;

    private GameObject target;
    private float distanceToTarget;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.updateRotation = false;
        agent.updatePosition = true;
    }

    private void Update()
    {
        SearchTarget();

        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
        
        //if (agent.remainingDistance > agent.stoppingDistance)
        //{
        //    agent.Move(target.transform.position);
        //}
        //else
        //{

        //}
    }

    private void SearchTarget()
    {
        GameObject[] targetList = GameObject.FindGameObjectsWithTag("Nexus");

        float offset = 0;

        for (int i = 0; i < targetList.Length; i++)
        {
            float tempOffset = Vector3.Distance(this.transform.position, targetList[i].transform.position);
            if (i == 0)
            {
                offset = tempOffset;
                target = targetList[i];
            }
            else
            {
                if (offset.CompareTo(tempOffset) > 0)
                {
                    offset = tempOffset;
                    target = targetList[i];
                }
            }
        }
    }

    private void MoveAgent()
    {
        
    }

    private void AttackTarget()
    {

    }
}
