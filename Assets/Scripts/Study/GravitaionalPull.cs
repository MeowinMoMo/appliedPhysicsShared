using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitaionalPull : MonoBehaviour
{
    [SerializeField] private float maxGravityDistance;
    [SerializeField] private float minimumGravityDistance;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float intensity;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        var overlapObjects = Physics2D.OverlapCircleAll(transform.position,
        minimumGravityDistance, layer);
        if (overlapObjects.Length == 0)
        {
            Debug.Log("Empty");
            return;
        }
        foreach (Collider2D overlapObject in overlapObjects)
        {
            var rb = overlapObject.GetComponent<GravityObjects>();
            if (rb == null)
            {
                Debug.Log("Test");
                return;
            }
            var direction = transform.position - rb.gameObject.transform.position;
            var reverseDirection = rb.gameObject.transform.position -
            transform.position;
            direction.Normalize();
            reverseDirection.Normalize();
            if (Vector2.Distance(rb.gameObject.transform.position,
            transform.position) > maxGravityDistance)
            {
                Debug.Log((Vector2.Distance(transform.position + (reverseDirection
                * maxGravityDistance), rb.transform.position)) / minimumGravityDistance);
                rb.RB.AddForce(direction * (intensity *
                ((Vector2.Distance(transform.position + (reverseDirection * maxGravityDistance),
                rb.transform.position)) / minimumGravityDistance)));
            }
            else
            {
                rb.RB.AddForce(direction * (intensity));
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxGravityDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, minimumGravityDistance);
    }
}
