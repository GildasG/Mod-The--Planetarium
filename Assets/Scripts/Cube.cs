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

    private float m_minScale = 0.5f;
    public float minScale
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
    private float m_maxScale = 5.0f;
    public float maxScale
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

    public static int scaleCount { get; private set; }
    protected static int colorCount { get; private set; }

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
    public virtual void ChangeColor(MeshRenderer renderer)
    {
        Material material = renderer.material;
        float changeColorR = Random.Range(0.0f, colorRange);
        float changeColorG = Random.Range(0.0f, colorRange);
        float changeColorB = Random.Range(0.0f, colorRange);
        float changeColorA = Random.Range(0.0f, colorRange);
        material.color = new Color(changeColorR, changeColorG, changeColorB, changeColorA);
    }
    public virtual void ChangeScale()
    {
        transform.localScale = Vector3.one * Random.Range(m_minScale, m_maxScale);
        scaleCount++;
    }

    public virtual void RandomRotation(float angle)
    {
        float x = Random.Range(-angle, angle);
        float y = Random.Range(-angle, angle);
        float z = Random.Range(-angle, angle);
        transform.Rotate(x, y, z);
    }
    public virtual void RandomRotation(GameObject target, float speedRange)
    {
        float rotationSpeed = Random.Range(speedRange / 5, speedRange);
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
    IEnumerator DelayColor()
    {
        ChangeColor(Renderer);
        colorCount++;
        Debug.Log("color : " + colorCount + "  scale :" + scaleCount);
        yield return new WaitForSeconds(delay);
        StartCoroutine(DelayColor());

    }

}
