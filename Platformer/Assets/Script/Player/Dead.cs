using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    /// <summary>
    /// ��� ������ ������������� �����
    /// </summary>
    public static void DeadPlayer() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

}
