using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class BatteryMonitorForm : Form
    {
        [DllImport("PowrProf.dll")]
        public static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

        private Timer batteryCheckTimer;
        private Label batteryStatusLabel;
        private Label batteryLevelLabel;
        private ProgressBar batteryProgressBar;
        private Button closeButton;

        public BatteryMonitorForm()
        {
            InitializeComponent();
            InitializeBatteryMonitoring();
        }

        private void InitializeComponent()
        {
            this.Text = "Батарейны хяналт";
            this.Size = new System.Drawing.Size(400, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            batteryStatusLabel = new Label
            {
                Text = "Батарейны төлөв:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            batteryLevelLabel = new Label
            {
                Text = "0%",
                Location = new System.Drawing.Point(150, 20),
                AutoSize = true
            };

            batteryProgressBar = new ProgressBar
            {
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(350, 30),
                Maximum = 100
            };

            closeButton = new Button
            {
                Text = "Хаах",
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(100, 30)
            };
            closeButton.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { batteryStatusLabel, batteryLevelLabel, batteryProgressBar, closeButton });
        }

        private void InitializeBatteryMonitoring()
        {
            batteryCheckTimer = new Timer();
            batteryCheckTimer.Interval = 10000; // 10 секунд тутамд шалгах
            batteryCheckTimer.Tick += BatteryCheckTimer_Tick;
            batteryCheckTimer.Start();

            // Шууд анхны төлөвийг шалгах
            CheckBatteryStatus();
        }

        private void BatteryCheckTimer_Tick(object sender, EventArgs e)
        {
            CheckBatteryStatus();
        }

        private void CheckBatteryStatus()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("Select * from Win32_Battery"))
                {
                    foreach (ManagementObject battery in searcher.Get())
                    {
                        int batteryLevel = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
                        bool isCharging = Convert.ToBoolean(battery["BatteryStatus"] == 2);

                        UpdateBatteryUI(batteryLevel, isCharging);

                        if (batteryLevel <= 20 && !isCharging)
                        {
                            if (MessageBox.Show(
                                "Батарейны түвшин бага байна. Компьютер унтрах уу?",
                                "Батарейны анхааруулга",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                SetSuspendState(false, true, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBatteryUI(int batteryLevel, bool isCharging)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateBatteryUI(batteryLevel, isCharging)));
                return;
            }

            batteryLevelLabel.Text = $"{batteryLevel}%";
            batteryProgressBar.Value = batteryLevel;
            batteryStatusLabel.Text = $"Батарейны төлөв: {(isCharging ? "Цэнэглэж байна" : "Цэнэглэхгүй байна")}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            batteryCheckTimer.Stop();
            batteryCheckTimer.Dispose();
            base.OnFormClosing(e);
        }
    }
} 