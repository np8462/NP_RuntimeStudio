using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NP.Core.Models;
using NP.Storage.Services;

namespace NP.UI.Controls
{
    public partial class AiSettingsControl : UserControl
    {
        private AiProviderSettings _settings;
        private SettingsService _settingsService;


        public AiSettingsControl()
        {
            try
            {
                InitializeComponent();
                _settingsService = new SettingsService();
                var settings = _settingsService.Load();
                LoadSettings(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }


        public event EventHandler SettingsSaved;
        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings = GetSettings();

            _settingsService.Save(_settings);

            if (SettingsSaved != null)
            {
                SettingsSaved(
                    this,
                    EventArgs.Empty);
            }

            if (Parent != null)
                Parent.Visible = !Parent.Visible;
        }

        public event EventHandler CancelRequested;
        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            if (CancelRequested != null)
            {
                CancelRequested(
                    this,
                    EventArgs.Empty);
            }
            if (Parent != null)
                Parent.Visible = !Parent.Visible;
        }

        public void LoadSettings(
    AiProviderSettings settings)
        {
            _settings = settings;

            if (_settings == null)
            {
                _settings =
                    new AiProviderSettings();
            }

            txtUrl.Text =
                _settings.Url;

            txtApiKey.Text =
                _settings.ApiKey;

            txtModel.Text =
                _settings.Model;

            numTimeout.Value =
                _settings.TimeoutSeconds > 0
                ? _settings.TimeoutSeconds
                : 300;
        }

        public AiProviderSettings GetSettings()
        {
            return new AiProviderSettings
            {
                Url =
                    txtUrl.Text.Trim(),

                ApiKey =
                    txtApiKey.Text.Trim(),

                Model =
                    txtModel.Text.Trim(),

                TimeoutSeconds =
                    (int)numTimeout.Value
            };
        }

        private void txtApiKey_Click(object sender, EventArgs e)
        {
            if (txtApiKey.PasswordChar == '*')
                txtApiKey.PasswordChar = '\0';
            else
                txtApiKey.PasswordChar = '*';
        }

        private void lblModel_VisibleChanged(object sender, EventArgs e)
        {

        }
    
    }
}
