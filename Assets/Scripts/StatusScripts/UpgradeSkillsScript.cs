using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSkillsScript : MonoBehaviour
{
    [SerializeField] Text _creativityLvlText, _staminaLvlText, _stomachLvlText, _possionLvlText, _skillsPointText;
    public static UpgradeSkillsScript instance;

    private void Awake() {
        instance = this;
    }

    public void Start() {
        _creativityLvlText.text = SkillsLvl.creativityLvl.ToString();
        _staminaLvlText.text = SkillsLvl.staminaLvl.ToString();
        _stomachLvlText.text = SkillsLvl.stomachLvl.ToString();
        _possionLvlText.text = SkillsLvl.possionLvl.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetSkillPoints() != 0)
        {
            _skillsPointText.gameObject.SetActive(true);
            _skillsPointText.text = Player.GetSkillPoints().ToString();
        }
        else _skillsPointText.gameObject.SetActive(false);
    }

    public void UpgradeLvl(string skillName)
    {
        if (Player.GetSkillPoints() != 0)
        {
            if (skillName == "Креативность")
            {
                if (SkillsLvl.creativityLvl != 10)
                {
                    SkillsLvl.creativityLvl++;
                    _creativityLvlText.text = SkillsLvl.creativityLvl.ToString();
                } else
                {
                    Player.AddSkillPoint(1);
                }
                
            }

            if (skillName == "Выносливость")
            {
                if (SkillsLvl.staminaLvl != 10) {
                    SkillsLvl.staminaLvl++;
                    _staminaLvlText.text = SkillsLvl.staminaLvl.ToString();
                } 
                else Player.AddSkillPoint(1);
            }

            if (skillName == "Крепкий желудок")
            {
                if (SkillsLvl.stomachLvl != 10) {
                    SkillsLvl.stomachLvl++;
                    _stomachLvlText.text = SkillsLvl.stomachLvl.ToString();
                } 
                else Player.AddSkillPoint(1);
            }

            if (skillName == "Страсть")
            {
                if (SkillsLvl.possionLvl != 10) {
                    SkillsLvl.possionLvl++;
                    _possionLvlText.text = SkillsLvl.possionLvl.ToString();
                } 
                else Player.AddSkillPoint(1);

                CreateGameUtils.UpdateChanceToCrunch();
            }

            Player.UseSkillPoint();
            Events.instance.Notify(EventTypes.UPGRADE_SKILL);
        }
        
    }
}
