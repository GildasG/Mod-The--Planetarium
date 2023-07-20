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
        RandomRotation(cube, OrbitSpeed(range));

        if (colorCount % 5 == 0)
        {
            ChangeColor(capsRenderer);
        }

        if (CheckScale(cube, Sphere.newScale))
        {
            RandomRotation(range);
        }
    }
    float OrbitSpeed (float range)
    {
        return Random.Range(range/2, range);
    }
    public override void RandomRotation(float angle)
    {
        transform.Rotate(angle/12, 0, 0);
    }
    public bool CheckScale(GameObject g, float scale)
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
