using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "Casa_abbandonata")
            enemy.transform.localScale = new Vector3(1, 1, 1);
        else
            enemy.transform.localScale = new Vector3(4, 4, 4);

        Instantiate(enemy, enemyPos.position, enemyPos.rotation);
        if (enemy.tag != "Pickup")
            PlayerPath.enemySpwn++;
    }
}
