using System;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierRescueSystem : MonoBehaviour
{
    private SceneManagerMASH sceneManagerMASH;
    // public AudioClip collectSoldierSFXClip;
    private AudioSource collectSoldierSFX;
    // audio.PlayOneShot((AudioClip)Resources.Load(“clank1”));

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManagerMASH = GameObject.FindGameObjectWithTag("SceneManagerMASH").GetComponent<SceneManagerMASH>();
        // collectSoldierSFXClip = GetComponent<AudioClip>();
        // collectSoldierSFX.clip = collectSoldierSFXClip;
        // AudioSource audio = gameObject.addComponent();
        // collectSoldierSFX.AddComponent<AudioSource>();
        collectSoldierSFX = GetComponent<AudioSource>();
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
                // collectSoldierSFX.PlayOneShot();
                collectSoldierSFX.Play();
                sceneManagerMASH.updateScoreText();
            }
        }
        else if (collider2DObject.gameObject.tag == "Hospital")
        {
            sceneManagerMASH.SoldiersInHospital += sceneManagerMASH.SoldiersInHelicopter;
            sceneManagerMASH.SoldiersInHelicopter = 0;
            print("Hit Trigger: Hospital");
            sceneManagerMASH.updateScoreText();

        }
        else if (collider2DObject.gameObject.tag == "Tree")
        {
            print("Hit Trigger: Tree");
            sceneManagerMASH.endGameDeath();
        }
        else
        {
            print("Hit Trigger: UNKNOWN HIT TRIGGER");
        }
    }
}