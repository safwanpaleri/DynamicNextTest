using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherited script of Enemy specific to Red, so that we can implement specific to this enemy if we want.
public class RedEnemy : EnemyScript
{
    // References of enemies.
    // as we are Red we take Blue as the enemies
    private BlueEnemy[] BlueEnemies;
    private BlueEnemy currentEnemy;

    // Update is called once per frame
    void Update()
    {
        //Finding all the blue enemies
        //if the found we will randomly select a enemy and start attacking it until its dead.
        // then if we are still alive then we will find and attack next enemy.
        if (isDead)
            return;

        BlueEnemies = FindObjectsOfType<BlueEnemy>();
        if (BlueEnemies.Length > 0)
        {
            if (currentEnemy != null)
            {
                LookAndMove(currentEnemy);
            }
            else
            {
                var rand = Random.Range(0, BlueEnemies.Length);
                currentEnemy = BlueEnemies[rand];
                LookAndMove(currentEnemy);
            }
        }
    }
}
