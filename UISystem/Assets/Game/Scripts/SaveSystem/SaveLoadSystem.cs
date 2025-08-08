using System;
using System.Threading.Tasks;

using UnityEditor;

using UnityEngine;


/// <summary>
/// ���������� ���� � ���� ���(������), ���� ��������
/// </summary>
public class SaveLoadSystem
{
    #region Methods

    #region Getters

    public async Task<GameData> GetData(IProgress<float> progress)
    {
        return await ReadData(progress);
    }

    #endregion

    #region Read
    //�� ��� ���� ���
    private async Task<GameData> ReadData(IProgress<float> progress)
    {
        float loadTime = 1f;
        float elapsed = 0f;

        while (elapsed < loadTime)
        {
            await Task.Delay(100);
            elapsed += 0.1f;
            float value = Mathf.Clamp01(elapsed / loadTime);
            progress?.Report(value);
        }

        return new GameData();
    }

    #endregion

    #region Write

    //�� ��� ������ ���
    private async Task<GameData> WriteData(IProgress<float> progress)
    {
        float loadTime = 2f;
        float elapsed = 0f;

        while (elapsed < loadTime)
        {
            await Task.Delay(100);
            elapsed += 0.1f;
            float value = Mathf.Clamp01(elapsed / loadTime);
            progress?.Report(value);
        }

        return new GameData();
    }

    #endregion

    #endregion
}