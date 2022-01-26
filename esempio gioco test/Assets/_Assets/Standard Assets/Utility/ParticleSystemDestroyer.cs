using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Utility
{
    public class ParticleSystemDestroyer : MonoBehaviour
    {
        // allows a particle system to exist for a specified duration,
        // then shuts off emission, and waits for all particles to expire
        // before destroying the gameObject

        public float minDuration = 8;
        public float maxDuration = 10;

        private float m_MaxLifetime;
<<<<<<< HEAD
        private bool m_EarlyStop;


=======
       // private bool m_EarlyStop;

/*
>>>>>>> test-scene
        private IEnumerator Start()
        {
            var systems = GetComponentsInChildren<ParticleSystem>();

            // find out the maximum lifetime of any particles in this effect
            foreach (var system in systems)
            {
<<<<<<< HEAD
                m_MaxLifetime = Mathf.Max(system.main.startLifetime.constant, m_MaxLifetime);
=======
                m_MaxLifetime = Mathf.Max(system.startLifetime, m_MaxLifetime);
>>>>>>> test-scene
            }

            // wait for random duration

            float stopTime = Time.time + Random.Range(minDuration, maxDuration);

<<<<<<< HEAD
            while (Time.time < stopTime && !m_EarlyStop)
=======
            while (Time.time < stopTime || m_EarlyStop)
>>>>>>> test-scene
            {
                yield return null;
            }
            Debug.Log("stopping " + name);

            // turn off emission
            foreach (var system in systems)
            {
<<<<<<< HEAD
                var emission = system.emission;
                emission.enabled = false;
=======
                system.enableEmission = false;
>>>>>>> test-scene
            }
            BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);

            // wait for any remaining particles to expire
            yield return new WaitForSeconds(m_MaxLifetime);

            Destroy(gameObject);
        }
<<<<<<< HEAD

=======
        */
>>>>>>> test-scene

        public void Stop()
        {
            // stops the particle system early
<<<<<<< HEAD
            m_EarlyStop = true;
=======
           // m_EarlyStop = true;
>>>>>>> test-scene
        }
    }
}
