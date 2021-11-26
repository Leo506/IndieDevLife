using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EducationController : MonoBehaviour
{
    [SerializeField] UIController eduCanvas;

    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        bool needShowEdu = false;

        switch (sceneName)
        {
            case "Room":
                if (!Education.roomEduShown)
                {
                    needShowEdu = true;
                    Education.roomEduShown = true;
                }
                    
                break;

            case "NewTown":
                if (!Education.streetEduShown)
                {
                    needShowEdu = true;
                    Education.streetEduShown = true;
                }
                    
                break;

            case "NewTown2":
                if (!Education.street2EduShown)
                {
                    needShowEdu = true;
                    Education.street2EduShown = true;
                }
                    
                break;

            default:
                break;
        }

        if (needShowEdu)
        {
            eduCanvas.EnableUI();
            PlayerMovement.instance.CantMove();
        }
    }
}
