using OverPay.Windows.UserConfSettings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OverPay.UserController
{
    /// <summary>
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : UserControl
    {
        public UserSettings()
        {
            InitializeComponent();
            this.IPTxt.Text = ConfigurationSettings.AppSettings["IP"];
            this.PortTxt.Text = ConfigurationSettings.AppSettings["Port"];
            this.SerialNumberTxt.Text = ConfigurationSettings.AppSettings["SerialNumber"];
        }

        private void UpdatePairingConfiguration_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IP"].Value = this.IPTxt.Text;
            config.AppSettings.Settings["Port"].Value = this.PortTxt.Text;
            config.AppSettings.Settings["SerialNumber"].Value = this.SerialNumberTxt.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("Ayarlar Güncellendi");
        }
    }
}
