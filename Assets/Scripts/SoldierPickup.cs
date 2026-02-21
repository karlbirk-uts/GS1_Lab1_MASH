using System;
using UnityEngine;

public class SoldierPickup : MonoBehaviour
{
    
    // private SceneManagerMASH sceneManagerMash;
    private SceneManagerMASH sceneManagerMASH;
    // public GameObject sceneManagerMASHGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManagerMASH = GameObject.FindGameObjectWithTag("SceneManagerMASH").GetComponent<SceneManagerMASH>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2DObject)
    {
        if (collider2DObject.gameObject.tag == "Soldier")
        {
            sceneManagerMASH.SoldiersInField--;
            Destroy(collider2DObject.gameObject);
            print("Hit Trigger: Soldier");
        }
    }
}
