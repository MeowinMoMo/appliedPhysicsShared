using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnEarth : MonoBehaviour
{
    
    
    [SerializeField] float gravitaionalPull_;
    [SerializeField] float intensity;
    [SerializeField] float mindept;

    List<Collider2D> planets;

    float distance;

    private LayerMask layer;

    // Update is called once per frame
    void Update()
    {
        var circle = Physics2D.OverlapCircleAll(transform.position, distance , layer);

    }
}
