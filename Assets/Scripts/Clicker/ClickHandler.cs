using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour, IClickHandler
{
    public event Action<int> ClickEvent;

    public void Click(int amount = 1) 
    {
        Debug.Log("click");// handle click
        ClickEvent?.Invoke(amount);// fire click event

        // play animation

    }
}
