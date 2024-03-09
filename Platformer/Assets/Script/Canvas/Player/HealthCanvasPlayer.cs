using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthCanvasPlayer : MonoBehaviour
{
    [SerializeField] private GameObject charackter;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Canvas restartCanvas;

    private Health health;

    private void Awake()
    {
        health = charackter.GetComponent<Health>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.health.ToString();
        if(charackter == null)
        {
            Time.timeScale = 0;
            restartCanvas.gameObject.SetActive(true);
        }
    }
}
