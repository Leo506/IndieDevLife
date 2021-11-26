using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour, IObserver
{
    AudioSource source;
    static AssetBundle sounds;

    // Start is called before the first frame update
    void Start()
    {
        Events.instance.AddObserver(this);
        source = GetComponent<AudioSource>();
        if (sounds != null)
            sounds.Unload(false);
        sounds = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/AssetBundles/sounds");

    }

    
    public void OnNotify(EventTypes eventType)
    {
        if (SettingsController.soundsIsOn)
        {
            AudioClip clip;
            string soundName = "";

            switch (eventType)
            {
                case EventTypes.CANVAS_ENABLE:
                    soundName = "DialogShow";
                    break;
                case EventTypes.CANVAS_DISABLE:
                    soundName = "DialogHide";
                    break;
                case EventTypes.SIT_DOWN:
                    soundName = "PC_On";
                    break;
                case EventTypes.STAND_UP:
                    soundName = "PC_Off";
                    break;
                case EventTypes.NORMAL_CLICK:
                    soundName = "ClickNormal";
                    break;
                case EventTypes.UPGRADE_SKILL:
                    soundName = "ClickLevelUp";
                    break;
                case EventTypes.FRIDGE_OPEN:
                    soundName = "FridgeOpen";
                    break;
                case EventTypes.FRIDGE_CLOSE:
                    soundName = "FridgeClose";
                    break;
                case EventTypes.EAT:
                    soundName = "MiscEating";
                    break;
                case EventTypes.GO_TO_BED:
                    soundName = "MiscBedDown";
                    break;
                case EventTypes.SLEEPING:
                    soundName = "MiscGoodnight";
                    break;
                case EventTypes.WAKE_UP:
                    soundName = "MiscGoodmorning";
                    break;
                case EventTypes.UP_FROM_BED:
                    soundName = "MiscBedUp";
                    break;
                case EventTypes.SUCCESS:
                    soundName = "ResultSuccess";
                    break;
                case EventTypes.EXIT:
                    soundName = "DoorClose";
                    break;
                case EventTypes.ENTER:
                    soundName = "DoorOpen";
                    break;
                case EventTypes.HUNGRY:
                    soundName = "MiscHungry";
                    break;
                case EventTypes.SLEEPY:
                    soundName = "MiscGoodnight";
                    break;
                case EventTypes.BUY:
                    soundName = "MiscBuy";
                    break;
                case EventTypes.BAD:
                    soundName = "ResultBad";
                    break;
                case EventTypes.GOOD:
                    soundName = "ResultGood";
                    break;
                case EventTypes.FAILED:
                    soundName = "ResultFail";
                    break;
                case EventTypes.ASTEROID_HIT:
                    soundName = "GamesAsteroidsHit";
                    break;
                case EventTypes.ASTEROID_LOSS:
                    soundName = "GamesAsteroidsLoss";
                    break;
                case EventTypes.SHOOT:
                    soundName = "GamesAsteroidsShot";
                    break;
                case EventTypes.JOB_FINISH:
                    soundName = "JobFinished";
                    break;
                case EventTypes.GET_PACKAGE:
                    soundName = "JobMoverTake";
                    break;
                case EventTypes.PUT_PACKAGE:
                    int index = Random.Range(1, 4);
                    soundName = $"JobMoverPut{index}";
                    break;
                case EventTypes.PROGRAMMER_SET_UP:
                    soundName = "GamesMemoryNewHand";
                    break;
                case EventTypes.CARD_CLICK:
                    soundName = "GamesMemoryCardClick";
                    break;
                default:
                    break;
            }

            if (soundName != "")
            {
                clip = sounds.LoadAsset(soundName) as AudioClip;
                source.PlayOneShot(clip, 1);
            }
        }
    }
}
