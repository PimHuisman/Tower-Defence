using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwachaBehaviour : TowerBehaviour
{
    public float maxTime;
    [SerializeField] float spacingY;
    [SerializeField] float spacingX;
    [SerializeField] Vector3 mapsize;
    [SerializeField] Transform arrowPos;
    [SerializeField] int arrowAmount;
    Transform arrow;
    public List<Transform> arrowList = new List<Transform>();
    [SerializeField] Transform arrowObject;

    public void Start()
    {
        SetStats();
        StartCoroutine(ShootRoutine());
    }

    public void Update()
    {
        CheckEnemies();

        if (Input.GetButtonDown("Jump"))
        {
            print("Works");
            GenerateArrows();
        }
    }

    public override void Shoot()
    {
        GenerateArrows();
        for (int i = 0; i < arrowList.Count; i++)
        {
            if (mainTarget != null)
            {
                weapon.LookAt(mainTarget.forward);
            }
            arrowList[i].GetComponent<Stick>().damage = damage;
            Calculate calc = arrowList[i].GetComponent<Calculate>();
            calc.maxTime = maxTime;
            calc.doWait = true;
            calc.target = mainTarget;
            calc.launchAngle = angle;
            calc.Launch();
            PlayAudio(shootClip);
        }
        arrowList.Clear();
    }

    void GenerateArrows()
    {
        for (int y = 0; y < mapsize.y; y++)
        {
            for (int x = 0;x < mapsize.x;x++)
            {
                Vector3 newArroPos = new Vector3(arrowPos.position.x + spacingX * x, arrowPos.position.y + spacingY * y, arrowPos.position.z);
                currentProjectile = Instantiate(arrowObject, newArroPos, arrowPos.rotation) as Transform;
                //currentProjectile.transform.parent = arrowPos.transform;
                currentProjectile.transform.SetParent(arrowPos.transform, true);
                arrowList.Add(currentProjectile);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        base.Enter(other);
    }

    void OnTriggerExit(Collider other)
    {
        base.Exit(other);
    }

    public override void CheckEnemies()
    {
        base.CheckEnemies();
    }
}