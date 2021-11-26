using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievNotifyController : MonoBehaviour, IObserver
{
    [SerializeField] UnityEngine.UI.Image _achiveImage;
    [SerializeField] AchievementsController achievements;
    [SerializeField] Animator _animator;
    Stack<AchieveButton> recievedAchievements;
    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        recievedAchievements = new Stack<AchieveButton>();
        
    }

    private void Start() {
        Events.instance.AddObserver(this);
    }

    public void AddRecievedAchievements(AchieveButton button)
    {

        recievedAchievements.Push(button);
        ShowNotify();
    }

    void ShowNotify()
    {
        if (recievedAchievements.Count != 0)
        {
            canvas.enabled = true;
            _achiveImage.sprite = recievedAchievements.ToArray()[0].GetAchievSprite();
            _animator.SetBool("isOpen", true);
        }
        else
            _animator.SetBool("isOpen", false);
        
    }

    public void Claim()
    {
        recievedAchievements.Pop().ClaimPrice();
        canvas.enabled = false;
        ShowNotify();
    }

    public void OnNotify(EventTypes eventType)
    {
        if (eventType == EventTypes.ACHIEVEMENT_GOT)
        {
            //ShowNotify();
        }
    }
}
