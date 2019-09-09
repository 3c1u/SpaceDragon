using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneSoundDetector : MonoBehaviour {
  [SerializeField] private AudioSource audioSource;
  private Microphone _microphone;

  private const int FFT_SIZE = 1024;
  private float[] _fftNoiseReductionMask = new float[FFT_SIZE];
  private float[] _fftBlowingLowpassFilter = new float[FFT_SIZE];
  private float[] _fftTonalBandpassFilter = new float[FFT_SIZE];
  
  public enum VoiceInputState {
    /// <summary>
    /// 音程、風のいずれも検知できない状態。
    /// </summary>
    Off = 0,
    /// <summary>
    /// 音程。
    /// </summary>
    Tonal,
    /// <summary>
    /// 風。
    /// </summary>
    Blow,
  }

  void Start() {
    // マイクの初期化処理とかをやる
    // let listener = MicrophoneListener.Listen().await?;
    
    // フィルタの生成
    GenerateFilters();
  }
  
  void Update() {
    float freq;
    var state = Process(audioSource, out freq);
  }

  /// <summary>
  /// 音声検出用のフィルターを初期化。
  /// </summary>
  void GenerateFilters() {
    
  }

  /// <summary>
  /// オーディオソースの入力に対し、音声を判別して更新されたステートを返す。
  /// </summary>
  /// <param name="source">オーディオソース</param>
  /// <param name="frequency">周波数の出力（検出された場合）</param>
  /// <returns></returns>
  VoiceInputState Process(AudioSource source, out float frequency) {
    // FFTの結果を取り出す。
    var fft_res = new float[FFT_SIZE];
    source.GetSpectrumData(fft_res, 0, FFTWindow.Blackman);

    // 検出できなかったときの返り値
    frequency = 0f;
    return VoiceInputState.Off;
  }
}
