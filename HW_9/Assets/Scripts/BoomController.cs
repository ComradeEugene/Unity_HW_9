using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public float timeToExplosion;
    public float power;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToExplosion -= Time.deltaTime;

        if (timeToExplosion <= 0 )
        {
            Boom();
        }
    }

	void Boom()
	{
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();
        
        foreach ( Rigidbody b in blocks )
        {
            if (Vector3.Distance(transform.position, b.transform.position) < radius)
            {
                Vector3 direction = b.transform.position - transform.position;

                b.AddForce(direction.normalized * power * (radius - Vector3.Distance(transform.position, b.transform.position)), ForceMode.Impulse);
            }
        }

        timeToExplosion = 3;
	}
}
