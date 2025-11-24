using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class RotDungDichNacl : MonoBehaviour
{
    public GameObject chaiNaCLDD;
    public GameObject chaiCaCLDDSetupw;
    [Header("========")]
    public Bat batNacl;
    [Header("========")]
    public UnityEvent OnSkipEvent;
    public UnityEvent OnCompleted;
    [Header("========")]
    public GameObject tay;
    public GameObject chaiNaclInHand;
    private List<Tween> _tweens = new List<Tween>();
    public Transform target;

    public void Play()
    {
        StartCoroutine(Anim2());
    }

    private IEnumerator Anim2()
    {
        tay.gameObject.SetActive(true);
        var tween = tay.transform.DOLocalMoveX(1, 1);
        _tweens.Add(tween);
        yield return new WaitForSeconds(1);
        chaiCaCLDDSetupw.SetActive(false);
        chaiNaCLDD.SetActive(false);
        chaiNaclInHand.SetActive(true);
        yield return null;
        var tween1 = tay.transform.DOMove(target.position, 1);
        _tweens.Add(tween1);
        var tween2 = tay.transform.DORotate(target.eulerAngles, 1);
        _tweens.Add(tween2);
        yield return new WaitForSeconds(1.5f);
        batNacl.ShowDD(true);
        chaiNaclInHand.SetActive(false);
        tay.gameObject.SetActive(false);
        OnCompleted?.Invoke();
    }

    public void Skip()
    {
        OnSkipEvent?.Invoke();
        StopAllCoroutines();
        _tweens.ForEach(i => i.Complete());
        OnCompleted?.Invoke();
    }
}
