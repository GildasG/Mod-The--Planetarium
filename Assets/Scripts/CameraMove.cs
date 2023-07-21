using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject sphere;

    private Vector3 initPos;
    private Vector3 translateMove;

    private float camSpeed = 12f;
    private float attenuationFactor = 4;
    private float zBoundary = 6.5f;
    private float lastZ;
    // Start is called before the first frame update
    private void Start()
    {
        initPos = transform.position;
        lastZ = zBoundary;
        translateMove = -Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (sphere.transform.position.z > zBoundary)
        {
            TrackSphere(sphere.transform.position.z);
        }
        else
        {
            lastZ = zBoundary;
            BackToInitPos();
        }


    }

    public void TrackSphere(float z) //ABSTRACTION
    {
        if (z > lastZ)
        {
            transform.Translate(translateMove * Time.deltaTime * camSpeed, Space.Self);
            lastZ = z;
        }
        else if (z < lastZ && transform.position.z > initPos.z)
        {
            transform.Translate(-translateMove * Time.deltaTime * camSpeed / attenuationFactor, Space.Self);
            lastZ = z;
        }
    }
    public void BackToInitPos() //ABSTRACTION
    {
        if (transform.position.z > initPos.z)
        {
            transform.Translate(-translateMove * Time.deltaTime * camSpeed / attenuationFactor, Space.Self);
        }
        else
        {
            transform.position = initPos;
        }
    }
}
