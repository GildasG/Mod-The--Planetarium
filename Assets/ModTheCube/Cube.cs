using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float delay = 1.0f;
    public float interval = 0.5f;
        
    void Start()
    {
        transform.position = new Vector3(2, 5, 3);
        InvokeRepeating("ChangeScale", delay, 1.8f);
        InvokeRepeating("ChangeColor", delay, interval);
         
    }
    
    void Update()
    {
        transform.Rotate(Random.Range(0, 100) * Time.deltaTime, Random.Range(0, 100) * Time.deltaTime, Random.Range(0, 100) * Time.deltaTime);
    }
    void ChangeColor()
    {
        Material material = Renderer.material;
        float changeColorR = Random.Range(0.0f, 1.0f);
        float changeColorG = Random.Range(0.0f, 1.0f);
        float changeColorB = Random.Range(0.0f, 1.0f);
        float changeColorA = Random.Range(0.0f, 1.0f);
        material.color = new Color(changeColorR, changeColorG, changeColorB, changeColorA);
    }
    void ChangeScale()
    {
        transform.localScale = Vector3.one * Random.Range(0.5f, 5.0f);
    }
   
}
