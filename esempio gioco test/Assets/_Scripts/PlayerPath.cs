using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPath : MonoBehaviour {
    public Transform[] path;
    public float speed = 1.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;
    public int pickups;
    public AudioSource footsteps;
    private Vector3 temp;
    public Image fade;
    public Canvas fadeC;

    private static int lvlAttuale;
    public static int enemySpwn = 0;

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
        switch (SceneManager.GetActiveScene().name) {
            case "Main":
                lvlAttuale = 1;
                LevelOne();
                break;
            case "Village":
                lvlAttuale = 2;
                LevelTwo();
                break;
            case "Level3":
                lvlAttuale = 3;
                LevelThree();
                break;
            case "Casa_abbandonata":
                lvlAttuale = 4;
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
    IEnumerator Fading()
    {
        yield return new WaitForSeconds(4.35f);
        SceneManager.LoadScene("LevelEnd");
       // MenuManager.IncLevelNumber();
    }

    private void LevelOne()
    {
        switch (currentPoint)
        {
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

                Quaternion target3 = Quaternion.Euler(0, tiltAroundY3, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target3, Time.deltaTime * smooth3);
                break;
            case 6:
                float smooth5 = 1.0f;
                float tiltAngle5 = 60.0f;
                float tiltAroundY5 = 1.0f * tiltAngle5;

                Quaternion target6 = Quaternion.Euler(0, tiltAroundY5, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target6, Time.deltaTime * smooth5);
                break;
            case 7:
                float smooth7 = 1.0f;
                float tiltAngle7 = 0.0f;
                float tiltAroundY7 = 1.0f * tiltAngle7;

                Quaternion target7 = Quaternion.Euler(0, tiltAroundY7, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target7, Time.deltaTime * smooth7);
                break;
            case 11:
                fadeC.gameObject.SetActive(true);
                StartCoroutine(Fading());
                break;

        }
    }

    private void LevelTwo()
    {
        switch (currentPoint)
        {
            case 1:
                // Smoothly tilts a transform towards a target rotation.
                float smooth = 1.0f;
                float tiltAngle = -25.0f;
                float tiltAroundY = 1.0f * tiltAngle;

                Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                break;
            case 2:
                // Smoothly tilts a transform towards a target rotation.
                float smooth2 = 1.0f;
                float tiltAngle2 = -25.0f;
                float tiltAroundY2 = 1.0f * tiltAngle2;

                Quaternion target2 = Quaternion.Euler(10, tiltAroundY2, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target2, Time.deltaTime * smooth2);
                break;
            case 3:
                // Smoothly tilts a transform towards a target rotation.
                float smooth3 = 1.0f;
                float tiltAngle3 = 10.0f;
                float tiltAroundY3 = 1.0f * tiltAngle3;

                Quaternion target3 = Quaternion.Euler(15, tiltAroundY3, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target3, Time.deltaTime * smooth3);
                break;
            case 6:
                // Smoothly tilts a transform towards a target rotation.
                float smooth6 = 1.0f;
                float tiltAngle6 = 30.0f;
                float tiltAroundY6 = 1.0f * tiltAngle6;

                Quaternion target6 = Quaternion.Euler(15, tiltAroundY6, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target6, Time.deltaTime * smooth6);
                break;
            case 7:
                // Smoothly tilts a transform towards a target rotation.
                float smooth7 = 1.0f;
                float tiltAngle7 = 40.0f;
                float tiltAroundY7 = 1.0f * tiltAngle7;

                Quaternion target7 = Quaternion.Euler(15, tiltAroundY7, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target7, Time.deltaTime * smooth7);
                break;
            case 9:
                // Smoothly tilts a transform towards a target rotation.
                float smooth9 = 1.0f;
                float tiltAngle9 = -10.0f;
                float tiltAroundY9 = 1.0f * tiltAngle9;

                Quaternion target9 = Quaternion.Euler(5, tiltAroundY9, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target9, Time.deltaTime * smooth9);
                break;
            case 10:
                // Smoothly tilts a transform towards a target rotation.
                float smooth10 = 1.0f;
                float tiltAngle10 = -25f;
                float tiltAroundY10 = 1.0f * tiltAngle10;

                Quaternion target10 = Quaternion.Euler(5, tiltAroundY10, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target10, Time.deltaTime * smooth10);
                break;
            case 11:
                // Smoothly tilts a transform towards a target rotation.
                float smooth11 = 1.0f;
                float tiltAngle11 = -15f;
                float tiltAroundY11 = 1.0f * tiltAngle11;

                Quaternion target11 = Quaternion.Euler(0, tiltAroundY11, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target11, Time.deltaTime * smooth11);
                break;
            case 12:
                // Smoothly tilts a transform towards a target rotation.
                float smooth12 = 1.0f;
                float tiltAngle12 = 10f;
                float tiltAroundY12 = 1.0f * tiltAngle12;

                Quaternion target12 = Quaternion.Euler(5, tiltAroundY12, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target12, Time.deltaTime * smooth12);
                break;
            case 13:
                // Smoothly tilts a transform towards a target rotation.
                float smooth13 = 1.0f;
                float tiltAngle13 = 10f;
                float tiltAroundY13 = 1.0f * tiltAngle13;

                Quaternion target13 = Quaternion.Euler(0, tiltAroundY13, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target13, Time.deltaTime * smooth13);
                break;
            case 14:
                // Smoothly tilts a transform towards a target rotation.
                float smooth14 = 1.0f;
                float tiltAngle14 = 10f;
                float tiltAroundY14 = 1.0f * tiltAngle14;

                Quaternion target14 = Quaternion.Euler(-5, tiltAroundY14, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target14, Time.deltaTime * smooth14);
                break;
            case 15:
                fadeC.gameObject.SetActive(true);
                StartCoroutine(Fading());
                break;

        }


    }

    private void LevelThree()
    {
        switch (currentPoint)
        {
            case 5:
                float smooth5 = 1.0f;
                float tiltAngle5 = 0f;
                float tiltAroundY5 = 1.0f * tiltAngle5;

                Quaternion target5 = Quaternion.Euler(0, tiltAroundY5, 0);
                //transform.rotation = Quaternion.Slerp(transform.rotation, target5, Time.deltaTime * smooth5);
                // Dampen towards the target rotation
                switch (enemySpwn) {
                    case 3: transform.rotation = Quaternion.Slerp(transform.rotation, target5, Time.deltaTime * smooth5);break;
                    case 2: transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 65f, 0), Time.deltaTime * smooth5);break;
                    case 1: transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90f, 0), Time.deltaTime * smooth5);break;
                }
                break;
            case 6:
                // Smoothly tilts a transform towards a target rotation.
                float smooth6 = 1.0f;
                float tiltAngle6 = -90.0f;
                float tiltAroundY6 = 1.0f * tiltAngle6;

                Quaternion target6 = Quaternion.Euler(0, tiltAroundY6, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target6, Time.deltaTime * smooth6);
                break;
            case 8:
                // Smoothly tilts a transform towards a target rotation.
                float smooth8 = 1.0f;
                float tiltAngle8 = -75.0f;
                float tiltAroundY8 = 1.0f * tiltAngle8;

                Quaternion target8 = Quaternion.Euler(0, tiltAroundY8, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target8, Time.deltaTime * smooth8);
                break;
            case 10:
                float smooth10 = 1.0f;
                float tiltAngle10 = -75.0f;
                float tiltAroundY10 = 1.0f * tiltAngle10;

                Quaternion target10 = Quaternion.Euler(0, tiltAroundY10, 0);
                //transform.rotation = Quaternion.Slerp(transform.rotation, target5, Time.deltaTime * smooth5);
                // Dampen towards the target rotation
                switch (enemySpwn)
                {
                    case 6: transform.rotation = Quaternion.Slerp(transform.rotation, target10, Time.deltaTime * smooth10); break;
                    case 4: transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * smooth10); break;
                    case 2: transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 200f, 0), Time.deltaTime * smooth10); break;
                }
                break;
            case 11:
                // Smoothly tilts a transform towards a target rotation.
                float smooth11 = 1.0f;
                float tiltAngle11 = 20f;
                float tiltAroundY11 = 1.0f * tiltAngle11;

                Quaternion target11 = Quaternion.Euler(0, tiltAroundY11, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target11, Time.deltaTime * smooth11);
                break;
            case 12:
                // Smoothly tilts a transform towards a target rotation.
                float smooth12 = 1.0f;
                float tiltAngle12 = 25f;
                float tiltAroundY12 = 1.0f * tiltAngle12;

                Quaternion target12 = Quaternion.Euler(0, tiltAroundY12, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target12, Time.deltaTime * smooth12);
                break;
            case 13:
                // Smoothly tilts a transform towards a target rotation.
                float smooth13 = 1.0f;
                float tiltAngle13 = -80f;
                float tiltAroundY13 = 1.0f * tiltAngle13;

                Quaternion target13 = Quaternion.Euler(0, tiltAroundY13, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target13, Time.deltaTime * smooth13);
                break;
            case 14:
                // Smoothly tilts a transform towards a target rotation.
                float smooth14 = 1.0f;
                float tiltAngle14 = -90f;
                float tiltAroundY14 = 1.0f * tiltAngle14;

                Quaternion target14 = Quaternion.Euler(0, tiltAroundY14, 0);

                // Dampen towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, target14, Time.deltaTime * smooth14);
                break;
            case 15:
                fadeC.gameObject.SetActive(true);
                StartCoroutine(Fading());
                break;
        }
    }
    public static int GetLvlAttuale()
    {
        return lvlAttuale;
    }
}
