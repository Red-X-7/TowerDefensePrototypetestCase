using System.Collections;
using UnityEngine;

public abstract class EnemyPathBase : MonoBehaviour
{
    //Canavarlarýn tüm yolu takip etmesini oluþturan script


    [Header("Waypoints")]
    public Transform startPoint;
    public Transform pathPoint1;
    public Transform pathPoint2;
    public Transform endPoint;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float arriveThreshold = 0.1f;
    public float fixedY = 5.5f;

    protected Transform[] waypoints;
    protected int currentIndex = 0;



    protected virtual void Start()
    {
        if (startPoint != null)
            transform.position = new Vector3(startPoint.position.x, fixedY, startPoint.position.z);

        waypoints = new Transform[] { pathPoint1, pathPoint2, endPoint };

        StartCoroutine(MoveRoutine()); 
    }



    IEnumerator MoveRoutine()
    {
        while (currentIndex < waypoints.Length)
        {
            Transform target = waypoints[currentIndex];
            Vector3 targetPos = new Vector3(target.position.x, fixedY, target.position.z);

            while (Vector3.Distance(transform.position, targetPos) > arriveThreshold)
            {
                Vector3 dir = (targetPos - transform.position).normalized;
                transform.position += dir * moveSpeed * Time.deltaTime;
                yield return null;
            }

            currentIndex++;
        }

        OnReachedDestination();
    }

    // Yol sonuna gelindiðinde çaðrýlacak
    protected virtual void OnReachedDestination()
    {
        Destroy(gameObject);
    }
}