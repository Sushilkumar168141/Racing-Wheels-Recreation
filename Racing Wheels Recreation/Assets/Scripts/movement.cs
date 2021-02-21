using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    //public Transform transform;
    //public Rigidbody rb;
    //SphereCollider sphereCollider;
    public WheelCollider wc;
    [SerializeField] float speed = 40f;
    Animator anim;
    bool onGround = false;
    bool inAir = false;

    public float maxSize = 3f;
    public float minSize = 1.2f;
    float increaseSpeed = 1f;
    public bool increase = false;
    public bool decrease = false;

    public GameManager gm;

    //public GameObject gameEndPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameEndPanel.SetActive(false);
        //wc = GetComponent<WheelCollider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float rotationsPerMinute = 60.0f;
        //transform.Rotate(0, 0, 2.0f * rotationsPerMinute * Time.deltaTime);

        transform.Rotate(10.0f * rotationsPerMinute * Time.deltaTime, 0, 0);
        //rb.velocity = Vector3.zero;

        // Check for touch pc
        if (gm.game_started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IncreaseWheelSize();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                DecreaseWheelSize();
            }

            // Check for touch mobile
            /*if (Input.touchCount > 0)
            {
                Touch first = Input.GetTouch(0);
                if (first.phase == TouchPhase.Stationary)
                {
                    //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
                    IncreaseWheelSize();
                }
                else if (first.phase == TouchPhase.Ended)
                {
                    DecreaseWheelSize();
                }
            }*/
        }

        //anim.Play("large");

        if (increase)
        {
            if (wc.radius < maxSize)
            {
                wc.radius += increaseSpeed * Time.deltaTime;
            }
            //anim.speed = 1;

        }

        if (decrease)
        {
            if (wc.radius > minSize)
            {
                wc.radius -= increaseSpeed * Time.deltaTime;
            }
            //anim.speed = -1;
        }
   
    }

    void FixedUpdate()
    {

        /*if (Input.touchCount > 0)
        {
            Touch first = Input.GetTouch(0);
            if (first.phase == TouchPhase.Stationary)
            {
                //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
                IncreaseWheelSize();
            }
            else if (first.phase == TouchPhase.Ended)
            {
                DecreaseWheelSize();
            }
        }*/

        


        /*if (onGround)
        {
            
            rb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
            //rb.AddForce(new Vector3(0f, 0f, speed*Time.deltaTime), ForceMode.VelocityChange);
        }
        else if (inAir)
        {
            rb.AddForce(Vector3.forward * 5f * Time.deltaTime, ForceMode.VelocityChange);
        }
        //rb.velocity = new Vector3(0f, 0f, speed);
        Debug.Log(rb.velocity);*/
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            Debug.Log("Collided with target");
        }
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            gameEndPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }*/


    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Track")
        {
            onGround = true;
            inAir = false;
            //speed = 20f;
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Track")
        {
            inAir = true;
            onGround = false;
            //speed = 0f;
        }
    }

    public void IncreaseWheelSize()
    {
        //sphereCollider.radius = 5f;
        increase = true;
        decrease = false;
        anim.SetFloat("direction", 1f);
        anim.Play("large", -1, float.NegativeInfinity);
        //speed = 100f;
        /*float finalSize = 5f;
        float increaseSpeed = 0.1f;
        while (sphereCollider.radius < finalSize)
        {
            sphereCollider.radius += increaseSpeed * Time.deltaTime;
        }*/
    }

    public void DecreaseWheelSize()
    {
        //sphereCollider.radius = 1.3f;
        decrease = true;
        increase = false;
        anim.SetFloat("direction", -1f);
        anim.Play("large", -1, float.NegativeInfinity);
        //anim.speed = -1;
        //speed = 50f;
        /*float finalSize = 1.3f;
        float increaseSpeed = 0.1f;
        while (sphereCollider.radius < finalSize)
        {
            sphereCollider.radius -= increaseSpeed * Time.deltaTime;
        }*/
    }

    


}
