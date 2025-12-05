using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class XitTay : MonoBehaviour
{
    public Transform tay;
    public Vector3 target;
    public UnityEvent OnCompleted;
    public Tween tween;

    private void OnEnable()
    {
        tween = tay.DOLocalMove(target, 1).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            OnCompleted?.Invoke();
        });
    }

    private void OnDisable()
    {
        tween.Kill();
    }

    public void Resume()
    {
        tween.Pause();
    }

    public void Pause()
    {
        tween.Play();
    }
}
