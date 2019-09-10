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
  
  [SerializeField] private Text scoreField;
  [SerializeField] private Text rankField;

  [SerializeField] private Image fadeOverlay;

  private static int    _score     = 0;
  private static string _rank      = "F";
  private static bool   _newRecord = false;

  private bool _replayTransitionFlag = false;
  
  public static void InvokeResultScreen(int score, string rank, bool isNewRecord) {
    _score = score;
    _rank = rank;
    _newRecord = isNewRecord;
    
    SceneManager.LoadScene("Scenes/Result");
  }
  
  void Start() {
    resultNewRecordLabel.SetActive(false);
    tapToReplayLabel.SetActive(false);
  }

  void Update() {
    // 最初の画面の表示を行う
    if (!_initialAnimation) {
      _initialAnimation = true;
      StartCoroutine(StartupAnimation());
    };
    
    // ボタンが押された・タップされた場合にシーン遷移する。
    if (Input.GetMouseButtonDown(0) && !_replayTransitionFlag) {
      StartCoroutine(ReplayTransition());
    }
      
    for (var i = 0; i < Input.touchCount; i++) {
      if (_replayTransitionFlag)
        break;
      
      StartCoroutine(nameof(ReplayTransition));
    }
    
    // TODO: VR時にシーン遷移を検知したい
  }

  IEnumerator ReplayTransition() {
    iTween.MoveBy(tapToReplayLabel, iTween.Hash("y", -150f,
                                   "time", 1.0f,
                                   "delay", 0));
    yield return new WaitForSeconds(0.2f);
    
    for (float i = 0; i <= 1; i += 0.05f) {
      fadeOverlay.color = new Color(0, 0, 0, Mathf.Clamp01(i));
      yield return new WaitForSeconds(0.01f);
    }
    
    // TODO: シーン遷移する
    SceneManager.LoadScene("Scenes/Start");
  }
  
  IEnumerator StartupAnimation() {
    SlideFromLeft(resultTitle);
    SlideFromLeft(scoreLabel, 0.3f);
    SlideFromLeft(rankLabel, 0.5f);
    
    yield return new WaitForSeconds(1.0f);
    
    for (int i = 0; i <= _score; i++) {
      // いい感じに増えてる演出がしたい
      if (i < (_score >> 1))
        i += 114;
      else if (i < (_score - 60))
        i += 66;
      
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
