using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : Cube
{
    private MeshRenderer capsRenderer;
    private float range = 50;

    // Start is called before the first frame update
    void Start()
    {
        capsRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RandomRotation(cube, OrbitSpeed(range)); //INHERITANCE (method and variable)

        if (colorCount % 5 == 0)
        {
            ChangeColor(capsRenderer); //INHERITANCE (method)
        }

        if (CheckScale(cube, Sphere.newScale)) //INHERITANCE (variables)
        {
            RandomRotation(range);
        }
    }
    float OrbitSpeed (float range) //ABSTRACTION
    {
        return Random.Range(range/1.5f, range);
    }
    public override void RandomRotation(float angle) //POLYMORPHISM
    {
        transform.Rotate(angle/13, 0, 0);
    }
    public bool CheckScale(GameObject g, float scale) //ABSTRACTION
    {
        float x = g.transform.localScale.x;
        if (x > scale)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
