using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] Material RedMaterial;
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] EnemyPool enemyPool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse position to the world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

           

            // Perform the raycast and check if it hits something
            if (Physics.Raycast(ray, out hit))
            {
                //Checking if the raycast hitted on a UI, if hitted on Ui element don't spawn
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }

                // Spawn the blue unit prefab at the hit position
                if(enemyPool != null)
                {
                    var NewBlueEnemy = enemyPool.GetEnemyFromPool();
                    var NewBlueEnemyScript = NewBlueEnemy.GetComponent<EnemyScript>();
                    NewBlueEnemyScript.isActive = true;
                    NewBlueEnemy.transform.position = hit.point;
                    NewBlueEnemy.transform.rotation = Quaternion.identity;
                    NewBlueEnemyScript.isBlue = true;
                    var RandInt = Random.Range(5000, 15000);
                    NewBlueEnemy.name = "BlueEnemy_" + RandInt;
                    if (canvasManager != null)
                        canvasManager.CreateUI(NewBlueEnemy.name, NewBlueEnemy.name + " spawned in the field", "Blue");
                }
                else
                {
                    var newBlueEnemy = Instantiate(EnemyPrefab, hit.point, Quaternion.identity);
                    var newBlueEnemyScript = newBlueEnemy.GetComponent<EnemyScript>();

                    if (newBlueEnemyScript != null)
                        newBlueEnemyScript.isBlue = true;

                    var RandInt = Random.Range(5000, 15000);
                    newBlueEnemy.name = "BlueEnemy_" + RandInt;

                    if (canvasManager != null)
                        canvasManager.CreateUI(newBlueEnemy.name, newBlueEnemy.name + " spawned in the field", "Blue");
                }
                
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // Raycast from the mouse position to the world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast and check if it hits something
            if (Physics.Raycast(ray, out hit))
            {
                if (enemyPool != null)
                {
                    var NewRedEnemy = enemyPool.GetEnemyFromPool();
                    NewRedEnemy.GetComponentInChildren<SkinnedMeshRenderer>().material = RedMaterial;
                    var NewRedEnemyScript = NewRedEnemy.GetComponent<EnemyScript>();
                    NewRedEnemyScript.isActive = true;
                    NewRedEnemy.transform.position = hit.point;
                    NewRedEnemy.transform.rotation = Quaternion.identity;

                    var RandInt = Random.Range(5000, 15000);
                    NewRedEnemy.name = "RedEnemy_" + RandInt;
                    if (canvasManager != null)
                        canvasManager.CreateUI(NewRedEnemy.name, NewRedEnemy.name + " spawned in the field", "Red");
                }
                else
                {
                    // Spawn the red unit prefab at the hit position
                    var newRedEnemy = Instantiate(EnemyPrefab, hit.point, Quaternion.identity);
                    newRedEnemy.GetComponentInChildren<SkinnedMeshRenderer>().material = RedMaterial;

                    //writing UI into Events tab
                    var RandInt = Random.Range(5000, 15000);
                    newRedEnemy.name = "RedEnemy_" + RandInt;
                    if (canvasManager != null)
                        canvasManager.CreateUI(newRedEnemy.name, newRedEnemy.name + " spawned in the field", "Red");
                }    
                
                
            }
        }
    }
}
