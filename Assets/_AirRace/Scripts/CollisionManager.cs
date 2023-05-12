using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public WaypointsContainer waypointsContainer;
    public GameObject player;
    [Tooltip("Time during which the player will be freezed after colliding with the ground, a building, or the wrong waypoint.")]
    public float freezeTime;

    private float timeWaited = 0f;
    private bool isCollideTargetWaypoint;
    private Vector3 lastWaypointPos;
    void Start()
    {

	}

	void OnTriggerEnter(Collider other)
	{
		isCollideTargetWaypoint = CheckReachTargetWaypoint(other.transform.parent);
		if (isCollideTargetWaypoint)
		{
            lastWaypointPos = other.transform.parent.position;
            waypointsContainer.DeletePassedWaypoint();
			other.transform.parent.gameObject.SetActive(false);
		}
		else
		{
			TeleportToLastWaypoint();
			StartFreeze();
		}
	}

    void TeleportToLastWaypoint()
    {
        player.transform.position = lastWaypointPos;
        player.transform.forward = waypointsContainer.GetNextWaypoint().transform.position - lastWaypointPos;
	}

    void StartFreeze()
    {
        timeWaited += Time.deltaTime;
        if (timeWaited > freezeTime ) { timeWaited = freezeTime; }

        if (timeWaited < freezeTime)
        {

        }
    }

	bool CheckReachTargetWaypoint(Transform collideTransform)
    {
        return waypointsContainer.GetNextWaypoint().transform == collideTransform;
    }
}
