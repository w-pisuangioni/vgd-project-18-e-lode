using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPath_Casa : MonoBehaviour {
    public Transform[] path;
    public float speed = 1.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;

    public AudioSource footsteps;
    private Vector3 temp;

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
            if (Path().magnitude <= reachDist && enemys == 0)
            {
                currentPoint++;
                  if (temp != transform.position)
                      footsteps.Play();
                  else
                      footsteps.Stop();
            }
            

        }
        else
        {
            footsteps.Stop();
        }

    }

    private Vector3 Path()
    {
        return path[currentPoint].position - transform.position;
    }

    private void FixedUpdate()
    {   float smooth;
        float tiltAngle;
        float tiltAroundY;
        Quaternion target;
         switch (currentPoint) {
          case 0:
              break;
          case 1:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 0.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
          //1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111

          case 6:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 180.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);

           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
          //66666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666
              
          case 7:
          // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 10f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);

          //Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
          //77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777

          case 8:
          // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 0.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);

          //Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
          //
          case 9:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 65.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
          case 10:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 180.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
         case 11:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 0.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
       case 13:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 25.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

       case 14:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 80.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

       case 15:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 180.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
    case 16:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 0.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
        case 20:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -60.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
       case 21:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -80.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
      case 23:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -90.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
      case 24:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -100.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
      case 25:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -120.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
      case 26:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -150.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
      case 27:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -90.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
      case 29:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -155.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
      case 30:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -165.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
        case 31:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -180.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
         case 32:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -195.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
         case 33:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -220.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
         case 34:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -240.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

         case 35:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -275.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

            case 37:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 0.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

            case 41:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -85.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

            case 42:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -90.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

            case 43:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -155.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

            case 44:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -165.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

            case 45:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -180.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

           case 46:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -195.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

           case 47:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -220.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;


           case 48:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -240.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;


           case 49:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -275.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 50:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 0.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 51:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 120.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 53:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 80.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 54:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 50.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 55:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 40.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

           case 56:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 25.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

           case 57:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 15.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

           case 60:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = -85.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

           case 61:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 0.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 62:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 60.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

           case 63:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 75.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 64:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 100.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 65:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 200.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 67:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 260.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;

           case 68:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 0.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
              break;
           case 69:
           // Smoothly tilts a transform towards a target rotation;
              smooth = 1.0f;
              tiltAngle = 120.0f;
              tiltAroundY = 1.0f * tiltAngle;

              target = Quaternion.Euler(0, tiltAroundY, 0);
           // Dampen towards the target rotation
              transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
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
