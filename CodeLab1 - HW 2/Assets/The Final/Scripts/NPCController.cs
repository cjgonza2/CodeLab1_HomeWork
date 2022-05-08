using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using Pathfinding;

public class NPCController : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject target;

    public float sight;

    //Seeker is a reference to seeker component that helps the AI
    //find where it should be looking.
    Seeker seeker;
    //Path is a reference to the pathfinder script that determines the path
    //the ai uses. 
    Path path;
    CharacterController controller;

    public float speed;
    public float nextDistance; //distance between the waypoint the npc is on compared to the waypoint it's going to.
    int currentWaypoint;    //where the npc is at right now. 
    bool reachedEnd;    //has the ai reached the end of its path.
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = GameObject.Find("NPC Destination");

        seeker = GetComponent<Seeker>();
        controller = GetComponent<CharacterController>();

        seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
    }

    // Update is called once per frame
    void Update()
    {
       if(SightUtil.CanSeeObj(player, gameObject, sight))
        {
            Debug.Log("can see player");
        }

        SightUtil.ObjSide(player, gameObject);

        ///where on the path are we.
        ///if middle of the path, which waypoint are we
        ///are we close to the next way point 
        ///if not than lets keep going
        if(path == null)
        {
            //if we don't have a path, this breaks out of update. 
            return;
        }
        reachedEnd = false;
        float distanceToWayPoint;
        while (true)
        {
            //distance check between our position and our path waypoint that we're trying to get to.
            distanceToWayPoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWayPoint < nextDistance)
            {
                //if we have more waypoints to go. 
                if(currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    reachedEnd = true;
                    break;
                }
            }
            else
            {
                break;
            }
        }
        
        ///smoothing when we reach the end of our path. 
        float speedSmooth;
        if (reachedEnd)
        {
            speedSmooth = Mathf.Sqrt(distanceToWayPoint / nextDistance);
        }
        else
        {
            speedSmooth = 1;
        }

        //finds the direciton 
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
       //finds how much we should be moving. 
        Vector3 vel = dir * speed * speedSmooth;
        controller.SimpleMove(vel);
    }

    void OnPathComplete(Path p)
    {
        Debug.Log("found path!");
        if (!p.error)
        {
            //setting our path variable to whatever path was found. 
            path = p;
            //if we had a path previsouly this
            //resets it. 
            currentWaypoint = 0;
        }
    }
}
