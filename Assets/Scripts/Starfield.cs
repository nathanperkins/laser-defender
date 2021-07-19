using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    [SerializeField] float minStartSpeed;
    [SerializeField] float maxStartSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem p = GetComponent<ParticleSystem>();
        var v = p.main;
        v.startSpeed = new ParticleSystem.MinMaxCurve(minStartSpeed, maxStartSpeed);
    }
}
