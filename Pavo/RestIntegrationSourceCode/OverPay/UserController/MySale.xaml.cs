using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverPay.Model.Sale;
using OverPay.Services.Sale;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MySale.xaml
    /// </summary>
    public partial class MySale : UserControl
    {
        private SaleService saleService;
        public MySale()
        {
            InitializeComponent();
            this.Loaded += MySale_Loaded;
            this.saleService = new SaleService();
        }

        private void MySale_Loaded(object sender, RoutedEventArgs e)
        {
            this.mySaleGrid.ItemsSource = IntegrationOperations.completedSales;
        }

        private async void Cancel_Sale(object sender, RoutedEventArgs e)
        {
            string result = await this.saleService.CancelSale(this.mySaleGrid.CurrentItem as IntegrationSale);
            var completeSale = (JObject)JsonConvert.DeserializeObject(result);
            bool hasError = completeSale["HasError"].Value<bool>();

            if (!hasError)
            {

            }
            else
            {
                MessageBox.Show(result);
            }
        }
    }
}
