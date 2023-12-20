using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    [SerializeField] private Slider _energySlider;
    Energy parameter;

    private float _time;

    void Awake()
    {
        parameter = new Energy(75, 2, _energySlider);
    }

    
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 1) 
        {
            parameter.Tick();
            _time = 0;
        }
    }
}
