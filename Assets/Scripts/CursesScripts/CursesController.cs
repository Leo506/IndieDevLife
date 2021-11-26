using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursesController : MonoBehaviour
{
    [Header("Кнопки прохождения курсов")]
    [SerializeField] UnityEngine.UI.Button[] _buyCurseButtons;

    public static CursesController instance;


    private void Awake() {
        instance = this;
        CheckCursesStatus();
    }

    // Фунция прохождения курса
    public void CompleteCurse(int index)
    {
        if (index <= 2)  // Если курс не за дискеты
        {
            if (Money.GetMoney() >= Curses.GetCursePrice(index))
            {
                Curses.ChangeCurseStatus(index, Curses.CurseStatus.Complete);  // Меняем состояние пройденного курса
                Curses.ChangeCurseStatus(index + 1, Curses.CurseStatus.NotComplete);
                Debug.Log("[LOG] Curse 1 status: " + Curses.GetCurseStatus(index));
                Money.ChangeMoney(-Curses.GetCursePrice(index));
                Events.instance.Notify(EventTypes.CURSE_TOOK);
            }
        } else  // Если курс проходится за дискеты
        {
            if (Money.GetFloppyDisks() >= Curses.GetCursePrice(index))
            {
                Curses.ChangeCurseStatus(index, Curses.CurseStatus.Complete);  // Меняем состояние пройденного курса
                Debug.Log("[LOG] Curse 1 status: " + Curses.GetCurseStatus(index));
                Money.ChangeFloppyDisks(-Curses.GetCursePrice(index));
                Events.instance.Notify(EventTypes.CURSE_TOOK);
            }
        }

        CheckCursesStatus();
        
    }

    public void CheckCursesStatus() {
        for (int i = 0; i < _buyCurseButtons.Length; i++)
        {
            var status = Curses.GetCurseStatus(i + 1);
            if (status == Curses.CurseStatus.Complete || status == Curses.CurseStatus.NotAvailable) _buyCurseButtons[i].enabled = false;
            else _buyCurseButtons[i].enabled = true;
        }
    }
}
