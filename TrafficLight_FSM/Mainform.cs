using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using ToolFunctions_ByLuke;
using TrafficLight_FSM.Scopes;

namespace TrafficLight_FSM
{
    delegate void SetTextCallback(Control ctr, string text);

    public partial class Mainform : Form, ITrafficLightUIPack, ITrafficLightUIController
    {
        // readonly修飾，確保不可重新賦值
        private readonly ITrafficLight pack;

        public Mainform(ITrafficLight pack)
        {
            InitializeComponent();
            this.pack = pack ?? throw new ArgumentNullException(nameof(pack));

            InitializeTrafficLightTypeComboBox();

            // 綁定按鈕點擊事件，用 Lambda 表達式
            btnStart.Click += (s, e) => pack.Start();
            btnPause.Click += (s, e) => pack.Pause();
            btnStop.Click += (s, e) => pack.Stop();

            btnSettingDuration.Click += (s, e) =>
            {
                if (int.TryParse(tbRedLigtDuration.Text, out int red) &&
                    int.TryParse(tbGreenLigtDuration.Text, out int green) &&
                    int.TryParse(tbYellowLigtDuration.Text, out int yellow))
                {
                    pack.SetDurations(red, green, yellow);
                }
                else
                {
                    MessageBox.Show("請輸入有效的數字！", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }

        #region TrafficLightTypeComboBox 相關函式
        private void InitializeTrafficLightTypeComboBox()
        {
            cmbTrafficLightType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrafficLightType.Items.Add(ETrafficLightType.SwitchCase.ToString());
            cmbTrafficLightType.Items.Add(ETrafficLightType.StatePattern.ToString());
            cmbTrafficLightType.SelectedIndex = (int)Scope.eTrafficLightType;
            cmbTrafficLightType.SelectedIndexChanged += CmbTrafficLightType_SelectedIndexChanged;

            Controls.Add(cmbTrafficLightType);
        }

        private void CmbTrafficLightType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbTrafficLightType.SelectedIndex == -1) return;

            // 更新 Scope 的 eTrafficLightType
            Scope.SetTrafficLightType((ETrafficLightType)cmbTrafficLightType.SelectedIndex);
        }
        #endregion

        #region 實作 ITrafficLightUIPack 介面
        public PictureBox RedLight => pbRed;
        public PictureBox YellowLight => pbYellow;
        public PictureBox GreenLight => pbGreen;
        public Button Start => btnStart;
        public Button Stop => btnStop;
        public Button Pause => btnPause;
        #endregion

        #region 實作 ITrafficLightUIController 介面
        private void UpdateTrafficLight(Color red, Color yellow, Color green)
        {
            pbRed.BackColor = red;
            pbYellow.BackColor = yellow;
            pbGreen.BackColor = green;
        }

        public void ShowRedLight() => UpdateTrafficLight(Color.Red, Color.Gray, Color.Gray);
        public void ShowYellowLight() => UpdateTrafficLight(Color.Gray, Color.Yellow, Color.Gray);
        public void ShowGreenLight() => UpdateTrafficLight(Color.Gray, Color.Gray, Color.Green);

        public void EnableStartButton(bool enable)
        {
            btnStart.Enabled = enable;
        }

        public void EnablePauseButton(bool enable)
        {
            btnPause.Enabled = enable;
        }

        public void EnableStopButton(bool enable)
        {
            btnStop.Enabled = enable;
        }

        public void ShowTimerState(string timeState)
        {
            ToolFunctions.AsyncSetText(lbTimeNow, timeState);
        }
    }

    #endregion
}
