using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jump : MonoBehaviour
{
    public float jumpForceA = 10f;       
    public float jumpAngleA = 60;
    [Space]
    public float jumpForceD = 20f;
    public float jumpAngleD = 60f;
    [Space]
    public float gravityScale = 1f;
    public bool isgrounded;
    private Rigidbody2D rb;
    private float jumpVelocity;
    public GameObject particleeff;
    public Transform spawntrans;
    //public rotationex rx;
    public GameObject ps;
    public float timer;
    public float x, y, y_axis, previous_Axis;
    public Animator anim;
    public GameObject Enemy, MenuUI, ScoreUI;
    private Button button;
    

    Spawnner spawnner;
    private void Start()
    {
        Time.timeScale = 2.3f;
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log("ds");
        GameObject spawnobj = GameObject.Find("Spawn");
        spawnner = spawnobj.GetComponent<Spawnner>();
        //rx = transform.GetComponent<rotationex>();

    }

    IEnumerator CalculateJumpVelocity(float jumpAngle, float jumpForce, float time)
    {
       
        float angleRad = Mathf.Deg2Rad * jumpAngle;

       
        float verticalVelocity = jumpForce * Mathf.Sin(angleRad);
        float horizontalVelocity = jumpForce * Mathf.Cos(angleRad); 

        
        Vector3 jumpVelocityVector = new Vector3(horizontalVelocity, verticalVelocity, 0f);

        rb.velocity = jumpVelocityVector;
        rb.angularVelocity = -180;
        while(rb.angularVelocity < 0)
        {
            rb.angularVelocity += 1;
            yield return new WaitForSeconds(time);
        }
        rb.angularVelocity = 0;
    }

    private void FixedUpdate()
    {
       
        Vector3 gravity = gravityScale * Physics.gravity;
        rb.AddForce(gravity, ForceMode2D.Force);
    }

    private void Update()
    {
        y_axis = transform.position.y;
        //Debug.Log(Screen.width);
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.position);
            if (touch.position.x < Screen.width / 2)
            {
                Debug.Log(touch.position);
                Abutton();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                Debug.Log(touch.position);
                Dbutton();
            }
        }
        else
        { 
             //Do nothing for now
        }
        
        if (Input.GetKeyDown(KeyCode.A) && isgrounded == true)
        {
            Abutton();

            Debug.Log("apressed");

        }
        else if (Input.GetKeyDown(KeyCode.D) && isgrounded == true)
        {
            Dbutton();
        }

        if (isgrounded)
        {
            float rpos = Mathf.Round(transform.position.x);
            Vector3 newpos = new Vector3(rpos, transform.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newpos, .2f);
            timer = 0;
            //transform.localScale = new Vector3(0, 1f, 0);

            /*Vector3 Rotation = transform.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            transform.rotation = Quaternion.Euler(Rotation);*/
            //rx.Targetangle = 0;

        }
      
        else if(y_axis < 0 || y_axis < previous_Axis)
        {
            PlayerDie();
        }
        else if(!isgrounded)
        {
            rb.gravityScale = 5;
        }
        
        

            
    }
    public void Abutton()
    {
        if (isgrounded)
        {
            StartCoroutine(CalculateJumpVelocity(jumpAngleA, jumpForceA, .02f));
            Debug.Log("A");
            CameraShake.Instance.ShakeCamera(x, y, .05f);
            spawnner.spawn();
            Handheld.Vibrate();
            previous_Axis = y_axis - 3;
            UIdisable();
            UIenable();
        }
        
    }
    public void Dbutton()
    {
        if (isgrounded)
        {
            StartCoroutine(CalculateJumpVelocity(jumpAngleD, jumpForceD, .5f));
            Debug.Log("D");
            CameraShake.Instance.ShakeCamera(x, y, .05f);
            Handheld.Vibrate();
            spawnner.spawn();
            previous_Axis = y_axis - 3;
            UIdisable();
            UIenable();
        }
    }
    public void UIdisable()
    {
        MenuUI.SetActive(false);
        
    }
    public void UIenable()
    {
        Enemy.SetActive(true);
        ScoreUI.SetActive(true);
    }
    public void PlayerDie()
    {
        this.enabled = false;
        this.gameObject.SetActive(false);
        Vector3 inspos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Instantiate(ps, inspos, Quaternion.identity);
    }
}
