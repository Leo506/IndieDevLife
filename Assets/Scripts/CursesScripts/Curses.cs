using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Curses
{
	// Возможные состояния курса
	public enum CurseStatus
	{
		Complete,
		NotComplete,
		NotAvailable
	}

	// Массив, в котором хранятся состояния всех курсов
	static CurseStatus[] curses = { CurseStatus.NotComplete, CurseStatus.NotAvailable, CurseStatus.NotAvailable };

	// Массив, в котором хранятся цены на все курсы
	static int[] cursesPrice = { 400,  1400, 1000};

	// Индексы курсов за дискеты
	static int[] floppyDiskPriceIndexs = { 2 };

	public static CurseStatus GetCurseStatus(int index)
	{
		return curses[index - 1];
	}

	public static void ChangeCurseStatus(int index, CurseStatus status)
	{
		try
		{
			curses[index - 1] = status;
		}
		catch (System.Exception)
		{

			
		}
		
	}

	public static int GetCursePrice(int index)
	{
		return cursesPrice[index - 1];
	}

	public static void ResetData() {
		curses = new CurseStatus[] { CurseStatus.NotComplete, CurseStatus.NotAvailable, CurseStatus.NotAvailable };
	}

	public static CurseStatus[] GetCurses() {
		return curses;
	}

	public static void SetCurses(CurseStatus[] cur) {
		curses = cur;
	}

	public static int GetCursesEffect()
    {
		int lastCompleteCurseIndex = -1;

        for (int i = 0; i < 3; i++)
        {
			if (curses[i] == CurseStatus.Complete)
				lastCompleteCurseIndex = i;
        }

        switch (lastCompleteCurseIndex)
        {
			case 0:
				return 1;
			case 1:
				return 3;
			case 2:
				return 6;
            default:
				return 0;
        }
    }
}
