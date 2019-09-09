/// <summary>
/// 音に対して反応するやつ。
/// </summary>

public interface ISoundDetectionHandler {
  /// <summary>
  /// 息の吹きかけに対して反応する。
  /// </summary>
  /// <param name="intensity">吹きかけの強さ</param>
  void HandleBlow(float intensity);

  /// <summary>
  /// 音程に対して反応する。
  /// </summary>
  /// <param name="intensity">音の大きさ</param>
  /// <param name="frequency">音の周波数</param>
  void HandleTonal(float intensity, float frequency);
}
