using UnityEngine;
public interface IObserver
{
    void OnNotify(EventTypes eventType);
}

public enum EventTypes
    {
        ACHIEVEMENT_GOT,
        GAME_CREATED,
        CURSE_TOOK,
        MONEY_CHANGED,
        GAME_PUBLISHED,
        CANVAS_ENABLE,
        CANVAS_DISABLE,
        SIT_DOWN,
        STAND_UP,
        NORMAL_CLICK,
        UPGRADE_SKILL,
        FRIDGE_OPEN,
        FRIDGE_CLOSE,
        EAT,
        GO_TO_BED,
        UP_FROM_BED,
        SLEEPING,
        WAKE_UP,
        SUCCESS,
        FAILED,
        EXIT,
        ENTER,
        HUNGRY,
        SLEEPY,
        BUY,
        GO_TO_WORK,
        GOOD,
        BAD,
        SHOOT,
        ASTEROID_HIT,
        ASTEROID_LOSS,
        JOB_FINISH,
        GET_PACKAGE,
        PUT_PACKAGE,
        PROGRAMMER_SET_UP,
        CARD_CLICK,
        END_CREATING
};