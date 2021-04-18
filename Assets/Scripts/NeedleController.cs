using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour
{
    private UnityEngine.UI.Text txtlotteryResult;

    void Start() {
        txtlotteryResult = GameObject.Find("LotteryResult").GetComponent<UnityEngine.UI.Text>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log(collision.name);

        Lottery lottery;

        if (collision.TryGetComponent(out lottery)) {
            // おみくじ結果の画面表示更新
            DisplayLotteryResultMessage(lottery.lotteryType.ToString());
            return;
        }


        if (collision.TryGetComponent(out lottery)) {

            // C# 8.0 以降
            txtlotteryResult.text = lottery.lotteryType switch {
                Lottery.LotteryType.大吉 => "大吉",
                Lottery.LotteryType.中吉 => "中吉",
                Lottery.LotteryType.小吉 => "小吉",
                Lottery.LotteryType.末吉 => "末吉",
                Lottery.LotteryType.凶 => "凶",
                Lottery.LotteryType.大凶 => "大凶",
                _ => "凶"
            };


            switch (lottery.lotteryType) {
                case Lottery.LotteryType.大吉:
                    txtlotteryResult.text = "大吉";
                    break;
                case Lottery.LotteryType.中吉:
                    txtlotteryResult.text = "中吉";
                    break;
                case Lottery.LotteryType.小吉:
                    txtlotteryResult.text = "小吉";
                    break;
                case Lottery.LotteryType.末吉:
                    txtlotteryResult.text = "末吉";
                    break;
                case Lottery.LotteryType.凶:
                    txtlotteryResult.text = "凶";
                    break;
                case Lottery.LotteryType.大凶:
                    txtlotteryResult.text = "大凶";
                    break;
            }
            return;
        }


        if (collision.gameObject.name == "daikichi") {
            txtlotteryResult.text = "大吉";
        } else if (collision.gameObject.name == "chukichi") {
            txtlotteryResult.text = "中吉";
        } else if (collision.gameObject.name == "shoukichi") {
            txtlotteryResult.text = "小吉";
        } else if (collision.gameObject.name == "suekichi") {
            txtlotteryResult.text = "末吉";
        } else if (collision.gameObject.name == "kyo") {
            txtlotteryResult.text = "凶";
        } else if (collision.gameObject.name == "daikyo") {
            txtlotteryResult.text = "大凶";
        }
    }

    /// <summary>
    /// おみくじ結果の画面表示更新
    /// </summary>
    /// <param name="message"></param>
    private void DisplayLotteryResultMessage(string message) {
        txtlotteryResult.text = message;
    }
}
