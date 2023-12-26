using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Test : MonoBehaviour
{
    private List<int> nums;
    private List<(int, int)> _points;
    // Start is called before the first frame update
    async void Start()
    {
        _points = new List<(int, int)> ();
        //nums = new List<int>(1000000);

        var sr = new StreamReader($"{Application.persistentDataPath}/2.txt");

        ExtractData2(sr);

        Sort(_points);

        foreach (var point in _points)
        {
            Debug.Log($"{point.Item1} : {point.Item2}");
        }
        //_points = ExtractData2(sr).ToList();
        using (FileStream fstream = new FileStream($"{Application.persistentDataPath}/2.txt", FileMode.OpenOrCreate))
        {
            
            // ����������� ������ � �����
           // byte[] buffer = Encoding.Default.GetBytes(text);
            // ������ ������� ������ � ����
            //await fstream.WriteAsync(buffer, 0, buffer.Length);
            Console.WriteLine("����� ������� � ����");
        }
        //Debug.Log(stAirs(nums, 100));
    }

    private static IEnumerable<int> ExtractData(StreamReader sr)
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            var items = line.Split(',');
            foreach (var item in items)
            {
                yield return Convert.ToInt32(item);
            }
        }
    }

    private void ExtractData2(StreamReader sr)
    {
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            var items = line.Split(' ');
            _points.Add((Convert.ToInt32(items[0]), Convert.ToInt32(items[1])));
            
        }
    }

    private void Sort(List<(int, int)> points) 
    {
        points.Sort();
    }

    private bool Solve(List<(int, int)> points) 
    {
        return true;
    }

    private int stAirs(List<int> nums, int A)
    {
        int answer = 0;
        int n = nums.Count;

        for (int i = 0; i < n; ++i)
        {
            for (int j = i; j < n; ++j)
            {
                if (nums[j] != j - i + 1)
                {
                    if (nums[j] == A)
                    {
                        answer++;
                    }
                    break;
                }
            }
        }

        return answer;
    }
}
