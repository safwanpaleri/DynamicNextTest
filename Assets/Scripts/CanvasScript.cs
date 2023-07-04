using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A small script attached to canvas so that Health and other UI always face towards the camera.
public class CanvasScript : MonoBehaviour
{
    //references to camera to face tpwards
    [SerializeField] private Transform TargetTransform;
    // Start is called before the first frame update

    private void Start()
    {
        //taking the reference as the object only present in the scene, will not be attached when spawned.
        TargetTransform = FindAnyObjectByType<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Code to always face towards the camera.
        gameObject.transform.LookAt(TargetTransform);
    }
}
