using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour
{
    private UnityEngine.UI.Text txtlotteryResult;

    void Start() {
        txtlotteryResult = GameObject.Find("LotteryResult").GetComponent<UnityEngine.UI.Text>();
    }

    /// <summary>
    /// 侵入判定を利用して抽選を判定する方式
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log(collision.name);

        Lottery lottery;

        // クラスで判定する方式。クラスに情報をそれぞれ enum の列挙子で登録してあるので、それをそのまま利用する
        if (collision.TryGetComponent(out lottery)) {
            // おみくじ結果の画面表示更新
            DisplayLotteryResultMessage(lottery.lotteryType.ToString());
            return;
        }

        // クラスで判定して、switch を使う方式
        if (collision.TryGetComponent(out lottery)) {

            // C# 8.0 以降の式型(戻り値あり用)の switch 文と enum の組み合わせで判定する方式
            txtlotteryResult.text = lottery.lotteryType switch {
                Lottery.LotteryType.大吉 => "大吉",
                Lottery.LotteryType.中吉 => "中吉",
                Lottery.LotteryType.小吉 => "小吉",
                Lottery.LotteryType.末吉 => "末吉",
                Lottery.LotteryType.凶 => "凶",
                Lottery.LotteryType.大凶 => "大凶",
                _ => "凶"
            };

            // switch 文と enum の組み合わせで判定する方式
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


        // for 文と enum の組み合わせで判定する方式
        for (int i = 0; i < (int)Lottery.LotteryType.Count; i++) {
            if (collision.gameObject.name == ((Lottery.LotteryType)i).ToString()) {
                txtlotteryResult.text = ((Lottery.LotteryType)i).ToString();
                break;
            }
        }

        // 名前(Tag でも可能)で判定する方式
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
