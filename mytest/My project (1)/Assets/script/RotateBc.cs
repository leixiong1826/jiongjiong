using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBc : MonoBehaviour
{
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}
