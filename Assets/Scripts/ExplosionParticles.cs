using System.Collections;
using UnityEngine;

public class ExplosionParticles : MonoBehaviour
{
    IEnumerator Start()
    {
        var particles = GetComponent<ParticleSystem>();
        yield return new WaitForSeconds(particles.main.duration);
        Destroy(gameObject);
    }
}
