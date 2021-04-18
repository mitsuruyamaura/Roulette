
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotteryResult : MonoBehaviour
{
    public enum LottelyType {
        大吉,
        中吉,
        小吉,
        末吉,
        凶,
        大凶
    }

    private GameObject lotteryResultObj;
    private bool isLottery;

    private float timer;
    public float lotteryTime;

    void Start() {
        lotteryResultObj = GameObject.Find("LotteryResult");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            isLottery = true;
        }

        if (isLottery == true) {
            timer += Time.deltaTime;

            if (timer > lotteryTime) {
                SubmitLottery();
            }
        }
    }

    /// <summary>
    /// おみくじの抽選
    /// </summary>
    private void SubmitLottery() {
        //if (transform.rotation.z >= 30 && transform.rotation.z < 90) {
        //    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "大吉";
        //    //lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = LottelyType.大吉.ToString();
        //} else if (transform.rotation.z >= 90 && transform.rotation.z < 150) {
        //    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "大凶";
        //} else if (transform.rotation.z >= 150 && transform.rotation.z > -150) {
        //    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = LottelyType.小吉.ToString();
        //} else if (transform.rotation.z <= -150 && transform.rotation.z > -90) {
        //    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = LottelyType.末吉.ToString();
        //} else if (transform.rotation.z <= -90 && transform.rotation.z > -30) {
        //    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "中吉";
        //} else if (transform.rotation.z <= -30 && transform.rotation.z < 30){
        //    DisplayMessage(LottelyType.凶.ToString());
        //}

        // 再抽選のための準備
        //transform.rotation = new Quaternion(0, 0, 0, 0);

        if (transform.rotation.z > -0.166f && transform.rotation.z < 0.166f) {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "大吉";

        } else if (transform.rotation.z >= 0.166f && transform.rotation.z < 0.5f) {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "大凶";
        } else if (transform.rotation.z >= 0.5f && transform.rotation.z < 0.83f ) {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = LottelyType.小吉.ToString();
        } else if (transform.rotation.z >= 0.83f && transform.rotation.z > -0.83f) {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = LottelyType.末吉.ToString();
        //} else if () {
        //    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "中吉";
        //} else if () {
        //    DisplayMessage(LottelyType.凶.ToString());
        }

        timer = 0;

        isLottery = false;

        Debug.Log(transform.rotation.z);
    }

    /// <summary>
    /// おみくじ結果の画面表示更新
    /// </summary>
    /// <param name="message"></param>
    private void DisplayMessage(string message) {
        lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = message;
    }
}
