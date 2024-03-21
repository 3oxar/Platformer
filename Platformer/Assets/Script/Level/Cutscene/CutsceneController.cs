using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cinemachines;
    [SerializeField] private Canvas[] canvas;
    [SerializeField] private TextMeshProUGUI[] textCutscene;
    [SerializeField] private GameObject player;

    private MovePlayer move;

    private float timeCutscene = 10f;
    private bool cutsceneChek = true;

    private void Awake()
    {
        move = player.GetComponent<MovePlayer>();
    }

    void Update()
    {
        if (cutsceneChek)
        {
            move.gameObject.SetActive(false);
            timeCutscene -=Time.deltaTime;

            if (timeCutscene < 5 && timeCutscene > 4.5)
            {
                cinemachines[0].gameObject.SetActive(false);

                textCutscene[0].gameObject.SetActive(false);
                textCutscene[1].gameObject.SetActive(true);
            }
            else if (timeCutscene <= 0)
            {
                cinemachines[1].gameObject.SetActive(false);
                textCutscene[1].gameObject.SetActive(false);
                cutsceneChek = false;
            }

        }
        else
        {
            canvas[0].gameObject.SetActive(false);
            canvas[1].gameObject.SetActive(true);
            move.gameObject.SetActive(true);
            Destroy(this.gameObject.GetComponent<CutsceneController>());
        }
    }
}
