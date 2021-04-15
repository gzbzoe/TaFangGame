using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    //将UIManager类设置为一个单例，方便其他类调用
    public static UIManager instance;
    //开始界面隐藏，显示关卡选择界面
    public GameObject StartPanel;
    public GameObject LevelPanel;
    public GameObject LosePanel;
    public GameObject VictoryPanel;
    public Text HPtext;//血量显示框
    public int HP=100;//血量
    public Text MoneyText;//金钱显示框
    public int Money = 1000;//金钱
    void Start () {
        instance = this;
        //血量初始化
        HPtext.text = HP + "";
        //金钱初始化
        MoneyText.text = Money + "";
	}
	
	
	void Update () {
        HPtext.text = HP + ""; //实时检测血量值
        MoneyText.text = Money + "";//实时检测金钱值
    }
    //开始游戏
    public void StartOnClick()
    {
        StartPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }
    //关卡选择界面返回开始界面
    public void LevelOnClick()
    {
        LevelPanel.SetActive(false);
        StartPanel.SetActive(true);
        
    }
    //关卡选择按钮
    public void SceneOnClick(int num)
    {
        SceneManager.LoadScene(num);
        HP = 100;
        Money = 1000;
    }
    //游戏失败，跳出losepanel
    public void Lose()
    {
        LosePanel.SetActive(true);
        //游戏暂停
        Time.timeScale = 0;
    }
    //退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }
}
