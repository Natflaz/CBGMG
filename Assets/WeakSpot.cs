using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(transform.parent.parent.gameObject);
        }
    }
}