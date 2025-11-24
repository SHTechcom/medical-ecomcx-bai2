using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FitBoxColliderMeshes : MonoBehaviour
{
    public float outsideAdd = 1f;

    [Sirenix.OdinInspector.Button]
    [ContextMenu("GetFitBoxCollider")]
    public void GetFitBoxCollider()
    {
        ApplyFit(outsideAdd);
    }

    [Sirenix.OdinInspector.Button]
    [ContextMenu("GetFitBoxCollider")]
    public void GetFitBoxCollider(float outside)
    {
        ApplyFit(outside);
    }

    void ApplyFit(float outside)
    {
        BoxCollider box = GetComponent<BoxCollider>();

        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        SkinnedMeshRenderer[] skinnedRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        if (meshRenderers.Length == 0 && skinnedRenderers.Length == 0) return;

        bool hasBounds = false;
        Bounds combinedBounds = new Bounds();

        foreach (var r in meshRenderers)
        {
            if (!hasBounds)
            {
                combinedBounds = r.bounds;
                hasBounds = true;
            }
            else
            {
                combinedBounds.Encapsulate(r.bounds);
            }
        }

        foreach (var sr in skinnedRenderers)
        {
            if (sr.sharedMesh == null) continue;

            Bounds localB = sr.sharedMesh.bounds;

            Vector3 worldCenter = sr.transform.TransformPoint(localB.center);
            Vector3 worldSize = sr.transform.TransformVector(localB.size);

            Bounds worldB = new Bounds(worldCenter, worldSize);

            if (!hasBounds)
            {
                combinedBounds = worldB;
                hasBounds = true;
            }
            else
            {
                combinedBounds.Encapsulate(worldB);
            }
        }

        if (!hasBounds) return;

        Vector3 localCenter = transform.InverseTransformPoint(combinedBounds.center);
        Vector3 localSize = transform.InverseTransformVector(combinedBounds.size);

        box.center = localCenter;
        box.size = localSize + outside * Vector3.one;
    }

    [Sirenix.OdinInspector.Button]
    [ContextMenu("Remove")]
    public void Remove()
    {
        if (Application.isPlaying)
            Destroy(this);
        else
            DestroyImmediate(this);
    }
}
