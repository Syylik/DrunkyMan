using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int metres;
    public float gameSpeed = 1;

    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMP_Text losePanelMetresText, inGameMetresText;
    public static GameManager instance { get; private set; }
    private void Awake() => instance = this;
    private void Start()
    {
        StartCoroutine(MetresAdd());
    }
    private void Update()
    {
        if(gameSpeed <= 4) gameSpeed += Time.deltaTime / 100;
    }
    private IEnumerator MetresAdd()
    {
        if(losePanel.activeSelf) yield return null;
        if(gameSpeed < 2f) yield return new WaitForSeconds(Random.Range(1f, 1.7f));
        else yield return new WaitForSeconds(Random.Range(0.6f, 1.2f));
        metres++;
        inGameMetresText.text = $"{metres}M";
        StartCoroutine(MetresAdd());
    }
    public void Lose()
    {
        Time.timeScale = 0;
        losePanelMetresText.text = $"{metres}M";
        losePanel.SetActive(true);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
