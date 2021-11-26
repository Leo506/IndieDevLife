using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    int[] prize = { 20, 500, 1000 };
    [SerializeField] AddController add;

    public void Purchase(int index)
    {
        Money.ChangeFloppyDisks(prize[index]);
    }

    public void SeeAdd()
    {
        if (AddController.addIsAvailible)
        {
            add.TryShowAdd();
            Money.ChangeFloppyDisks(prize[0]);
        }
    }

    public void DisableAdd()
    {
        AddController.addIsAvailible = false;
    }
}
