using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] float m_gain = 1f; // 音量に掛ける倍率
    float m_volumeRate; // 音量(0-1)
    // Use this for initialization

    //[SerializeField] Text volumetext;

    bool ok = false;

    private AudioSource m_audioSource;

    /*[SerializeField]
    private Slider frequencyBoundarySlider;

    [SerializeField]
    private Slider upperThreshold;

    [SerializeField]
    private Slider lowerThreshold;

    [SerializeField]
    private Text statusField;*/

    public bool isBlow = false;

    void Start()
    {

        Application.RequestUserAuthorization(UserAuthorization.Microphone);

        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {

            AudioSource aud = GetComponent<AudioSource>();
            m_audioSource = aud;

            if ((aud != null) && (Microphone.devices.Length > 0)) // オーディオソースとマイクがある
            {
                Debug.Log("okがtrue");

                string devName = Microphone.devices[0]; // 複数見つかってもとりあえず0番目のマイクを使用
                int minFreq, maxFreq;
                Microphone.GetDeviceCaps(devName, out minFreq, out maxFreq); // 最大最小サンプリング数を得る
                aud.clip = Microphone.Start(devName, true, 1, 44100/*minFreq*/); // 音の大きさを取るだけなので最小サンプリングで十分
                aud.Play(); //マイクをオーディオソースとして実行(Play)開始
                ok = true;
                Debug.Log("変わった" + ok);
            }
            else
            {
                Debug.Log("マイク不備");
            }
        }
        else
        {
            //volumetext.text = "許可降りてない";
        }


    }

    // Update is called once per frame
    void Update()
    {
        /*var spectrum = new float[1024];

        m_audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);

        var upper = 0f;
        var lower = 0f;

        var frequencyBoundary = frequencyBoundarySlider.value;

        for (int i = 0; i < spectrum.Length; i++)
        {
            var targetFrequency = i * 22050.0 / spectrum.Length;

            if(targetFrequency>2000.0){
                break;
            }
            if (frequencyBoundary < targetFrequency)
            {
                upper += spectrum[i];
            }
            else
            {
                lower += spectrum[1];
            }
        }

        statusField.text = frequencyBoundary + " Hz, lower: " + lowerThreshold.value
                            + " (" + (lower > lowerThreshold.value) + "), higher: "
                            + upperThreshold.value + " (" + (upper > upperThreshold.value) + ")";*/

        if(ok){

            if (m_volumeRate < 30)
            {
                //volumetext.text = 0 + "";
            }
            else if(isBlow){

                //volumetext.text = 0 + "";

            }else{
                Debug.Log(m_volumeRate);
                //volumetext.text = m_volumeRate + "";
            }
        }

        GameController.Instance.Player.Breath.Power = m_volumeRate / 100.0f;
        GameController.Instance.Player.Voice.Power = m_volumeRate / 100.0f;


    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        float sum = 0f;
        for (int i = 0; i < data.Length; ++i)
        {
            sum += Mathf.Abs(data[i]); // データ（波形）の絶対値を足す
        }
        // データ数で割ったものに倍率をかけて音量とする
        m_volumeRate = Mathf.Clamp01(sum * m_gain / (float)data.Length) * 1000;
    } 

    /*[SerializeField] Text volumetext;

    private readonly int SampleNum = (2 << 9); // サンプリング数は2のN乗(N=5-12)
    [SerializeField, Range(0f, 1000f)] float m_gain = 200f; // 倍率
    AudioSource m_source;
    float[] currentValues;

    bool ok = false;

    // Use this for initialization
    void Start()
    {

        Application.RequestUserAuthorization(UserAuthorization.Microphone);

        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Debug.Log("ここまで");
            m_source = GetComponent<AudioSource>();
            currentValues = new float[SampleNum];
            if ((m_source != null) && (Microphone.devices.Length > 0)) // オーディオソースとマイクがある
            {
                Debug.Log("最初");
                ok = true;
                string devName = Microphone.devices[0]; // 複数見つかってもとりあえず0番目のマイクを使用
                int minFreq, maxFreq;
                Microphone.GetDeviceCaps(devName, out minFreq, out maxFreq); // 最大最小サンプリング数を得る
                int ms = minFreq / SampleNum; // サンプリング時間を適切に取る
                m_source.loop = true; // ループにする
                m_source.clip = Microphone.Start(devName, true, ms, minFreq); // clipをマイクに設定
                while (!(Microphone.GetPosition(devName) > 0)) { } // きちんと値をとるために待つ
                Microphone.GetPosition(null);
                m_source.Play();



                Debug.Log("okがtrue");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (ok)
        {
            m_source.GetSpectrumData(currentValues, 0, FFTWindow.Hamming);
            float sum = 0f;
            for (int i = 0; i < currentValues.Length; ++i)
            {
                sum += currentValues[i]; // データ（周波数帯ごとのパワー）を足す
            }
            // データ数で割ったものに倍率をかけて音量とする
            float volumeRate = Mathf.Clamp01(sum * m_gain / (float)currentValues.Length);
            volumetext.text = volumeRate * 100 + "";
            Debug.Log(volumeRate);}
        }*/

}
