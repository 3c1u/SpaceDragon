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
        End,
    }

    private PreStageState _state = PreStageState.NotDetected;
    private float         _blowingTime = 0f;

    [SerializeField] private Image progressCircle;
    [SerializeField] private Text  progressField;
    [SerializeField] private Text  titleLabel;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (_state == PreStageState.End)
            return;
        
        if (GameController.Instance.Player.Breath.isActive) {
            _state = PreStageState.BlowWaiting;
            _blowingTime += Time.deltaTime;

            progressField.text = (3 - Mathf.FloorToInt(_blowingTime)) + "";
        } else {
            _state = PreStageState.NotDetected;
            _blowingTime = 0f;

            progressField.text = "Waiting...";
        }

        if (_blowingTime >= 3.0f) {
            _blowingTime = 3.0f;
            _state = PreStageState.End;
            
            progressCircle.gameObject.SetActive(false);
            progressField.text = "Game Start!";

            StartCoroutine(MoveSceneTransition());
        }

        progressCircle.fillAmount = Mathf.Clamp01(_blowingTime * 0.333f);
    }

    IEnumerator MoveSceneTransition() {
        iTween.MoveBy(titleLabel.gameObject, new Vector3(1500, 0, 0), 1.0f);
        yield return new WaitForSeconds(0.1f);
        iTween.MoveBy(progressField.gameObject, new Vector3(1500, 0, 0), 1.0f);

        yield return new WaitForSeconds(0.5f);

        yield return SceneManager.LoadSceneAsync("Scenes/STAGE");
    }
}
