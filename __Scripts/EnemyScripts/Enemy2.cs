using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : enemyMove
{
    public float veloctiy = 2.5f;

    Enemy enemy;
    Transform player;
    Rigidbody2D rb;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtPlayer();

        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, rb.velocity, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }
}
