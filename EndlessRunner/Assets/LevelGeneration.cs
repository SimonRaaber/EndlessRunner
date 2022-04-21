using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private Tilemap _level;
    [SerializeField] private Transform _player;

    private Vector3Int _position = new Vector3Int(0, -5, 0);
    private Tilemap[] _levelParts;
    private Tilemap _start;

    // Start is called before the first frame update
    void Start()
    {
        _levelParts = Resources.LoadAll<Tilemap>("LevelParts");
        _start = Resources.Load<Tilemap>("LevelStart/Start");

        SetLevelPart(_start);
    }
    
    // Update is called once per frame
    void Update()
    { 
        if (_player.position.x > _position.x - 20)
        {
            SetLevelPart(GetLevelPart());
        }
    }

    private void SetLevelPart(Tilemap levelPart)
    {
        BoundsInt bounds = levelPart.cellBounds;
        _level.SetTilesBlock(new BoundsInt(_position, bounds.size), levelPart.GetTilesBlock(bounds));

        foreach (Transform child in levelPart.transform)
        {
            Vector3 childPos = child.position - bounds.center;
            Vector3 pos = _level.GetCellCenterWorld(_position) + bounds.size / 2 + childPos;
            Instantiate(child.gameObject, pos, child.rotation);
        }

        _position = new Vector3Int(_position.x + bounds.size.x, _position.y, 0);
    }

    private Tilemap GetLevelPart()
    {
        int i = UnityEngine.Random.Range(0, _levelParts.Length);
        return _levelParts[i];
    }
}