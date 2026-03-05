using OverPay.Model.Integration;
using OverPay.Model.Payment;
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

namespace OverPay.Windows.Payment
{
    /// <summary>
    /// Interaction logic for ExternalPayment.xaml
    /// </summary>
    public partial class ExternalPaymentEdit : Window
    {
        int selectedIndex = 0;
        DataGrid externalPaymentDataGrid;
        public ExternalPaymentEdit(DataGrid dataGrid, int? index, string editType)
        {
            InitializeComponent();
            this.AddPayment.Content = editType;
            externalPaymentDataGrid = dataGrid;

            if (editType != "Create")
            {
                var externalPayment = IntegrationOperations.externalPayments[index.Value];
                selectedIndex = index.Value;
                this.AmountTxt.Text = externalPayment.Amount.ToString();
                this.PaymentTypeCmb.SelectedIndex = externalPayment.Type;
                this.PaymentMediatorCmb.SelectedIndex = externalPayment.Mediator;
                this.PaymentProviderBrandCmb.SelectedIndex = externalPayment.Brand;
                this.CardNoTxt.Text = externalPayment.CardNo;
                this.AutherazitonTxt.Text = externalPayment.AuthorizationCode;
            } 
            foreach (var item in IntegrationOperations.paymentTypes)
            {
                this.PaymentTypeCmb.Items.Add(item);
            }
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            if (this.AddPayment.Content.ToString() == "Create")
            {
                IntegrationOperations.externalPayments.Add(new Model.Integration.ExternalPayment
                {
                    Type = (int)this.PaymentTypeCmb.SelectedValue,
                    Mediator = (int)this.PaymentMediatorCmb.SelectedValue,
                    Brand = (int)this.PaymentProviderBrandCmb.SelectedValue,
                    Amount = Decimal.Parse(this.AmountTxt.Text),
                    CardNo = this.CardNoTxt.Text,
                    AuthorizationCode = this.AutherazitonTxt.Text
                });
            } 
            else if (this.AddPayment.Content.ToString() == "Update")
            {
                IntegrationOperations.externalPayments[selectedIndex].Type = (int)this.PaymentTypeCmb.SelectedValue;
                IntegrationOperations.externalPayments[selectedIndex].Mediator = (int)this.PaymentMediatorCmb.SelectedValue;
                IntegrationOperations.externalPayments[selectedIndex].Brand = (int)this.PaymentProviderBrandCmb.SelectedValue;
                IntegrationOperations.externalPayments[selectedIndex].Amount = Decimal.Parse(this.AmountTxt.Text);
                IntegrationOperations.externalPayments[selectedIndex].CardNo = this.CardNoTxt.Text;
                IntegrationOperations.externalPayments[selectedIndex].AuthorizationCode = this.AutherazitonTxt.Text;

            } 
            else if (this.AddPayment.Content.ToString() == "Delete")
            {
                IntegrationOperations.externalPayments.RemoveAt(selectedIndex);
            }
            this.externalPaymentDataGrid.ItemsSource = IntegrationOperations.externalPayments;
            this.Close();
        }
        private void PaymentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.PaymentMediatorCmb.Items.Clear();
            var paymentType = IntegrationOperations.paymentTypes.First(pm => pm.Id == (int)this.PaymentTypeCmb.SelectedValue);
            foreach (var item in paymentType.PaymentMediators)
            {
                this.PaymentMediatorCmb.Items.Add(item);
            }
        }

        private void PaymentMediator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.PaymentProviderBrandCmb.Items.Clear();
            var paymentType = IntegrationOperations.paymentTypes.First(pm => pm.Id == (int)this.PaymentTypeCmb.SelectedValue);
            var paymentMediator = paymentType.PaymentMediators.First(pm => pm.Id == (int)this.PaymentMediatorCmb.SelectedValue);
            foreach (var item in paymentMediator.PaymentProviderBrands)
            {
                this.PaymentProviderBrandCmb.Items.Add(item);
            }
        }
    }
}
