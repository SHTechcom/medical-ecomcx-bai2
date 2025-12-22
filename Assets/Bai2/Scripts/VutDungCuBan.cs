using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class VutDungCuBan : MonoBehaviour
{
    public Transform bang;
    Vector3 target = new Vector3(0.583309412f, 0.087f, 1.35699999f);
    public UnityEvent OnCompleted;

    public void Play()
    {
        bang.DOLocalMove(target, 4f).OnComplete(() =>
        {
            OnCompleted?.Invoke();
        });
    }
}
