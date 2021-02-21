using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform cameraTransform;

    public GameObject wheel;
    public Transform wheelTransform;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        wheel = GameObject.Find("WheelWithCollider");
        wheelTransform = wheel.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        cameraTransform.position = wheelTransform.position + offset;
        //cameraTransform.rotation = new Vector3(9.33599663f, 342.5f, 1.08154318f));
        cameraTransform.rotation = new Quaternion(9.33599663f, 342.5f, 1.08154318f, 1);
        cameraTransform.LookAt(wheelTransform);
    }
}
