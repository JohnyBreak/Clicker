using System;
using UnityEngine;
using DG.Tweening;

public class ClickHandler : MonoBehaviour, IClickHandler
{
    public event Action<double> ClickEvent;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Click(double amount = 1) 
    {
        ClickEvent?.Invoke(amount);// fire click event

        // play animation
        _transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(ScaleBack);

    }
    private void ScaleBack() 
    {
        _transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }
}
