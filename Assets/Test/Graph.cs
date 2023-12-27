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
        var sr = new StreamReader($"{Application.persistentDataPath}/5_2.txt");
        _pointsPos = new();
        ExtractData2(sr);
        _tops = new(_pointsPos.Count);

        Sort(_pointsPos);

        Debug.Log(Solve(_pointsPos));
        //WriteDataIntoFile(_pointsPos);
        // tilt = 286 
        //(-999982804, 931735985)
        // (999983090, 931735985)

        //(-999983090, 931735985)
        // (999982804, 931735985)

        // tilt = 143
        //(-999982947, 931735985)
        // (999982947, 931735985)

        //xOy();
        //SpawnPoints(_pointsPos);
        //LocatePoints(_pointsPos);
    }

    private bool Solve(List<(int, int)> points)
    {
        // опущу часть для нечетного кол-ва точек для простоты, потому что у нас графики по 30 и 200000 точек
        List<(int, int)> leftPoints = new();
        List<(int, int)> rightPoints = new();

        //как брать сдвиг, если обе Х > 0 или обе Х < 0, берем большую по модулю Х как сдвиг
        //если левая точка Х < 0, то берем разницу по модулю и делим на 2
        // в любом случае отнимать половину сдвига

        // надо узнать кол-во точек, если оно четное(% 2 ==0) брать модуль разницы двух средних точек(от большего по модулю отнять меньшее по модулю), если разница нечетная, то 
        //
        //
        // если нечетное кол-во, то брать центральную, если она не равна 0, то брать ее Х значение как сдвиг
        // и отнимать у всех точек половину этого сдвига
        // сравнивать все точки, если Х совпал, то проверять Y, если Х или Y не совпал, то функция не четная



        // определяем сдвиг (мы уже знаем, что у второго графика сдвиг = 143)

        float shift;

        int pointCount = points.Count;

        // 0 1 2 3 4 5

        // 0 1 2 3 4 5 6 7 8 9 10

        (int, int) leftPoint;
        (int, int) rightPoint;

        if (pointCount % 2 == 0)
        {
            Debug.Log("even");
            leftPoint = points[(pointCount / 2) - 1];
            rightPoint = points[(pointCount / 2)];
            Debug.Log(leftPoint);
            Debug.Log(rightPoint);
            if ((leftPoint.Item1 > 0 && rightPoint.Item1 > 0))
            {
                Debug.Log("if");
                //int max = Math.Max(Math.Abs(leftPoint.Item1), Math.Abs(rightPoint.Item1));
                int betweenPoints = rightPoint.Item1 - leftPoint.Item1;
                shift = (betweenPoints / 2) + leftPoint.Item1;// при точках 1 и 5 я получу 3
                shift *= -1;
            }
            else if ((leftPoint.Item1 < 0 && rightPoint.Item1 < 0))
            {
                Debug.Log("else if");
                int betweenPoints = leftPoint.Item1 - rightPoint.Item1;
                shift = (betweenPoints / 2) - leftPoint.Item1;// при точках -5 и -1 я получу -3
                //shift *= -1;
            }
            else
            {
                Debug.Log("else");
                int betweenPoints = (rightPoint.Item1 - leftPoint.Item1) / 2;
                // при точках -5 и 1 я получу 3
                if (Math.Abs(leftPoint.Item1) > Math.Abs(rightPoint.Item1))
                {//перевес вправо
                    Debug.Log("if in else");
                    shift = Math.Abs(leftPoint.Item1 + betweenPoints);// shift = 2
                }
                else
                {
                    Debug.Log("else in else");
                    shift = -(rightPoint.Item1 - betweenPoints);// shift = 2
                }
            }
        }
        else
        {
            Debug.Log("odd");
            shift = -points[pointCount / 2].Item1;
        }

        List<(int, int)> tempPoints = new(points.Count);

        foreach (var point in points)
        {
            tempPoints.Add((point.Item1 + (int)shift, point.Item2));
        }

        foreach (var point in tempPoints)
        {
            if (point.Item1 < 0) //если икс отрицательный, то добавляем точку в левый список
            {
                leftPoints.Add(point);
            }
            else //if(point.Item1 > 0)// иначе в правый
            {
                rightPoints.Add(point);
            }
        }

        leftPoints.Sort();
        rightPoints.Sort();

        Debug.Log("shift "+ shift);
        Debug.Log("Left");
        foreach (var p in leftPoints)
        {
            Debug.Log(p);
        }

        Debug.Log("Right");
        foreach (var p in rightPoints)
        {
            Debug.Log(p);
        }
        rightPoints.Reverse();
        if (rightPoints[0].Item1 == 0) rightPoints.RemoveAt(0);

        //if (leftPoints.Count == rightPoints.Count)
        //{
            for (int i = 0; i < leftPoints.Count; i++)
            {
                //int tempDiff = (leftPoints.Count - i - 1);

                Debug.Log($"x {leftPoints[i].Item1} {rightPoints[i].Item1}");
                if (Math.Abs(leftPoints[i].Item1) != Math.Abs(rightPoints[i].Item1))
                {// step 1 проверить есть ли одинаковые иксы, например -1 и 1, -43 и 43 и тд, если нет, то return false
                    Debug.Log("x !=");
                    return false;
                }
                else
                {
                    Debug.Log($"y {leftPoints[i].Item2} {rightPoints[i].Item2}");
                    if (leftPoints[i].Item2 != rightPoints[i].Item2)
                    {// step 2 сравнить для каждой пары иксов их игреки, они должны быть равны, если нет, то return false
                        Debug.Log("y !=");
                        return false;
                    }
                }
            }
        //}
        //else 
        //{
        //    for (int i = 0; i < leftPoints.Count; i++)
        //    {
        //        int tempDiff = (leftPoints.Count - i);

        //        Debug.Log($"x {leftPoints[i].Item1} {rightPoints[tempDiff].Item1}");
        //        if (Math.Abs(leftPoints[i].Item1) != Math.Abs(rightPoints[tempDiff].Item1))
        //        {// step 1 проверить есть ли одинаковые иксы, например -1 и 1, -43 и 43 и тд, если нет, то return false
        //            Debug.Log("x !=");
        //            return false;
        //        }
        //        else
        //        {
        //            Debug.Log($"y {leftPoints[i].Item2} {rightPoints[tempDiff].Item2}");
        //            if (leftPoints[i].Item2 != rightPoints[tempDiff].Item2)
        //            {// step 2 сравнить для каждой пары иксов их игреки, они должны быть равны, если нет, то return false
        //                Debug.Log("y !=");
        //                return false;
        //            }
        //        }
        //    }

        //}



        return true;
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

    private void Sort(List<(int, int)> points)
    {
        points.Sort();
    }

    private void WriteDataIntoFile(List<(int, int)> points)
    {
        string[] lines = new string[points.Count];

        for (int i = 0; i < points.Count; i++)
        {
            lines[i] = $"{points[i].Item1} {points[i].Item2}";
        }
        System.IO.File.WriteAllLines($"{Application.persistentDataPath}/3.txt", lines);
    }

    private void xOy()
    {
        for (int i = 0; i < _amountXDivision; i++)
        {
            Instantiate(_xDivision, new Vector3(i * _scale, 0, 0), Quaternion.identity);
        }
        for (int i = 0; i < _amountYDivision; i++)
        {
            Instantiate(_yDivision, new Vector3(0, i * _scale, 0), Quaternion.identity);
        }
    }

    public void SpawnPoints(List<(int, int)> coordinates)
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
        _lineRenderer.positionCount = _tops.Count;
        _lineRenderer.SetPositions(_tops.ToArray());
    }
}
