using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPath : MonoBehaviour {
    public Transform[] path;
    public float speed = 1.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;
    

    void Start()
    {
        
    }

    void Update()
    {
        //Vector3 dir = Path();
        if (path.Length > currentPoint)
        {
            transform.position += Path() * Time.deltaTime * speed;
            int enemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (Path().magnitude <= reachDist && enemys == 0)
            {
                currentPoint++;
            }
        }
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
            case 3:
                float smooth3 = 1.0f;
                float tiltAngle3 = 0.0f;
                float tiltAroundY3 = 1.0f * tiltAngle3;

                Quaternion target3= Quaternion.Euler(0, tiltAroundY3, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target3, Time.deltaTime * smooth3);
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
