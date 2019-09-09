/// <summary>
/// 音に対して反応するやつ。
/// </summary>

public interface ISoundDetector {
  /// <summary>
  /// 音の検出をオンにする。
  /// </summary>
  void Start();
  
  /// <summary>
  /// 音の検出をやめる。
  /// </summary>
  void Stop();

  /// <summary>
  /// 音イベントのハンドラを指定する。
  /// </summary>
  /// <param name="handler">ハンドラ</param>
  void SetHandler(ISoundDetectionHandler handler);
}
