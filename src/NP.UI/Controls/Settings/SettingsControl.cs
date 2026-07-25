using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP.UI.Controls.Settings
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            AiSettingsControl aiSettingControl = new AiSettingsControl();
            aiSettingControl.Dock = DockStyle.Fill;
            tabAI.Controls.Add(aiSettingControl);

            RuntimeSettingsControl runtimeSettingsControl = new RuntimeSettingsControl();
            runtimeSettingsControl.Dock = DockStyle.Fill;
            tabRuntime.Controls.Add(runtimeSettingsControl);

            ThemeSettingsControl themeSettingsControl = new ThemeSettingsControl();
            themeSettingsControl.Dock = DockStyle.Fill;
            tabTheme.Controls.Add(themeSettingsControl);

            ChromeSettingsControl chromeSettingsControl = new ChromeSettingsControl();
            chromeSettingsControl.Dock = DockStyle.Fill;
            tabChrome.Controls.Add(chromeSettingsControl);

            VsSettingsControl vsSettingsControl = new VsSettingsControl();
            vsSettingsControl.Dock = DockStyle.Fill;
            tabVS2012.Controls.Add(vsSettingsControl);

            JsonViewerSettingsControl jsonViewerSettingsControl = new JsonViewerSettingsControl();
            jsonViewerSettingsControl.Dock = DockStyle.Fill;
            tabJsonViewer.Controls.Add(jsonViewerSettingsControl);

            LoggerSettingsControl loggerSettingsControl = new LoggerSettingsControl();
            loggerSettingsControl.Dock = DockStyle.Fill;
            tabLogger.Controls.Add(loggerSettingsControl);
        }
    }
}
