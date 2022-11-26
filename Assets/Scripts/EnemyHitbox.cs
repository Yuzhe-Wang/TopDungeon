using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collectable
{
    // damage
    public int enemyDamage = 1;
    public float pushForce = 1;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.CompareTag("Fighter") && coll.name == "Player")
        {
            // create a new damage object, before sending it to the player
            Damage damage = new Damage();
            damage.damageAmount = enemyDamage;
            damage.origin = transform.position;
            damage.pushForce = pushForce;

            coll.SendMessage("ReceiveDamage", damage);
        }
    }
}
