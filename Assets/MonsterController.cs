﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class MonsterController : NetworkBehaviour {

    private NavMeshAgent agent;
    private NetworkIdentity m_Identity;
    private GameObject target;
    private float distanceToTarget;

    private Animator m_Animator;
    private float m_ForwardAmount;
    private bool m_Attack;
    private float attackTimer;

    public int m_Damage;
    private BoxCollider attackCollider;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_Identity = GetComponent<NetworkIdentity>();
        m_Animator = GetComponent<Animator>();
        attackCollider = GetComponent<BoxCollider>();

        agent.updateRotation = true;
        agent.updatePosition = true;
    }

    private void Update()
    {
        SearchTarget();
        attackTimer += Time.deltaTime;

        if (target != null)
        {
            m_ForwardAmount = agent.velocity.magnitude;
            agent.SetDestination(target.transform.position);
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (attackTimer >= 2f)
            {
                attackTimer = 0;
                StartCoroutine("AttackTarget");
            }
            
        }
        else
        {
            m_Animator.SetBool("Attack", false);
        }
    }

    public void SearchTarget()
    {
        GameObject[] nexusList = GameObject.FindGameObjectsWithTag("Nexus");
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Unit");

        float offset = 0;

        for (int i = 0; i < nexusList.Length; i++)
        {
            //if (m_Identity.clientAuthorityOwner.Equals(nexusList[i].GetComponent<NexusStatus>().GetOwner()))
            //{
            //    continue;
            //}

            float tempOffset = Vector3.Distance(this.transform.position, nexusList[i].transform.position);
            if (i == 0)
            {
                offset = tempOffset;
                target = nexusList[i];
            }
            else
            {
                if (offset.CompareTo(tempOffset) > 0)
                {
                    offset = tempOffset;
                    target = nexusList[i];
                }
            }
        }
    }

    private void MoveAgent()
    {
        
    }

    IEnumerator AttackTarget()
    {
        m_Attack = true;
        UpdateAnimator();

        yield return new WaitForSeconds(1f);
        attackCollider.enabled = true;

        yield return new WaitForSeconds(0.3f);

        m_Attack = false;
        attackCollider.enabled = false;
        UpdateAnimator();
    }

    public void Die()
    {
        m_Animator.SetTrigger("Die");
        agent.isStopped = true;
        StartCoroutine("DestroyDelay");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        if (other.tag == "Unit")
        {
            other.GetComponent<UnitHealth>().TakeDamage(m_Damage);
        }
        else if (other.tag == "Nexus")
        {
            other.GetComponent<NexusStatus>().TakeDamage(m_Damage);
        }
    }

    void UpdateAnimator()
    {
        // update the animator parameters
        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        m_Animator.SetBool("Attack", m_Attack);
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
