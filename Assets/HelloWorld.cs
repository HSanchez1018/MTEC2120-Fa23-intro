using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Other;

    /*public GameObject Other
    {
        get { return m_Other; }
        set { m_Other = value; }
    }*/

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        rend = m_Other.GetComponent<Renderer>();
        if (!rend) Debug.LogError("There is no renderer");

        rend.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(100, 0, 0);
            Debug.Log("My name is " + gameObject.name);
            Debug.Log("My tag is " + tag);

            rend.material.color = Color.blue;
        };
    }

    public Color RandomColor()
    {
        return new Color(Random.Range(0f, 1.0f), Random.Range(0f,1.0f), Random.Range(0f,1.0f));
    }
}
