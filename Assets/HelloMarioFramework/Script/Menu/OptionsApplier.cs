/*
 *  Copyright (c) 2024 Hello Fangaming
 *
 *  Use of this source code is governed by an MIT-style
 *  license that can be found in the LICENSE file or at
 *  https://opensource.org/licenses/MIT.
 *  
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace HelloMarioFramework
{
    public class OptionsApplier : MonoBehaviour
    {
        [SerializeField]
        public AudioSource musicPlayer;

        void Start()
        {
            if (OptionsSave.save == null) OptionsSave.Load();

            ChangeSettings();
        }

        public void ChangeSettings()
        {
            if (musicPlayer != null) musicPlayer.volume = ((float)OptionsSave.save.musicVolume) / 20;

            if (OptionsSave.save.frameRate == 0)
            {
                Application.targetFrameRate = -1;
                QualitySettings.vSyncCount = 1;
            }
            else
            {
                Application.targetFrameRate = OptionsSave.save.frameRate;
                QualitySettings.vSyncCount = 0;
            }

          

            if (FreeLookHelper.singleton != null)
                FreeLookHelper.singleton.LoadSettings();
        }

        public static void ChangeResolution(int resolution)
        {
            float ratio = (float)Display.main.systemWidth / (float)Display.main.systemHeight;
            if (resolution == -1) resolution = Display.main.systemHeight;
            Screen.SetResolution((int)(resolution * ratio), resolution, Screen.fullScreen);
        }
    }
}