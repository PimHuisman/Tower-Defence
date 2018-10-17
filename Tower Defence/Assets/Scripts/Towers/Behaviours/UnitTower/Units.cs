using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Units : MonoBehaviour
{
    NavMeshAgent agent;
    [HideInInspector] public Transform target;
    
    [Header("Health")]
    public int health;
    public int currentHealth;

    [Header("Raycast")]
    [SerializeField] float distEnemy;
    [SerializeField] Vector3 offset;
    [SerializeField] float attackRate;
    [SerializeField] int damage;
    [SerializeField] bool isAttacking;
    RaycastHit hit;
    [SerializeField] float raycastLength;

     [Header("FieldOfView")]
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTarget = new List<Transform>();

    public float meshResolution;
    public int edgeResolveInterations;
    public float edgeDstThreshold;

    [HideInInspector] public float distance;

    void Start()
    {
        StartCoroutine("AttackRate");
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("FindTargetWithDelay", 0.2f);
        currentHealth = health;
    }

    void Update()
    {
        SetPosition();
        CheckHealth();
        Attack();
    }

    void SetPosition()
    {
        agent.SetDestination(target.position);
    }

    void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.GetComponentInParent<UnitBehaviour>())
            {
                gameObject.GetComponentInParent<UnitBehaviour>().RemoveUnit(transform);
                Destroy(gameObject);
            }
            else
            {
                print("Parent doesn't have UnitBehaviour script!");
            }
        }
    }

    public int CalculateHealth(int damage)
    {
        if(currentHealth <= 0)
        {
            return currentHealth = 0;
        }
        currentHealth -= damage;
        return currentHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBehaviour>()) 
        {
            isAttacking = true;
            Vector3 newPos = new Vector3(other.transform.position.x + distEnemy,other.transform.position.y,other.transform.position.z);
            target.position = newPos;
            agent.isStopped = true;
        }
    }

    void OnTriggerStay(Collider other) 
    {

    }

    void Attack()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "Enemy")
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
        }
        Debug.DrawRay(transform.position + offset, transform.forward * raycastLength, Color.red);
    }

    IEnumerator AttackRate()
    {
        while (true)
        {
            while (isAttacking)
            {
                yield return new WaitForSeconds(attackRate);
                hit.transform.gameObject.GetComponent<EnemyHealth>().DamageMe(damage, null);
            }
            yield return null;
        }
    }

    void FindVisibleTarget()
    {
        visibleTarget.Clear();
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);


        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTarget.Add(target);

                    Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                }

            }
        }
    }

    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    public Vector3 DirFromAngel(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
