using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsForObstacles;
    [SerializeField] private Obstacle[] _obstacles;

    private void Start()
    {
        for (int i = 0; i < _pointsForObstacles.Length; i++)
        {
            Instantiate(_obstacles[Random.Range(0,_obstacles.Length)], _pointsForObstacles[i]
                );
        }
    }
}
