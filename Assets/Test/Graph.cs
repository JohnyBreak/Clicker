using ModestTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private float _scale;
    [SerializeField] private GameObject _xDivision;
    [SerializeField] private float _amountXDivision;
    [SerializeField] private GameObject _yDivision;
    
    [SerializeField] private float _amountYDivision;
    [SerializeField] private GameObject _point;
    private List<GameObject> _points;
    private List<Vector3> _tops;
    [SerializeField] private LineRenderer _lineRenderer;

    private List<(int, int)> _pointsPos;

    // Start is called before the first frame update
    void Start()
    {
        var sr = new StreamReader($"{Application.persistentDataPath}/2.txt");
        _pointsPos = new();
        ExtractData2(sr);
        _tops = new(_pointsPos.Count);
        

        Sort(_pointsPos);

        xOy();
        SpawnPoints(_pointsPos);
        LocatePoints(_pointsPos);
    }
    private void Sort(List<(int, int)> points)
    {
        points.Sort();
    }
    private void ExtractData2(StreamReader sr)
    {
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            var items = line.Split(' ');
            _pointsPos.Add((Convert.ToInt32(items[0]), Convert.ToInt32(items[1])));

        }
    }

    private void xOy()
    {
        for (int i = 0; i < _amountXDivision; i++)
        {
            Instantiate(_xDivision, new Vector3(i * _scale, 0, 0), Quaternion.identity);
        }
        for (int i = 0; i < _amountYDivision; i++)
        {
            Instantiate(_yDivision, new Vector3( 0, i * _scale, 0), Quaternion.identity);
        }
    }

    public void SpawnPoints(List<(int,int)> coordinates) 
    {
        _points = new(coordinates.Count);

        for (int i = 0; i < coordinates.Count; i++)
        {
            _points.Add(Instantiate(_point));
        }
    }

    public void LocatePoints(List<(int, int)> coordinates) 
    {
        foreach (var c in coordinates)
        {
            _tops.Add(new(c.Item1 * _scale, c.Item2 * _scale));


        }

        for (int i = 0; i < _tops.Count; i++)
        {
            _points[i].transform.position = _tops[i];
        }
        _lineRenderer.positionCount= _tops.Count;
        _lineRenderer.SetPositions(_tops.ToArray());
    }
}
