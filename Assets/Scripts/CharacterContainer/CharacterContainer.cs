using Dreamteck.Splines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    [SerializeField] private SplineComputer _splineComputer;
    [SerializeField] private SplineFollower _splineFolower;
    [SerializeField] private PlayerCharacter _character;
    //[SerializeField] private int _charactersCount;
    [SerializeField] private int _positionPointsWidth;
    [SerializeField] private int _positionPointsLength;

    private List<PlayerCharacter> _playerCharacters = new List<PlayerCharacter>();
    private Transform[,] _positionPoints;
    private Vector3 _positionToSpawn;

    private void Start()
    {
        _positionPoints = new Transform[_positionPointsWidth, _positionPointsLength];
        PlayerCharacter currentPlayerCharacter;

        //for (int i = -_positionPoints.GetLength(0) / 2; i < _positionPoints.GetLength(0) / 2; i++)
        //{
        //    for (int j = -_positionPoints.GetLength(1) / 2; j < _positionPoints.GetLength(1) / 2; j++)
        //    {
        //        _positionToSpawn = new Vector3(i, 0, j);
        //        Instantiate(_character, _positionToSpawn, Quaternion.identity, transform);
        //    }
        //}

        for (int i = 0; i < _positionPoints.GetLength(0); i++)
        {
            for (int j = 0; j < _positionPoints.GetLength(1); j++)
            {
                _positionToSpawn = new Vector3(i, 0, j);
                _playerCharacters.Add(Instantiate(_character, transform.position + _positionToSpawn, Quaternion.identity, transform));

            }
        }

        foreach (var playerCharacter in _playerCharacters)
        {
            playerCharacter.PlayerCharacterDied += PlayerCharacterDeath;
        }
    }

    private void PlayerCharacterDeath(PlayerCharacter playerCharacter)
    {
        _playerCharacters.Remove(playerCharacter);
        
        if (_playerCharacters.Count <= 0)
        {
            LoseLevel();
        }
    }

    public void WinLevel()
    {
        foreach (var playerCharacter in _playerCharacters)
        {
            playerCharacter.Finish();
        }
    }

    private void LoseLevel()
    {
        _splineFolower.follow = false;
    }
}
