using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;
    public GameObject enemyPrefab;

    [SerializeField] private List<GameObject> enemyPool = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        for(int i=0; i<10; i++)
        {
            var newEnemy = Instantiate(enemyPrefab,this.transform);
            EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();
            enemyPool.Add(newEnemy);
        }
    }

    public GameObject GetEnemyFromPool()
    {
        foreach(var enemy in enemyPool)
        {
            if(!enemy.GetComponent<EnemyScript>().isActive)
            {
                return enemy;
            }
        }

        var newEnemy = Instantiate(enemyPrefab, this.transform);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
