// TODO: 時間があったら実装してみたい

using System;
using static MicrophoneSoundDetector;

public class AdaptiveDetectionStrategy : DetectorStrategy {
	private readonly int _fftSize;

	// フィルタを生成する必要があるのでFFT配列のサイズを知らないといけない
	public AdaptiveDetectionStrategy(int fftSize) {
		_fftSize = fftSize;
	}

	override public VoiceInputState Detect(float[] fft, int samplingRate) {
		throw new NotImplementedException();
	}
}
