using System;
using UnityEngine;

public class SoldierRescueSystem : MonoBehaviour
{
    private SceneManagerMASH sceneManagerMASH;

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
            if (sceneManagerMASH.SoldiersInHelicopter < 3)
            {
                --sceneManagerMASH.SoldiersInField;
                Destroy(collider2DObject.gameObject);
                print("Hit Trigger: Soldier");
                ++sceneManagerMASH.SoldiersInHelicopter;
            }

        }
        else if (collider2DObject.gameObject.tag == "Hospital")
        {
            sceneManagerMASH.SoldiersInHospital += sceneManagerMASH.SoldiersInHelicopter;
            sceneManagerMASH.SoldiersInHelicopter = 0;
            print("Hit Trigger: Hospital");
        }
        else if (collider2DObject.gameObject.tag == "Tree")
        {
            print("Hit Trigger: Tree");
        }
        else
        {
            print("Hit Trigger: UNKNOWN HIT TRIGGER");
        }
    }
}