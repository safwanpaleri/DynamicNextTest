using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnManager : MonoBehaviour
{
    public GameObject BlueEnemy;
    public GameObject RedEnemy;
    [SerializeField] private CanvasManager canvasManager;

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
                var newBlueEnemy = Instantiate(BlueEnemy, hit.point, Quaternion.identity);
                var newBlueEnemyScript = newBlueEnemy.GetComponent<EnemyScript>();

                if(newBlueEnemyScript != null)
                    newBlueEnemyScript.isBlue = true;

                var RandInt = Random.Range(5000, 15000);
                newBlueEnemy.name = "BlueEnemy_" + RandInt;
                canvasManager.CreateUI(newBlueEnemy.name, newBlueEnemy.name + " spawned in the field", "Blue");
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
                // Spawn the red unit prefab at the hit position
                var newRedEnemy = Instantiate(RedEnemy, hit.point, Quaternion.identity);

                //writing UI into Events tab
                var RandInt = Random.Range(5000, 15000);
                newRedEnemy.name = "RedEnemy_" + RandInt;
                canvasManager.CreateUI(newRedEnemy.name, newRedEnemy.name + " spawned in the field", "Red");
            }
        }
    }
}
