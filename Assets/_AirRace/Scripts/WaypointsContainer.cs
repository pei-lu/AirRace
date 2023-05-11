using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsContainer : MonoBehaviour
{
    public Queue<GameObject> waypoints;
	private void Start()
	{
		waypoints = new Queue<GameObject>();
	}
	public void AddWaypoint(GameObject waypoint)
    {
		waypoints.Enqueue(waypoint);
    }

    public void DeletePassedWaypoint()
    {
        waypoints.Dequeue();
    }

    public GameObject GetNextWaypoint()
    {
        return waypoints.Peek();
    }
}
