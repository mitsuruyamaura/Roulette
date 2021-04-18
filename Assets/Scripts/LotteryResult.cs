
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一定時間ごとに抽選して中世結果を画面表示
/// </summary>
public class LotteryResult : MonoBehaviour
{
    private GameObject lotteryResultObj;
    private bool isLottery;

    private float timer;
    public float lotteryTime;

    void Start() {
        lotteryResultObj = GameObject.Find("LotteryResult");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            isLottery = true;
        }

        if (isLottery == true) {
            timer += Time.deltaTime;

            if (timer > lotteryTime) {
                // おみくじの抽選
                SubmitLottery();
            }
        }
    }

    /// <summary>
    /// おみくじの抽選
    /// </summary>
    private void SubmitLottery() {

        // eulerAngles を利用すると、0 ～ 360 の角度が取得できる。rotation を利用すると 0 ～ 1.0f, 1.0f ～ -1.0f になるので注意
        // 逆回転(時計の反対周り)の場合にも対応している
        if (transform.eulerAngles.z >= 30 && transform.eulerAngles.z < 90) {
            lotteryResultObj.GetComponent<Text>().text = "大吉";
        } else if (transform.eulerAngles.z >= 90 && transform.eulerAngles.z < 150) {
            lotteryResultObj.GetComponent<Text>().text = "大凶";
        } else if (transform.eulerAngles.z >= 150 && transform.eulerAngles.z < 210) {
            lotteryResultObj.GetComponent<Text>().text = "小吉";
        } else if (transform.eulerAngles.z >= 210 && transform.eulerAngles.z < 270) {
            lotteryResultObj.GetComponent<Text>().text = "末吉";
        } else if (transform.eulerAngles.z >= 270 && transform.eulerAngles.z < 330) {
            lotteryResultObj.GetComponent<Text>().text = "中吉";
        } else {
            lotteryResultObj.GetComponent<Text>().text = "凶";
        }

        // 再抽選のための準備
        timer = 0;

        isLottery = false;

        Debug.Log(transform.eulerAngles.z);
    }
}
