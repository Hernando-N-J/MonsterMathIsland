using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Points : MonoBehaviour
{
    public int points = 0;
    [SerializeField] private List<int> randNumbers;
    

    private void Awake()
    {
        SortRandomNumbers();
    }

    private void SortRandomNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            var n = Random.Range(0, 20);
            randNumbers.Add(n);
        }
        
        randNumbers.Sort();
        foreach (var v in randNumbers)
        {
            Debug.Log(v);
        }
    }
}
