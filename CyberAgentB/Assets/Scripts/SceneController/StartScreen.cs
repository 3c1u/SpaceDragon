// スパゲッティおいしい

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SceneController {
  public class StartScreen : MonoBehaviour {
    [SerializeField] private Image fadePlane;
    [SerializeField] private float fadeCoefficient = 1.5f;
    private                  bool  isAnimating     = false;
    private                  bool  isFadeIn        = false;
    private                  float opacity         = 1.0f;

    [SerializeField] private Text  blinkText;

    [SerializeField] private Color darkTextColour;
    [SerializeField] private Color brightTextColour;

    private Color camColor;

    private bool sceneTransitionFlag = false;

    void Start() {
      isAnimating = true;
      isFadeIn = true;

      camColor = Camera.main.backgroundColor;
      Camera.main.backgroundColor = Color.black;
    }

    void Update() {
      if (Input.GetMouseButtonDown(0)) {
        isFadeIn            = false;
        isAnimating         = true;
        sceneTransitionFlag = true;
      }
      
      for (var i = 0; i < Input.touchCount; i++) {
        if (sceneTransitionFlag)
          break;
        
        Touch touch = Input.GetTouch(i);

        if (touch.phase == TouchPhase.Began) {
          isFadeIn    = false;
          isAnimating = true;
          sceneTransitionFlag = true;
        }
      }

      if (!isAnimating)
        return;
      
      if (isFadeIn) {
        opacity -= fadeCoefficient * Time.deltaTime;
        if (opacity <= 0) {
          opacity     = 0;
          isAnimating = false;
          
          StartCoroutine(BlinkMessage());
        }
      }
      else {
        opacity += fadeCoefficient * Time.deltaTime;
          
        if (opacity >= 1) {
          opacity     = 1;
          isAnimating = false;

          if (sceneTransitionFlag) {
            SwitchToGameScene();
          }
        }
      }
      
      var prevColor = fadePlane.color;
      prevColor.a = opacity;
      fadePlane.color = prevColor;

      Camera.main.backgroundColor = new Color(camColor.r * (1 - opacity),
                                              camColor.g * (1 - opacity),
                                              camColor.b * (1 - opacity),
                                              1.0f);
    }

    void SwitchToGameScene() {
      StopCoroutine(BlinkMessage());
      
      // ゲームの初期化
      
      // ステージ画面に遷移
      SceneManager.LoadScene("Scenes/SCENE");
    }

    IEnumerator BlinkMessage() {
      while (true) {
        iTween.ColorTo(blinkText.gameObject, iTween.Hash(
                                                         "from", darkTextColour,
                                                         "to", brightTextColour,
                                                         "onupdate", "UpdateTextColour",
                                                         "time", 0.3f
                                                         ));
        yield return new WaitForSeconds(0.5f);
        iTween.ColorTo(blinkText.gameObject, iTween.Hash(
                                                         "from", brightTextColour,
                                                         "to", darkTextColour,
                                                         "onupdate", "UpdateTextColour",
                                                         "time", 0.3f
                                                        ));
        yield return new WaitForSeconds(0.5f);
      }
    }

    void UpdateTextColour(Color colour) {
      blinkText.color = colour;
    }
  }
}
