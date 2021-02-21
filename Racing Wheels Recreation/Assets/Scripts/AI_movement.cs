using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AI_movement : MonoBehaviour
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
    public float increaseSpeed = 2f;
    bool increase = false;
    bool decrease = false;

    public GameManager gm;
    public float timer = 0f;
    public int option = 0;
    float maxTime = 5f;
    //public GameObject gameEndPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameEndPanel.SetActive(false);
        //wc = GetComponent<WheelCollider>();
        anim = GetComponent<Animator>();
        maxTime = Random.Range(2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        float rotationsPerMinute = 60.0f;
        //transform.Rotate(0, 0, 2.0f * rotationsPerMinute * Time.deltaTime);

        transform.Rotate(Random.Range(5f,10f) * rotationsPerMinute * Time.deltaTime, 0, 0);
        //rb.velocity = Vector3.zero;

        // Check for touch pc

        if (gm.game_started)
        {
            if (timer > maxTime)
            {
                timer = 0f;
                option = Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
            }
            else if (timer<=maxTime)
            {
                timer += Time.deltaTime;
            }
            
            if (option == 0)
            {
                DecreaseWheelSize();
            }
            else if (option == 1)
            {
                IncreaseWheelSize();
            }
            /*if (Input.GetMouseButtonDown(0))
            {
                IncreaseWheelSize();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                DecreaseWheelSize();
            }*/
        }

        if (increase)
        {
            if (wc.radius < maxSize)
            {
                wc.radius += increaseSpeed * Time.deltaTime;
            }
        }

        if (decrease)
        {
            if (wc.radius > minSize)
            {
                wc.radius -= increaseSpeed * Time.deltaTime;
            }
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
        anim.Play("large" );
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
        anim.Play("small");
        //speed = 50f;
        /*float finalSize = 1.3f;
        float increaseSpeed = 0.1f;
        while (sphereCollider.radius < finalSize)
        {
            sphereCollider.radius -= increaseSpeed * Time.deltaTime;
        }*/
    }

    


}
