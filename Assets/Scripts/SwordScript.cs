using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is attached to the sword.
public class SwordScript : MonoBehaviour
{
    //Taking reference to the script which attached with the parent of this gameobject.
    [SerializeField] EnemyScript enemyScript;


    //When the sword get collided with an enemy then it will damage the enemy according to the damage given in the script 
    //attached to this object
    //Also send the attacking enemy game object for further purposes
    private void OnCollisionEnter(Collision collision)
    { 
        if (!enemyScript.isDead && enemyScript.isAttacking && collision.gameObject != this.gameObject && !enemyScript.isTakingDamage)
        {
            var CollisionGameobjectEnemyScript = collision.gameObject.GetComponent<EnemyScript>();
            CollisionGameobjectEnemyScript.TakeDamage(enemyScript.Damage,enemyScript.gameObject);

        }
    }

}
