using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPath : MonoBehaviour {
    public Transform[] path;
    public float speed = 1.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;
    public int pickups;
    public AudioSource footsteps;
    public Vector3 temp;

    void Start()
    {

    }

    void Update()
    {
        temp = transform.position;
        //Vector3 dir = Path();
        if (path.Length > currentPoint)
        {
            transform.position += Path() * Time.deltaTime * speed;
            int enemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
            pickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

            if (Path().magnitude <= reachDist && enemys == 0 && pickups == 0)//continua solo se ci sono 0 mostri e 0 drop
            {
                currentPoint++;
                if (temp != transform.position)
                    footsteps.Play();
                else
                    footsteps.Stop();
            }
        }
        else
            footsteps.Stop();
    }

    private Vector3 Path()
    {
        return path[currentPoint].position - transform.position;
    }

    private void FixedUpdate()
    {
            switch (currentPoint) {
            case 2:
                // Smoothly tilts a transform towards a target rotation.
                float smooth = 1.0f;
                float tiltAngle = 60.0f;
                float tiltAroundY = 1.0f * tiltAngle;

                Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                break;
            case 4:
                float smooth3 = 1.0f;
                float tiltAngle3 = 0.0f;
                float tiltAroundY3 = 1.0f * tiltAngle3;

                Quaternion target3= Quaternion.Euler(0, tiltAroundY3, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target3, Time.deltaTime * smooth3);
                break;
            case 5:
                float smooth5 = 1.0f;
                float tiltAngle5 = 60.0f;
                float tiltAroundY5 = 1.0f * tiltAngle5;

                Quaternion target6 = Quaternion.Euler(0, tiltAroundY5, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target6, Time.deltaTime * smooth5);
                break;
            case 6:
                SceneManager.LoadScene("LevelEnd");
                MenuManager.IncLevelNumber();
                break;
                
        }
}

    private void OnDrawGizmos()
    {
        if (path.Length > 0)
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, 1.0f);
                }
            }
    }
}
