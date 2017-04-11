using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class EnemyAI : MonoBehaviour
{
    // What to chase?
    public Transform target;

    // How many times each second we will update our path
    public float updateRate = 2f;
    private float space;

    //attacking flag for animation and other tracking purposes.
    private bool attacking = false, startedPath = false;
   
    // Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //The calculated path
    public Path path;

    //The AI’s speed per second
    public float speed;
    public ForceMode2D fMode;
    public float jumpforce;

    [HideInInspector]
    public bool pathIsEnded = false;
    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance;
    public float aggroRange;

    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;
    private bool searchingForPlayer = false;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        Debug.Log(transform.tag);
   
    }
    IEnumerator SearchForPlayer()
    {

        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if (sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
        else
        {
            target = sResult.transform;
            searchingForPlayer = false;
            StartCoroutine(UpdatePath());
        }
    }
    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            yield return false;
        }

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }
    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void FixedUpdate()
    {
        //distance between seeker a
        space = Vector3.Distance(transform.position, target.transform.position);
        if (space <= aggroRange)
        {
            //Debug.Log(space);
            if (!startedPath)
            {
                startedPath = true;
                if (target == null)
                {
                    if (!searchingForPlayer)
                    {
                        searchingForPlayer = true;
                        StartCoroutine(SearchForPlayer());
                    }
                    return;
                }


                StartCoroutine(UpdatePath());
            }
        }
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        //TODO: Always look at player?
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            // I add this part. When reach the end we gave it players new position.
            StartCoroutine(SearchForPlayer());
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * 100 * Time.fixedDeltaTime;

        //distance between seeker and next waypoint
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (space <= aggroRange)
        {
            //Move the AI
            rb.AddForce(dir, fMode);

            if (transform.tag == "groundEnemy")
            {
                if (rb.velocity.x == 0 && !attacking)
                {
                    //Debug.Log("I am jumping");
                    rb.velocity = new Vector2(0, 1 * jumpforce);
                }
            }
        }
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "player")
        {
            attacking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "player")
        {
            attacking = false;
        }
    }
}
