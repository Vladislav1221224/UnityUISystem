using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] protected bool _onlyOneMenu = true;
    [SerializeField] protected bool _allClosed = false;
    [SerializeField] public List<Menu> Menus;
    [SerializeField] protected Hashtable _hashTableMenus = new Hashtable();
    [SerializeField] protected Menu lastOpened = null;
    public virtual void OpenMenu(string menuName)
    {
        if (_onlyOneMenu && lastOpened != null)
        {
            if (lastOpened != null)
                lastOpened.Close();
        }
        Menu openMenu = (Menu)_hashTableMenus[menuName];
        if (openMenu != null)
            openMenu.Open();


        lastOpened = openMenu;
    }

    public virtual void CloseMenu(string menuName)
    {
        Menu openMenu = (Menu)_hashTableMenus[menuName];
        if (openMenu != null)
            openMenu.Close();


        lastOpened = openMenu;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }
    public virtual void Init()
    {
        _hashTableMenus.Clear();

        Menus = Menus.Where(menu => menu != null).ToList();

        foreach (Menu menu in Menus)
        {
            if (menu)
            {
                menu.Close();
                if (!_hashTableMenus.ContainsKey(menu.menuName))
                    _hashTableMenus.Add(menu.menuName, menu);
            }
        }
        if (!_allClosed && Menus.Count > 0 && Menus[0] != null)
            OpenMenu(Menus[0].menuName);
    }
    public void CloseAll()
    {
        foreach (var menu in Menus)
        {
            menu.Close();
        }
    }
}
