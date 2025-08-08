using TMPro;

using UnityEngine;

public class GameUIView : MonoBehaviour
{
    #region Properties

    [SerializeField] TextMeshProUGUI _gameSessionTimeText;

    #endregion

    #region Methods

    public void SetGameTime(float gameSessionTime)
    {
        _gameSessionTimeText.text = $"{gameSessionTime:F1} sec";
    }

    #endregion
}