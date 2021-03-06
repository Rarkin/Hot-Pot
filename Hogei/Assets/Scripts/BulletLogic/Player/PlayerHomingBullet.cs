using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingBullet : MonoBehaviour {

    [Header("Tags")]
    [Tooltip("Tag for targets")]
    public string targetTag = "Enemy";

    [Header("Adjustment force")]
    [Tooltip("Amount of force used to steer homing")]
    public float adjustForce = 0.5f;
    [Tooltip("Time between adjustments")]
    public float homingAdjustInterval = 0.1f;

    [Header("Damage")]
    [Tooltip("Damage dealt by bullet")]
    public float bulletDamage = 0.5f;

    [Header("Explosion vfx")]
    public GameObject explosionVFX;

    ////script ref
    //private BulletBank bulletBank;

    //control vars
    private Rigidbody myRigid;
    private bool isActive = false;
    private float travelSpeed = 3.0f;
    //private float maxHomingTime = 4.0f;
    private float homingStartDelay = 1.0f;
    private float startTime = 0.0f;
    //private float lastAdjustTime = 0.0f;
    public GameObject target;
    public GameObject[] targetArray = new GameObject[0];

    // Use this for initialization
    void Start () {
        myRigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            MoveBullet();
        }
        else
        {
            myRigid.velocity = Vector3.zero;
        }
    }

    private void OnEnable()
    {
        PauseHandler.PauseEvent += OnPause;
        PauseHandler.UnpauseEvent += OnUnpause;
        //print("Subscribed to event");
    }

    private void OnDisable()
    {
        PauseHandler.PauseEvent -= OnPause;
        PauseHandler.UnpauseEvent -= OnUnpause;
        //print("Unsubscribed to event");
    }

    //set up func
    public void SetupVars(float speed, float hominTime, float hominStartDelay)
    {
        isActive = true;
        travelSpeed = speed;
        //maxHomingTime = hominTime;
        homingStartDelay = hominStartDelay;
        startTime = Time.time;
        //lastAdjustTime = 0.0f;
        GetTargets();
    }

    //find all possible targets active in scene
    private void GetTargets()
    {
        targetArray = GameObject.FindGameObjectsWithTag(targetTag);

        //set a large compare value
        float closestDist = 5000.0f;
        float compareDist = 0f;

        //for all in target array
        for (int i = 0; i < targetArray.Length; i++)
        {
            compareDist = Vector3.Distance(transform.position, targetArray[i].transform.position);
            //compare the distance, and if closer, make that object the target
            if (closestDist > compareDist)
            {
                target = targetArray[i];
                closestDist = compareDist;
            }
        }
    }

    //movement logic
    private void MoveBullet()
    {
        if (/*Time.time < startTime + maxHomingTime &&*/ Time.time > startTime + homingStartDelay)
        {
            
                //GetTargets();

                if (targetArray.Length >= 1 && target != null)
                {
                    SteerToTarget();
                }
                else
                {
                    myRigid.velocity = transform.forward * travelSpeed;
                }

        }
        
        else
        {
            myRigid.velocity = transform.forward * travelSpeed;
        }
    }

    //find a target and steer
    private void SteerToTarget()
    {
        //steer towards target
        //get vector towards target
        //Vector3 desireVelocity = target.transform.position - transform.position;
        Vector3 desireVelocity = new Vector3(target.transform.position.x, 0.0f, target.transform.position.z) - new Vector3(transform.position.x, 0.0f, transform.position.z);
        float distance = desireVelocity.magnitude;
        desireVelocity = Vector3.Normalize(desireVelocity) * travelSpeed;
        //get steering force
        Vector3 steeringForce =  desireVelocity - myRigid.velocity;
        //steeringForce /= adjustForce;
        //adjust velocity
        myRigid.velocity = Vector3.ClampMagnitude( myRigid.velocity + (steeringForce * Time.deltaTime), travelSpeed);
        transform.rotation = Quaternion.LookRotation(myRigid.velocity);
    }

    //deactivate func
    private void Deactivate()
    {
        Destroy(gameObject);
    }

    //collision = deactivate
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.isTrigger)
        {
            //any collision
            if (collision.gameObject.GetComponent<EntityHealth>()/* || collision.CompareTag("Enviroment")*/)
            {
                collision.gameObject.GetComponent<EntityHealth>().DecreaseHealth(bulletDamage);
                if (explosionVFX) Instantiate(explosionVFX, transform.position, transform.rotation);

            }
            Deactivate();
        }
    }


    //Pause events
    void OnPause()
    {
        isActive = false;
    }

    void OnUnpause()
    {
        isActive = true;
    }

}
