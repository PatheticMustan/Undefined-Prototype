using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyPS : MonoBehaviour
{
    public GameObject boxObj;

    public ParticleSystem boxPS;

    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!boxObj.activeSelf && !flag)
        {
            flag = true;

            boxPS.gameObject.transform.position = boxObj.transform.position;

            boxPS.Play();
        }
    }
}
