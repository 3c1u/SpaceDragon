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

    private bool sceneTransitionFlag = false;

    void Start() {
      isAnimating = true;
      isFadeIn = true;
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
        }
      }
      else {
        opacity += fadeCoefficient * Time.deltaTime;
          
        if (opacity >= 1) {
          opacity     = 1;
          isAnimating = false;

          if (sceneTransitionFlag) {
            // TODO: シーン遷移
            ResultScreen.InvokeResultScreen(10000, "A+", true);
          }
        }
      }
      
      var prevColor = fadePlane.color;
      prevColor.a = opacity;
      fadePlane.color = prevColor;
    }
  }
}
