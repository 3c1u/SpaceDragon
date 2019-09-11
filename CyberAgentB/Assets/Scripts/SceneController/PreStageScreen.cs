using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreStageScreen : MonoBehaviour
{
    enum PreStageState {
        NotDetected = 0,
        BlowWaiting,
        FadeIn,
        FadeOut,
        End,
    }

    private PreStageState _state = PreStageState.FadeIn;
    private float         _blowingTime = 0f;
    private float         _planeOpacity = 0f;

    [SerializeField] private Image progressCircle;
    [SerializeField] private Text  progressField;
    [SerializeField] private Text  titleLabel;
    [SerializeField] private Image fadeOverlay;

    [SerializeField] private float fadeCoefficient = 1.0f;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (_state == PreStageState.FadeIn) {
            _planeOpacity += Time.deltaTime * fadeCoefficient;
            if (_planeOpacity >= 1) {
                _state = PreStageState.NotDetected;
                _planeOpacity = 1;
            }

            fadeOverlay.color = new Color(0, 0, 0, 1 - _planeOpacity);

            return;
        } else if (_state == PreStageState.FadeOut) {
            _planeOpacity -= Time.deltaTime * fadeCoefficient;
            if (_planeOpacity <= 0) {
                SceneManager.LoadScene("Scenes/STAGE");
            }

            fadeOverlay.color = new Color(0, 0, 0, 1 - _planeOpacity);

            return;
        }

        if (_state == PreStageState.End)
            return;
        
        if (GameController.Instance.Player.Breath.isActive) {
            if (_state != PreStageState.BlowWaiting)
                progressField.text = "Good!";
            
            _state = PreStageState.BlowWaiting;
            _blowingTime += Time.deltaTime;
        } else {
            if (_state != PreStageState.NotDetected) {
                if (_blowingTime < 0.1f)
                    progressField.text = "Blow To Start";
                else
                    progressField.text = "Try again!";
                
                _state = PreStageState.NotDetected;
            }
            _blowingTime = 0f;
        }

        if (_blowingTime >= 1.0f) {
            _blowingTime = 1.0f;
            _state = PreStageState.End;
            
            progressCircle.gameObject.SetActive(false);
            progressField.text = "Game Start!";

            StartCoroutine(MoveSceneTransition());
        }

        progressCircle.fillAmount = Mathf.Clamp01(_blowingTime);
    }

    IEnumerator MoveSceneTransition() {
        yield return new WaitForSeconds(0.5f);

        iTween.MoveBy(titleLabel.gameObject, new Vector3(1500, 0, 0), 1.0f);
        yield return new WaitForSeconds(0.1f);
        iTween.MoveBy(progressField.gameObject, new Vector3(1500, 0, 0), 1.0f);

        yield return new WaitForSeconds(0.5f);

        _state = PreStageState.FadeOut;
    }
}
