using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    public string menuName;
    [SerializeField] bool _isSetsActive = true;
    [SerializeField] UnityEvent OnOpen;
    [SerializeField] UnityEvent OnClose;

    public void Open()
    {
        if (_isSetsActive && gameObject)
            gameObject.SetActive(true);
        OnOpen.Invoke();
    }
    public void Close()
    {
        if (_isSetsActive && gameObject)
            gameObject.SetActive(false);
        OnClose.Invoke();
    }
}
