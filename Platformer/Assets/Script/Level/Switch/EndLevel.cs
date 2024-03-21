using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    [SerializeField] private Canvas endLvlCanvas;
    [SerializeField] private PointsPlayer playerPoint;
    [SerializeField] private TextMeshProUGUI pointText;
   
    [SerializeField] private int numberLevelOpen;// индекс открываемой сцены

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            pointText.text = pointText.text + $"{playerPoint.pointPlayer}";
            endLvlCanvas.gameObject.SetActive(true);
        }
    }

    public void NextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(numberLevelOpen);

    }

    public void OpenMenu() => SceneManager.LoadScene(0);
   
}
