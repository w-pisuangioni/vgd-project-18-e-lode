using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemy;
    public Transform enemyPos;
    private float repeatRate = 5.0f;
    public int range = 1;
    private int rangePriv = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    private void OnTriggerEnter(Collider other)
    {
        rangePriv = Random.Range(1, range);
        if (other.gameObject.tag == "Player" && rangePriv == 1 )
        {
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            Destroy(gameObject, 1);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void EnemySpawner()
    {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);
    }
}
