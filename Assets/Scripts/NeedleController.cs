using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour
{
    private GameObject lotteryResultObj;
    private UnityEngine.UI.Text txtlotteryResult;

    void Start() {
        lotteryResultObj = GameObject.Find("LotteryResult");
        txtlotteryResult = lotteryResultObj.GetComponent<UnityEngine.UI.Text>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log(collision.name);

        Lottery lottery;

        if (collision.TryGetComponent(out lottery)) {
            txtlotteryResult.text = lottery.lotteryType.ToString();
            return;
        }


        if (collision.TryGetComponent(out lottery)) {
            switch (lottery.lotteryType) {
                case Lottery.LotteryType.大吉:
                    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "大吉";
                    break;
                case Lottery.LotteryType.中吉:
                    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "中吉";
                    break;
                case Lottery.LotteryType.小吉:
                    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "小吉";
                    break;
                case Lottery.LotteryType.末吉:
                    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "末吉";
                    break;
                case Lottery.LotteryType.凶:
                    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "凶";
                    break;
                case Lottery.LotteryType.大凶:
                    lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "大凶";
                    break;
            }
            return;
        }


        if (collision.gameObject.name == "daikichi") {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "大吉";
        } else if (collision.gameObject.name == "chukichi") {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "中吉";
        } else if (collision.gameObject.name == "shoukichi") {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "小吉";
        } else if (collision.gameObject.name == "suekichi") {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "末吉";
        } else if (collision.gameObject.name == "kyo") {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "凶";
        } else if (collision.gameObject.name == "daikyo") {
            lotteryResultObj.GetComponent<UnityEngine.UI.Text>().text = "大凶";
        }
    }
}
