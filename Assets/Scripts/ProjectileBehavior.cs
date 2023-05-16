using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Transform attachmentPoint;
    private bool isAttached = false;

    public void SetAttachmentPoint(Transform attachment)
    {
        attachmentPoint = attachment;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isAttached && collision.gameObject.CompareTag("Sphere"))
        {
            Rigidbody projectileRigidbody = GetComponent<Rigidbody>();
            projectileRigidbody.useGravity = false;
            projectileRigidbody.isKinematic = true;
            transform.parent = attachmentPoint;
            isAttached = true;
        }
    }
}
