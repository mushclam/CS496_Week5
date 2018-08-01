using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class MonsterController : NetworkBehaviour {

    private NavMeshAgent agent;
    [SyncVar] private NetworkIdentity m_Identity;
    [SyncVar] private GameObject target;
    [SyncVar] private float distanceToTarget;

    private Animator m_Animator;
    private float m_ForwardAmount;
    private bool m_Attack;
    private float attackTimer;

    public int m_Damage;
    private BoxCollider attackCollider;

    public GameObject SummonSound;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_Identity = GetComponent<NetworkIdentity>();
        m_Animator = GetComponent<Animator>();
        attackCollider = GetComponent<BoxCollider>();

        agent.updateRotation = true;
        agent.updatePosition = true;
        Instantiate(SummonSound);
    }

    private void Update()
    {
        if (hasAuthority)
        {
            CmdSearchTarget();
            attackTimer += Time.deltaTime;

            if (target != null && agent.remainingDistance <= agent.stoppingDistance)
            {
                AttackTarget();
            }
            else
            {
                m_Animator.SetBool("Attack", false);
            }
        }
    }

    [Command]
    public void CmdSearchTarget()
    {
        GameObject[] nexusList = GameObject.FindGameObjectsWithTag("Nexus");

        float offset = float.MaxValue;

        for (int i = 0; i < nexusList.Length; i++)
        {
            if (m_Identity.clientAuthorityOwner
                .Equals(nexusList[i].GetComponent<NexusStatus>().GetOwner()))
            {
                continue;
            }

            float tempOffset = Vector3.Distance(this.transform.position, nexusList[i].transform.position);

            if (offset.CompareTo(tempOffset) > 0)
            {
                offset = tempOffset;
                target = nexusList[i];
            }
        }

        RpcMoveAgent();
    }

    [ClientRpc]
    private void RpcMoveAgent()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    private void AttackTarget()
    {
        if (attackTimer >= 2f)
        {
            attackTimer = 0;
            GetComponent<AudioSource>().Play();
            StartCoroutine("AttackAnim");
        }
    }

    IEnumerator AttackAnim()
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

    [ClientRpc]
    public void RpcDie()
    {
        m_Animator.SetTrigger("Die");
        agent.isStopped = true;
        StartCoroutine("DestroyDelay");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<NetworkIdentity>().hasAuthority)
        {
            if (other.tag == "Unit")
            {
                other.GetComponent<UnitHealth>().CmdTakeDamage(m_Damage);
            }
            else if (other.tag == "Nexus")
            {
                other.GetComponent<NexusStatus>().CmdTakeDamage(m_Damage);
            }
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
