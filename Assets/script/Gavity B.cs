using System.Collections.Generic;
using UnityEngine;

public class GavityB : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody rb;
    const float G = 0.0006674f;
    public static List<GavityB> otherObjectsList;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObjectsList == null)
        {
            otherObjectsList = new List<GavityB>();
        }
        otherObjectsList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (var planets in otherObjectsList) 
        {
            if (planets != this)
            { Attract(planets); }
            
        }
    }

    // Update is called once per frame
   
    private void Attract(GavityB other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * otherRb.mass)/Mathf.Pow(distance,2);
        Vector3 finalForce = forceMagnitude *direction.normalized;

        otherRb.AddForce(finalForce);
    }
}
