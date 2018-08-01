using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonAttack : MonoBehaviour {

    private float attackTimer;
    private Transform burningPosition;
    private ParticleSystem burningEffect;
    private GameObject target;

    private void Start()
    {
        burningEffect = GetComponentInChildren<ParticleSystem>();
        burningPosition = burningEffect.transform;
    }

    private void Update()
    {
        GetComponent<MonsterController>().SearchTarget();
        Vector3 offset = (target.transform.position - transform.position);

        burningPosition.Rotate(offset);
        
        attackTimer += Time.deltaTime;
        if (attackTimer >= 3f)
        {
            attackTimer = 0;
            StartCoroutine("BurnAttack");
        }
    }

    IEnumerator BurnAttack()
    {
        burningPosition.gameObject.SetActive(true);
        burningEffect.Play();
        yield return new WaitForSeconds(2f);
        burningEffect.Stop();
        burningPosition.gameObject.SetActive(false);
    }
}
