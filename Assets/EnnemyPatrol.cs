using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float speed;

    public Transform[] waypoints;

    private Transform target;

    public SpriteRenderer graphics;

    private int destPoint;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World ); //normalized met la magnitude (force) à 1
        
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;

        }
    }
}
