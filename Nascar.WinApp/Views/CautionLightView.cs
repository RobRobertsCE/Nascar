using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nascar.WinApp.Views
{
    public enum CautionLightState
    {
        Off,
        Green,
        Yellow,
        Red
    }

    public partial class CautionLightView : UserControl
    {
        int blinkCount = 0;

        private CautionLightState state = CautionLightState.Off;
        public CautionLightState LightState
        {
            get
            {
                return state;
            }
            set
            {
                if (state == value) return;
                state = value;
                SetLightState(state);
            }
        }

        public CautionLightView()
        {
            InitializeComponent();

            SetLightState(CautionLightState.Off);
        }

        public void SetFlagState(FlagState state)
        {
            switch (state)
            {
                case FlagState.Green:
                    {
                        LightState = CautionLightState.Green;
                        break;
                    }
                case FlagState.Yellow:
                    {
                        LightState = CautionLightState.Yellow;
                        break;
                    }
                case FlagState.Red:
                    {
                        LightState = CautionLightState.Red;
                        break;
                    }
                default:
                    {
                        LightState = CautionLightState.Off;
                        break;
                    }
            }
        }

        void SetLightState(CautionLightState newState)
        {
            this.state = newState;

            this.picLights.Image = Properties.Resources.CautionLightsOff;

            if (newState == CautionLightState.Yellow)
            {
                blinkCount = 0;
                blinkTimer.Enabled = true;
                this.picLights.Image = Properties.Resources.CautionLightsOff; 
            }
            else
            {
                blinkTimer.Enabled = false;
                if (newState == CautionLightState.Red)
                {
                    this.picLights.Image = Properties.Resources.CautionLightsRed;

                }
                else if (newState == CautionLightState.Green)
                {
                    this.picLights.Image = Properties.Resources.CautionLightsGreen;
                }
            }
        }

        private void blinkTimer_Tick(object sender, EventArgs e)
        {
            if (LightState == CautionLightState.Yellow)
            {
                Image lightImage = Properties.Resources.CautionLightsYellow;

                int lightSequenceCount = 8;

                if ((blinkCount % lightSequenceCount) == 0)
                {
                    lightImage = Properties.Resources.CautionLightsYellowLeft;
                }
                else if ((blinkCount % lightSequenceCount) == lightSequenceCount-1)
                {
                    lightImage = Properties.Resources.CautionLightsYellowRight;
                }
                else if ((blinkCount % lightSequenceCount) == lightSequenceCount - 2)
                {
                    lightImage = Properties.Resources.CautionLightsYellowLeft;
                }
                else if ((blinkCount % lightSequenceCount) == lightSequenceCount - 3)
                {
                    lightImage = Properties.Resources.CautionLightsYellowRight;
                }
                else if ((blinkCount % lightSequenceCount) == lightSequenceCount - 4)
                {
                    lightImage = Properties.Resources.CautionLightsOff;
                }
                else if ((blinkCount % lightSequenceCount) == lightSequenceCount - 5)
                {
                    lightImage = Properties.Resources.CautionLightsYellow;
                }
                else if ((blinkCount % lightSequenceCount) == lightSequenceCount - 6)
                {
                    lightImage = Properties.Resources.CautionLightsOff;
                }
                else if ((blinkCount % lightSequenceCount) == lightSequenceCount - 7)
                {
                    lightImage = Properties.Resources.CautionLightsYellow;
                }

                this.picLights.Image = lightImage;

                blinkCount++;
            }
            else
            {
                blinkCount = 0;
                blinkTimer.Enabled = false;
            }


        }
    }
}
