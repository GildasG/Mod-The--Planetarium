using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer Renderer;
    [SerializeField]protected GameObject cube;
    protected Sphere sphereScript;
    public float delay = 1.0f;
    private float interval = 2.0f;

    private float m_minScale = 0.5f; //ENCAPSULATION BACKING FIELD
    public float minScale //ENCAPSULATION
    {
        get { return m_minScale; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Scale can't be negative !");
            }
            m_minScale = value;
        }
    }
    private float m_maxScale = 5.0f; //ENCAPSULATION BACKING FIELD
    public float maxScale //ENCAPSULATION
    {
        get { return m_maxScale; }
        set
        {
            if (value < m_minScale)
            {
                Debug.Log("maxScale can't be inferior to minScale !!");
            }
            m_maxScale = value;
        }
    }

    public static int scaleCount { get; private set; } //ENCAPSULATION
    protected static int colorCount { get; private set; } //ENCAPSULATION

    private float colorRange = 1.0f;

    void Start()
    {
        sphereScript = GameObject.Find("Sphere").GetComponent<Sphere>();
        colorCount = 0;
        scaleCount = 0;
        Renderer = GetComponent<MeshRenderer>();
        StartCoroutine(DelayColor());
        InvokeRepeating("ChangeScale", delay, interval);

    }

    void Update()
    {
        if (sphereScript.target != cube)
        {
            RandomRotation((colorCount * scaleCount) % 15);
        }

    }
    public virtual void ChangeColor(MeshRenderer renderer) //ABSTRACTION // POLYMORPHISM-Preparation
    {
        Material material = renderer.material;
        float changeColorR = Random.Range(0.0f, colorRange);
        float changeColorG = Random.Range(0.0f, colorRange);
        float changeColorB = Random.Range(0.0f, colorRange);
        float changeColorA = Random.Range(0.0f, colorRange);
        material.color = new Color(changeColorR, changeColorG, changeColorB, changeColorA);
    }
    public virtual void ChangeScale() //ABSTRACTION //POLYMORPHISME-Preparation
    {
        transform.localScale = Vector3.one * Random.Range(m_minScale, m_maxScale);
        scaleCount++;
    }

    public virtual void RandomRotation(float angle) //ABSTRACTION //POLYMORPHISM-Preparation
    {
        float x = Random.Range(-angle, angle);
        float y = Random.Range(-angle, angle);
        float z = Random.Range(-angle, angle);
        transform.Rotate(x, y, z);
    }
    public virtual void RandomRotation(GameObject target, float speedRange) //ABSTRACTION //POLYMORPHISM-Preparation
    {
        float rotationSpeed = Random.Range(speedRange / 5, speedRange);
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
    IEnumerator DelayColor() //ABSTRACTION
    {
        ChangeColor(Renderer);
        colorCount++;
        Debug.Log("color : " + colorCount + "  scale :" + scaleCount);
        yield return new WaitForSeconds(delay);
        StartCoroutine(DelayColor());

    }

}
