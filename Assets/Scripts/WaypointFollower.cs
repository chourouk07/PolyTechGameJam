using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2.0f;

    private int currentWaypointIndex = -1;

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned!");
            return;
        }

        // Start following waypoints
        NextWaypoint();
    }

    void Update()
    {
        if (currentWaypointIndex >= 0 && currentWaypointIndex < waypoints.Length)
        {
            Vector2 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                NextWaypoint();
            }
        }
    }

    void NextWaypoint()
    {
        int previousWaypointIndex = currentWaypointIndex;

        // Pick a random waypoint that is not the previous one
        do
        {
            currentWaypointIndex = Random.Range(0, waypoints.Length);
        } while (currentWaypointIndex == previousWaypointIndex);

        Debug.Log("Next waypoint index: " + currentWaypointIndex);
    }
}
