using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator animator;

    public LayerMask enemyLayers;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    void Update()
    {
        if (Input.GetKeyDown("g") == true)
        {
            Hit();
        }
    }

    void Hit()
    {
        animator.SetTrigger("isAttacking");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
