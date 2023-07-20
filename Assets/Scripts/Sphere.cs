using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sphere : Cube
{
    private MeshRenderer sphRend;

    public GameObject target;
    private GameObject capObj;
    private float rotSpeed;
    public static float newScale {get; private set;}
    private bool onRot = false;


    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 0;
        capObj = GameObject.Find("Capsule");
        sphRend = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(cube, capObj);
        RandomRotation(target, rotSpeed);
        ChangeScale();

    }
    public void CheckDistance(GameObject cube, GameObject caps)
    {
        float cubeDist = Vector3.Distance(transform.position, cube.transform.position);
        float capsDist = Vector3.Distance(transform.position, caps.transform.position);
        if (cubeDist > capsDist)
        {
            target = caps;
            rotSpeed = cubeDist * 10;
        }
        else
        {
            target = cube;
            rotSpeed = capsDist * 10;
        }
    }
    public override void RandomRotation(GameObject target, float speedRange)
    {

        Debug.Log("center : " + target + "speed : " + rotSpeed);
        Debug.Log("Pos : " + target + "speed : " + speedRange);
        if (!onRot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                base.RandomRotation(target, speedRange);
                onRot = true;
            }
            else
            {
                ChangeColor(sphRend);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {

                onRot = false;
            }
            else
            {
                base.RandomRotation(target, speedRange);
            }
        }



    }

    public override void ChangeScale()
    {
        newScale = 3.0f;
        if (target != cube)
        {
            transform.localScale = Vector3.one * newScale;
        }
        else
        {
            transform.localScale = Vector3.one;
        }

    }
}
