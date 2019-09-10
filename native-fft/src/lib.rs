#![allow(non_snake_case)]
use rustfft::num_complex::Complex;
use rustfft::num_traits::Zero;
use rustfft::{FFTplanner, FFT};
use std::f32;
use std::sync::Arc;

pub trait Window {
    fn window(x: f32) -> f32;
}

pub struct Rectangular;
impl Window for Rectangular {
    fn window(x: f32) -> f32 {
        if 0_f32 <= x && x <= 1_f32 {
            1_f32
        } else {
            0_f32
        }
    }
}

pub struct Blackman;
impl Window for Blackman {
    fn window(x: f32) -> f32 {
        if 0_f32 <= x && x <= 1_f32 {
            0.42 - 0.50 * f32::cos(2.0 * f32::consts::PI * x)
                + -0.08 * f32::cos(4.0 * f32::consts::PI * x)
        } else {
            0_f32
        }
    }
}

pub struct Hamming;
impl Window for Hamming {
    fn window(x: f32) -> f32 {
        if 0_f32 <= x && x <= 1_f32 {
            0.54 - 0.46 * f32::cos(2.0 * f32::consts::PI * x)
        } else {
            0_f32
        }
    }
}

pub struct FFTWorker<W = Hamming>
where
    W: Window,
{
    input_buffer: Vec<Complex<f32>>,
    output_buffer: Vec<Complex<f32>>,
    size_coef: f32,
    size: usize,
    fft: Arc<dyn FFT<f32>>,
    _phantom: std::marker::PhantomData<W>,
}

impl<W> FFTWorker<W>
where
    W: Window,
{
    pub fn new(size: usize) -> Self {
        let mut planner = FFTplanner::new(false);
        let fft = planner.plan_fft(size);

        Self {
            input_buffer: vec![Complex::zero(); size],
            output_buffer: vec![Complex::zero(); size],
            fft,
            size_coef: 1.0 / (size as f32),
            size,
            _phantom: std::marker::PhantomData,
        }
    }

    pub fn process(&mut self, input: &[f32], output: &mut [f32]) -> Option<()> {
        // バッファのサイズ確認
        if input.len() != self.size || output.len() != self.size {
            return None;
        }

        // 入力バッファに値を突っ込む
        for (i, v) in input.into_iter().enumerate() {
            // 窓関数を適用していい感じに
            self.input_buffer
                .push((v * W::window((i as f32) * self.size_coef)).into());
        }
        // FFT実行
        self.fft
            .process(&mut self.input_buffer, &mut self.output_buffer);

        // 結果をいい感じに書き込む
        for (i, v) in (&self.output_buffer).into_iter().enumerate() {
            // ほげほげ〜
            let v = v.norm();
            output[i] = v;
        }

        // やったねたえちゃん！
        Some(())
    }
}
