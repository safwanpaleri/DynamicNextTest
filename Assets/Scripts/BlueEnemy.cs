using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherited script of Enemy specific to blue, so that we can implement specific to this enemy if we want.
public class BlueEnemy : EnemyScript
{
    // References of enemies.
    // as we are blue we take Red as the enemies
    private RedEnemy[] RedEnemies;
    private RedEnemy currentEnemy;

    // Update is called once per frame
    void Update()
    {
        //Finding all the red enemies
        //if the found we will randomly select a enemy and start attacking it until its dead.
        // then if we are still alive then we will find and attack next enemy.
        if(isDead)
            return;

        RedEnemies = FindObjectsOfType<RedEnemy>();
        if (RedEnemies.Length > 0)
        {
            if (currentEnemy != null)
            {
                LookAndMove(currentEnemy);
            }
            else
            {
                var rand = Random.Range(0, RedEnemies.Length);
                currentEnemy = RedEnemies[rand];
                LookAndMove(currentEnemy);
            }
        }
    }
}
