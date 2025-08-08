using UnityEngine;

/// <summary>
/// Зберігає дані: час, випадкове число
/// </summary>
public struct GameData
{
    public GameData(float time, int number)
    {
        _time = time;
        _number = number;
    }

    float _time;
    int _number;
    public float Time => _time;
    public int Number => _number;
}