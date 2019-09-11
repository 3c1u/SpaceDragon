using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreen : MonoBehaviour {
  private bool _initialAnimation = false;

  [SerializeField] private GameObject resultTitle;
  [SerializeField] private GameObject scoreLabel;
  [SerializeField] private GameObject rankLabel;
  [SerializeField] private GameObject resultNewRecordLabel;
  [SerializeField] private GameObject tapToReplayLabel;

  [SerializeField] private Image progressCircle;
  
  [SerializeField] private Text scoreField;
  [SerializeField] private Text rankField;

  [SerializeField] private Image fadeOverlay;

  private static int    _score     = 0;
  private static string _rank      = "F";
  private static bool   _newRecord = false;

  private bool _replayTransitionFlag = false;
  private bool _blowTransitionFlag = false;
  private bool _blowEnabled = false;
  
  public static void InvokeResultScreen(int score, string rank, bool isNewRecord) {
    _score = score;
    _rank = rank;
    _newRecord = isNewRecord;
    
    SceneManager.LoadScene("Scenes/Result");
  }
  
  void Start() {
    resultNewRecordLabel.SetActive(false);
    tapToReplayLabel.SetActive(false);

    progressCircle.fillAmount = 0f;
  }

  void Update() {
    // 最初の画面の表示を行う
    if (!_initialAnimation) {
      _initialAnimation = true;
      StartCoroutine(StartupAnimation());
    };

    // VR時にシーン遷移を検知してシーン遷移
    if (!_blowEnabled)
      return;
    
    if (GameController.Instance.Player.Breath.isActive) {
      progressCircle.fillAmount += 1.0f * Time.deltaTime;

      if (!_blowTransitionFlag) {
        _blowTransitionFlag = true;
        StartCoroutine(nameof(BlowDetection));
      }
    } else if(progressCircle.fillAmount < 1.0f) {
      StopCoroutine(nameof(BlowDetection));
      progressCircle.fillAmount = 0;
      _blowTransitionFlag = false;
    }
  }

  IEnumerator BlowDetection() {
    yield return new WaitForSeconds(1.0f);

    if(!_blowTransitionFlag)
      yield break;
    
    progressCircle.fillAmount = 1.0f;
    yield return ReplayTransition();
  }

  IEnumerator ReplayTransition() {
    StopCoroutine(nameof(StartupAnimation));

    iTween.MoveBy(progressCircle.gameObject, iTween.Hash("y", -300f,
                                   "time", 2.0f,
                                   "delay", 0));
    
    iTween.MoveBy(tapToReplayLabel, iTween.Hash("y", -300f,
                                   "time", 2.0f,
                                   "delay", 0.2f));
    
    yield return new WaitForSeconds(0.2f);

    Color camColor = Camera.main.backgroundColor;
    
    for (float i = 0; i <= 1; i += 0.05f) {
      var f = Mathf.Clamp01(i);
      var f_inv = (1 - f);
      fadeOverlay.color = new Color(0, 0, 0, f);
      // Camera.main.backgroundColor = new Color(camColor.r * f_inv, camColor.g * f_inv, camColor.b * f_inv, 1.0f);

      yield return new WaitForSeconds(0.01f);
    }

    yield return new WaitForSeconds(1.0f);
    
    // シーン遷移する
    yield return SceneManager.LoadSceneAsync("Scenes/Start");
  }
  
  IEnumerator StartupAnimation() {
    SlideFromLeft(resultTitle);
    SlideFromLeft(scoreLabel, 0.3f);
    SlideFromLeft(rankLabel, 0.5f);
    
    yield return new WaitForSeconds(1.0f);
    
    for (int i = 0; i <= _score; i++) {
      // いい感じに増えてる演出がしたい
      if (i < (_score >> 1))
        i += _score >> 4 + 1;
      else if (i < (_score - 60))
        i += _score >> 5 + 1;
      
      if (_score < i) {
        i = _score;
      }
      
      scoreField.text = i.ToString("D6");
      yield return new WaitForSeconds(0.01f);
    }
    
    yield return new WaitForSeconds(0.5f);
    rankField.text = _rank;
    yield return new WaitForSeconds(0.5f);

    if (_newRecord) {
      resultNewRecordLabel.SetActive(true);
      yield return new WaitForSeconds(0.5f);
    }
    
    tapToReplayLabel.SetActive(true);
    SlideFromBottom(tapToReplayLabel);
    yield return new WaitForSeconds(1.0f);

    _blowEnabled = true;
  }

  void SlideFromLeft(GameObject o, float delay = 0) {
    iTween.MoveFrom(o, iTween.Hash("x", -1000f,
                                   "time", 1.0f,
                                   "delay", delay));
  }
  
  void SlideFromBottom(GameObject o, float delay = 0) {
    iTween.MoveFrom(o, iTween.Hash("y", -1000f,
                                   "time", 1.0f,
                                   "delay", delay));
  }
}
