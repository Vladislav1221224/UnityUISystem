using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenView : MonoBehaviour
{
    #region Properties

    [SerializeField] TextMeshProUGUI _currentProcessText;
    [SerializeField] Slider _loadingProgressBar;

    float _progress = 0f;

    #endregion

    #region Methods

    #region Unity methods

    private void Awake()
    {
        _loadingProgressBar.value = 0;
    }

    private void Update()
    {
        if (_progress != _loadingProgressBar.value)
        {
            _loadingProgressBar.value = Mathf.Lerp(_loadingProgressBar.value, _progress, 0.25f);
        }
    }

    #endregion

    /// <summary>
    /// �������� �������� �������� � ������� ��������� ������������ ��� Lerp.
    /// ϳ������� ���� ������� ������ ������� ������� ��� ��������. 
    /// ��������� ReloadGame.
    /// </summary>
    public void SetProgress(float progress)
    {
        _progress = progress;
        _loadingProgressBar.value = _progress;
    }
    /// <summary>
    /// ������� �������� �������� �� ������� ����� UI ��������.
    /// </summary>
    public void UpdateProgress(float progress)
    {
        _progress = progress;
    }

    public void SetProcess(string process)
    {
        _currentProcessText.text = process;
    }

    #endregion
}