using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ResourceHealth : MonoBehaviour
{
    public int startHealth;
    public int health;
    public float destroyTime = 5f;
    public ItemScriptableObject resourceType;
    [SerializeField] private string spawnerName = "TreeSpawner";
    public GameObject rockFX;
 
    public void Start()
    {

        health = startHealth;
    }
    public void TreeFall()
    {
        gameObject.AddComponent<Rigidbody>();
        Rigidbody rig = GetComponent<Rigidbody>();
        rig.isKinematic = false;
        rig.useGravity = true;
        rig.mass = 200;
        rig.constraints = RigidbodyConstraints.FreezeRotationY;

        Destroy(gameObject, destroyTime);
 
        
 
    }
    public void StoneGathered()
    {
        Vector3 spawnPosition;
        if(transform.parent.parent == null)
        {
            spawnPosition = transform.position;
        }
        else
        {
            spawnPosition = transform.parent.position;
        }
        Instantiate(rockFX, spawnPosition, Quaternion.identity);
        Destroy(gameObject);
    }
 
}