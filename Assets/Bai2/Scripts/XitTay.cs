using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class XitTay : MonoBehaviour
{
    public Transform tay;
    public Vector3 target;
    public UnityEvent OnCompleted;

    private void OnEnable()
    {
        tay.DOLocalMove(target, 1).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            OnCompleted?.Invoke();
        });
    }
}
