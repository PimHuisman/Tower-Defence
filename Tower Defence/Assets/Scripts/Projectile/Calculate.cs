using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    public Transform target;
    float distanceToTarget;

    public float launchAngle;
    private Rigidbody myRb;
    public bool launched;
    public bool hasLanded;
    public bool doWait;
    public float maxTime;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 offset360;
    [SerializeField] Vector3 offset270;
    [SerializeField] Vector3 offset180;
    [SerializeField] Vector3 offset90;

    // Use this for initialization
    void MyStart()
    {
        //print ("Starting");
        if (GetComponent<Rigidbody>())
        {
            myRb = GetComponent<Rigidbody>();

        }
        else { }

        myRb.useGravity = false;
        myRb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (launched == true)
        {
            if (hasLanded == false)
            {
                if (myRb != null)
                {
                    transform.rotation = Quaternion.LookRotation(myRb.velocity);
                }
            }
        }
    }

    public void Launch()
    {
        if (doWait == true)
        {

            StartCoroutine("WaitShoot");
        }
        else
        {
            Launch2();
        }

    }

    void Launch2()
    {
        #region Rotation Target
        if (target != null)
        {
            if (target.transform.eulerAngles.y < 362 && target.transform.eulerAngles.y > 272)
            {
                print("i am between 360/270");
                offset = offset360;
            }
            if (target.transform.eulerAngles.y < 272 && target.transform.eulerAngles.y > 182)
            {
                print("i am between 270/180");
                offset = offset270;
            }
            if (target.transform.eulerAngles.y < 182 && target.transform.eulerAngles.y > 92)
            {
                print("i am between 180/90");
                offset = offset180;
            }
            if (target.transform.eulerAngles.y < 92 && target.transform.eulerAngles.y > 0)
            {
                print("i am between 90/0");
                offset = offset90;
            }
        }
        #endregion
        MyStart();
        launched = true;

        //print ("Is the rigidbody using gravity before the change? " + myRb.useGravity);
        myRb.useGravity = true;
        myRb.isKinematic = false;
        //print ("Is the rigidbody using after before the change? " + myRb.useGravity);

        Vector3 projectileXZPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 targetXZPos = new Vector3(target.position.x, transform.position.y, target.position.z) + offset;

        transform.LookAt(targetXZPos);

        float distance = Vector3.Distance(projectileXZPos, targetXZPos);
        float gravity = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(launchAngle * Mathf.Deg2Rad);
        float heightOffset = target.position.y - transform.position.y;

        // calculate initial speed required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(gravity * distance * distance / (2.0f * (heightOffset - distance * tanAlpha)));
        float Vy = tanAlpha * Vz;

        // create the velocity vector in local space and get it in global space
        Vector3 localVelocity = new Vector3(0f, Vy, Vz);

        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        // launch the object by setting its initial velocity and flipping its state
        myRb.velocity = globalVelocity;

    }
    public IEnumerator WaitShoot()
    {
        float secs = Random.Range(0, maxTime);
        yield return new WaitForSeconds(secs);
        Launch2();
        yield return null;
    }

    void OnCollisionEnter(Collision c)
    {

        if (transform.tag != "Projectile")
        {

            hasLanded = true;
        }
    }
}