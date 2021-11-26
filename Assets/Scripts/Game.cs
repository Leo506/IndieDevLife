using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Game
{
    // Статусы персонажа
    Dictionary<string, int> foodList;
    float hungry;
    float sleep;
    int money;
    int floppyDisks;
    int creativityLvl;
    int staminaLvl;
    int stomachLvl;
    int possionLvl;
    int playerLvl;
    int currentExp;
    int skillPoint;

    // Инфа про курсы
    Curses.CurseStatus[] curses;

    // Статистика по играм
    List<CreatedGame> gameArchive;

    // Информация для созадания игры
    float completeTime;
    float timeToCreateGame;
    int chanceToCrunch;
    string gameName;
    GameState gameState;
    DateTime endCreateGameTime;

    // Ежедневные бонусы
    DateTime timeOfLastBonus;
    int bonusIndex;

    // Достижения
    bool[] achieveGotten;

    // Настройки
    bool musicIsOn;
    bool langIsRus;
    bool soundsIsOn;

    // Бусты
    bool onEnergy;
    DateTime energyTime;

    bool onFood;
    DateTime foodTime;

    bool onCreativity;
    bool onTalant;

    // Реклама
    bool addAvailible;

    // Обучение
    bool greetingsShown;
    bool roomEduShown;
    bool streetEduShown;
    bool street2EduShown;

    // Был ли хит?
    bool wasHit;


    public static void ResetGame() {
        Food.ResetData();
        Hungry.ResetData();
        Sleep.ResetData();
        Money.ResetData();
        SkillsLvl.ResetData();
        Curses.ResetData();
        Player.ResetData();
        GamesArchive.ResetData();
        Publisher.ResetData();
        UIController.ResetData();
        CreatingGameInfo.ResetData();
        AchievementsList.ResetData();
    }

    public Game() {
        foodList = Food.GetFoodList();
        hungry = Hungry.hungry;
        sleep = Sleep.GetSleepValue();
        money = Money.GetMoney();
        floppyDisks = Money.GetFloppyDisks();
        creativityLvl = SkillsLvl.creativityLvl;
        staminaLvl = SkillsLvl.staminaLvl;
        stomachLvl = SkillsLvl.stomachLvl;
        possionLvl = SkillsLvl.possionLvl;
        curses = Curses.GetCurses();
        skillPoint = Player.GetSkillPoints();
        gameArchive = GamesArchive.GetGames();
        timeOfLastBonus = DailyBonusController.timeOfLastBonus;
        bonusIndex = DailyBonusController.bonusIndex;

        achieveGotten = new bool[AchievementsList.progress.Length];
        for (int i = 0; i < achieveGotten.Length; i++)
        {
            achieveGotten[i] = AchievementsList.progress[i].priceIsGotten;
        }

        musicIsOn = SettingsController.musicIsOn;
        langIsRus = SettingsController.langIsRus;
        soundsIsOn = SettingsController.soundsIsOn;

        onEnergy = Boosts.IsPlayerOnEnergy();
        energyTime = Boosts.startEnergyTime;
        onFood = Boosts.IsPlayerOnFood();
        foodTime = Boosts.startFoodTime;
        onCreativity = Boosts.IsPlayerOnCreativity();
        onTalant = Boosts.IsPlayerOnTalant();

        completeTime = CreatingGameInfo.CompleteTime;
        timeToCreateGame = CreatingGameInfo.TimeToCreateGame;
        chanceToCrunch = CreatingGameInfo.ChanceToCrunch;
        gameName = CreatingGameInfo.GameName;
        gameState = CreatingGameInfo.gameState;
        endCreateGameTime = GameCreator.CreateGameEndTime;

        addAvailible = AddController.addIsAvailible;

        greetingsShown = Education.greetingsShown;
        roomEduShown = Education.roomEduShown;
        streetEduShown = Education.streetEduShown;
        street2EduShown = Education.street2EduShown;

        wasHit = Publisher.wasHit;
    }

    public void Load() {
        Food.SetFoodList(foodList);
        Hungry.hungry = hungry;
        Sleep.SetSleepValue(sleep);
        Money.SetMoney(money, floppyDisks);
        SkillsLvl.creativityLvl = creativityLvl;
        SkillsLvl.staminaLvl = staminaLvl;
        SkillsLvl.stomachLvl = stomachLvl;
        SkillsLvl.possionLvl = possionLvl;
        Curses.SetCurses(curses);
        Player.SetPlayer(skillPoint);
        GamesArchive.SetGameArchive(gameArchive);
        DailyBonusController.timeOfLastBonus = timeOfLastBonus;
        DailyBonusController.bonusIndex = bonusIndex;

        for (int i = 0; i < achieveGotten.Length; i++)
        {
            AchievementsList.progress[i].priceIsGotten = achieveGotten[i];
        }

        SettingsController.langIsRus = langIsRus;
        SettingsController.musicIsOn = musicIsOn;
        SettingsController.soundsIsOn = soundsIsOn;

        Boosts.SetUp(onEnergy, onFood, onCreativity, onTalant, energyTime, foodTime);

        CreatingGameInfo.CompleteTime = completeTime;
        CreatingGameInfo.TimeToCreateGame = timeToCreateGame;
        CreatingGameInfo.ChanceToCrunch = chanceToCrunch;
        CreatingGameInfo.GameName = gameName;
        CreatingGameInfo.gameState = gameState;
        GameCreator.CreateGameEndTime = endCreateGameTime;

        AddController.addIsAvailible = addAvailible;

        Education.greetingsShown = greetingsShown;
        Education.roomEduShown = roomEduShown;
        Education.streetEduShown = streetEduShown;
        Education.street2EduShown = street2EduShown;

        Publisher.wasHit = wasHit;
    }
}
