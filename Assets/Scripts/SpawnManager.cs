using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject BlueEnemy;
    public GameObject RedEnemy;

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
                // Spawn the blue unit prefab at the hit position
                Instantiate(BlueEnemy, hit.point, Quaternion.identity);
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
                Instantiate(RedEnemy, hit.point, Quaternion.identity);
            }
        }
    }
}
