using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CreatedGame
{
    public string name { get; private set; }
    public int receivedMoney { get; private set; }
    public bool isPublished { get; private set; }

    public CreatedGame(string name, int money, bool pub)
    {
        this.name = name;
        this.receivedMoney = money;
        this.isPublished = pub;
    }
}
