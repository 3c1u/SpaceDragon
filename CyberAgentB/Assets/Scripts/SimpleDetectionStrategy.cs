using static MicrophoneSoundDetector;

public class SimpleDetectionStrategy : DetectorStrategy {
	override public VoiceInputState Detect(float[] fft, int samplingRate) {
		// マジックナンバー類。ウマくいかなければこの辺を弄るといいかも。
		const float lowpass1 = 147.0f;
		const float lowpass2 = 2000.0f;
		const float lowThreshold = 0.0267f;
		const float highThreshold = 0.064f;


		float upperSum = 0f;
		float lowerSum = 0f;

		for (int i = 0; i < fft.Length; i++) {
			float targetFreq = ((float) i) / fft.Length * samplingRate;

			//	ローパス処理
			if (targetFreq > lowpass2)
				break;

			if (targetFreq < lowpass1) {
				lowerSum += fft[i];
			} else {
				upperSum += fft[i];
			}
		}

		bool lowActivated = lowThreshold <= lowerSum;
		bool highActivated = highThreshold <= upperSum;

		// 入力のからの結果に基づいて場合分け
		if (lowActivated) // (lowActivated && !highActivated) || (lowActivated && highActivated)
			return VoiceInputState.Blow;
		else if (highActivated) // !lowActivated
			return VoiceInputState.Tonal;
		else
			return VoiceInputState.Off;
	}
}
