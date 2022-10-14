using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public float NextWaypointDistance = 3f;

    public Path Path;
    public int CurrentWaypoint = 0;
    public bool ReachedEndOfPath = false;

    public Seeker Seeker;
    public Enemy Enemy;
    public Rigidbody2D Rb;

    private void Start()
    {
        InvokeRepeating("UpdatePath", 0, .5f);
    } 

    private void UpdatePath()
    {
        if (Seeker.IsDone())
            Seeker.StartPath(Rb.position, Enemy.TargetTransform.position, OnPathComplete);
    }

    private void OnPathComplete(Path path)
    {
        if (!path.error)
        {
            Path = path;
            CurrentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (Path == null)
            return;

        if (CurrentWaypoint >= Path.vectorPath.Count)
        {
            ReachedEndOfPath = true;
            return;
        }
        else
            ReachedEndOfPath = false;

        MoveTowardsTarget();

        RotateTowardsTarget();

        TryUpdateWaypoint();
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = ((Vector2)Path.vectorPath[CurrentWaypoint] - Rb.position).normalized;
        Vector2 force = direction * Enemy.MoveSpeed;

        Rb.velocity = Vector2.zero;
        Rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void RotateTowardsTarget()
    {
        Vector3 rotationDirection = Enemy.TargetTransform.position - transform.position;
        float angle = Mathf.Atan2(rotationDirection.y, rotationDirection.x) * Mathf.Rad2Deg;
        Rb.rotation = angle + 280;
    }

    private void TryUpdateWaypoint()
    {
        if (Vector2.Distance(Rb.position, Path.vectorPath[CurrentWaypoint]) < NextWaypointDistance)
            CurrentWaypoint++;
    }
}