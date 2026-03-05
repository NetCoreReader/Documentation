using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverPay.Command;
using OverPay.Global;
using OverPay.Model.Cart;
using OverPay.Model.Customer;
using OverPay.Model.Enum;
using OverPay.Model.Integration;
using OverPay.Model.Payment;
using OverPay.Model.Product;
using OverPay.Model.Sale;
using OverPay.Services.Customer;
using OverPay.Services.Merchant;
using OverPay.Services.Payment;
using OverPay.Services.Product;
using OverPay.Services.Sale;
using OverPay.Windows.Payment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SaleUC.xaml
    /// </summary>
    public partial class SaleUC : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<ExternalPayment> externalPayments;
        private ObservableCollection<ExternalPayment> ep;
        ICommand addCommand, minusCommand;
        private Customer Customer;
        private Product product;
        private List<CartItem> cartItems = new List<CartItem>();
        private Sale Sale;
        private SaleItem saleItem;
        private ProductService productService;
        private ProductPriceService productPriceService;
        private MerchantPaymentTypeService merchantPaymentTypeService;
        private PaymentService paymentService;
        private SaleService saleService;
        private SaleApplicationService saleApplicationService;
        private CustomerService customerService;
        private List<PaymentType> paymentTypes;
        private ExternalPayment selectedExternalPayment;
        private decimal SalePrice;
        decimal givingAmount; // ilk degeri verilmedi ama 0 olarak init ediliyor
        private Grid grid;
        private bool isDoteNoticed;
        private List<String> currencyCodes = new List<String> { "Select item","USD", "EUR", "GBP","CHF", "RUB" };
        private string ButtonContent;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ExternalPayment> ExternalPayments { get => externalPayments; set { externalPayments = value; onPropertyChanged("ExternalPayments"); } }

        public SaleUC(Grid grid)
        {
            InitializeComponent();
            this.Sale = new Sale();
            this.productService = new ProductService();
            this.paymentService = new PaymentService();
            this.paymentTypes = new();
            addCommand = new RelayCommand(onAdd,CanAdd);
            minusCommand = new RelayCommand(onMinus, CanMinus);
            this.productPriceService = new ProductPriceService();
            this.merchantPaymentTypeService = new MerchantPaymentTypeService();
            this.saleService = new SaleService();
            this.saleApplicationService = new SaleApplicationService();
            this.customerService = new CustomerService();
            SetVisibility(Visibility.Collapsed);
            this.Email.Visibility = Visibility.Collapsed;
            this.Phone.Visibility = Visibility.Collapsed;
            this.nihaiTuketici.IsChecked = true;
            AddItemBtn.Visibility = Visibility.Collapsed;
            this.ep = new ObservableCollection<ExternalPayment>()
            {
                new ExternalPayment(){ Amount = 3},
                new ExternalPayment() { AuthorizationCode = "123"}
            };
            setCurrencies();
            this.grid = grid;
            this.Loaded += CRUD_Loaded;
        }
        private async void CRUD_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            var paymentTypeList = await this.merchantPaymentTypeService.ListMerchantPaymentType();
            foreach (var item in paymentTypeList.Data)
            {
                this.paymentTypes.Add(item.PaymentType);
            }*/

        }
        private async void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string query = (sender as TextBox).Text;
            if (query.Length > 2)
            {
                try
                {

                   bool found = false;
                    var data = await productService.SearchMerchantProduct(query, 4);
                    // Clear the list   
                    resultStack.Children.Clear();
                    // Add the result   
                    foreach (var obj in data)
                    {
                        if (obj.Name.ToLower().Contains(query.ToLower()))
                        {
                            addItem(obj);
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        resultStack.Children.Add(new TextBlock() { Text = "No results found." });
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void addItem(OverPay.Model.Product.Product product)
        {
            TextBlock block = new TextBlock();
            // Add the text   
            block.Text = product.Name;
            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;
            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                Parent.Text = (sender as TextBlock).Text;
                this.product = product;
                resultStack.Children.Clear();
                AddItemBtn.Visibility = Visibility.Visible;
            };
            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Gray;
            };
            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };
            // Add to the panel   
            resultStack.Children.Add(block);
        }
        private async void AddProductItemBtn(object sender, RoutedEventArgs e)
        {
            if(product != null)
            {
                /*
                if (this.Sale.Id == 0)
                {
                    var result = await this.saleService.Create(Sale);
                    var integSale = (JObject)JsonConvert.DeserializeObject(result);
                    bool hasError = integSale["HasError"].Value<bool>();

                    if (!hasError)
                    {
                        IntegrationOperations.paymentTypes = integSale["Data"]["PaymentTypes"].ToObject<List<PaymentType>>();
                        this.Sale.Id = integSale["Data"]["Id"].Value<int>();
                        this.Sale.SaleNumber = integSale["Data"]["SaleNumber"].Value<string>();
                        await addProduct();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                } 
                else if (this.Sale.Id > 0)
                {
                   await addProduct();
                }*/

                await addProduct();
            }    
        }

        private async Task addProduct()
        {
            if (cartItems?.Count == 0)
                await AddProduct();
            else
            {
                var index = cartItems.FindIndex(i => i.ProductId == product.Id);

                if (index < 0)
                    await AddProduct();
                else
                {
                    cartItems[index].Quantitiy++;
                    cartItems[index].TotalPrice += cartItems[index].Product.ProductPrice.Price; // product price include olmadigi icin problem cikartabilir.
                    cartItems[index].GrossPrice += cartItems[index].Product.ProductPrice.Price;
                    cartItems[index].QuantityLabel.Content = cartItems[index].Quantitiy;
                    cartItems[index].PriceLabel.Content =  $"{cartItems[index].TotalPrice.ToString("0.00")} TRY";
                    this.SalePrice += (int)cartItems[index].Product.ProductPrice.Price;
                    this.TotalPriceLabel.Content = "Toplam Fiyat: " + this.SalePrice + " TRY";
                }
            }
        }
        private void onAdd(object value)
        {
            CartItem cartItem = (CartItem)value;
            cartItem.Quantitiy++;
            cartItem.TotalPrice +=(int)cartItem.Product.ProductPrice.Price; // product price include olmadigi icin problem cikartabilir.
            cartItem.QuantityLabel.Content = cartItem.Quantitiy;
            cartItem.PriceLabel.Content = cartItem.TotalPrice + " TRY";
            this.SalePrice += (int)cartItem.Product.ProductPrice.Price;
            this.TotalPriceLabel.Content = "Toplam Fiyat: " + this.SalePrice + " TRY";

        }
        private bool CanAdd(object value)
        {
            return true;
        }
        private void onMinus(object value)
        {
            CartItem cartItem = (CartItem)value;
            if (cartItem.Quantitiy > 0)
            {
                cartItem.Quantitiy--;
                cartItem.TotalPrice -= (int)cartItem.Product.ProductPrice.Price; // product price include olmadigi icin problem cikartabilir.
                cartItem.QuantityLabel.Content = cartItem.Quantitiy;
                cartItem.PriceLabel.Content = cartItem.TotalPrice + " TRY";
                this.SalePrice -= (int)cartItem.Product.ProductPrice.Price;
                this.TotalPriceLabel.Content = "Toplam Fiyat: " + this.SalePrice + " TRY";
            }
            if (cartItem.Quantitiy == 0)
            {
                var index = cartItems.FindIndex(i => i.ProductId == cartItem.ProductId);
                this.productList.Items.Remove(cartItem);
                this.Btn.Items.Remove(cartItem.addbtn);
                this.Btn.Items.Remove(cartItem.minusbtn);
                this.Btn.Items.Remove(cartItem.QuantityLabel);
                cartItems.RemoveAt(index);
                this.PriceList.Items.Remove(cartItem.PriceLabel);
                if(cartItems.Count == 0)
                {
                    SetVisibility(Visibility.Collapsed);
                }
            }
        }
        private bool CanMinus(object value)
        {
            return true;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.customerName.Visibility = this.nihaiTuketici.IsChecked == true ? Visibility.Hidden : Visibility.Visible;
            this.Email.Visibility = this.SendEMailNotification.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            this.Phone.Visibility = this.SendPhoneNotification.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private async void CompleteSale(object sender, RoutedEventArgs e)
        {
            try
            {
                if(this.cartItems == null || this.cartItems.Count == 0)
                {
                    MessageBox.Show("Sepete ürün ekleliyiniz");
                    return;
                }
                double exchangeRate;
                double.TryParse(exchangeRateTxt.Text.Replace(',','.'), out exchangeRate);
                this.Sale.SendPhoneNotification = (bool)SendPhoneNotification.IsChecked;
                this.Sale.SendEMailNotification = (bool)SendEMailNotification.IsChecked;
                this.Sale.NotificationPhone = Phone.Text;
                this.Sale.NotificationEMail = Email.Text;
                this.Sale.CurrencyCode = this.currencyCmb.SelectedItem.ToString() != "Select item" ? this.currencyCmb.SelectedItem.ToString() : "TRY";
                this.Sale.ExchangeRate = exchangeRate;

                this.CompleteSaleBtn.IsEnabled = false;
                Payment payment = createPayment();
                payment = await this.paymentService.CreateSalePayment(payment);
                this.Sale.AddedPayments.Add(payment);
                this.initSaleItem();
                string result = await this.saleService.CompleteSale(this.Sale);
                var completeSale = (JObject)JsonConvert.DeserializeObject(result);
                bool hasError = completeSale["HasError"].Value<bool>();
                MessageBox.Show(result);

                if (!hasError)
                {
                    IntegrationOperations.completedSales.Add(new IntegrationSale { 
                        Id = completeSale["Data"]["Id"].Value<long>(),
                        SaleNumber = completeSale["Data"]["SaleNumber"].Value<string>(),
                        IsOffline = completeSale["Data"]["IsOffline"].Value<bool>(),
                        GrossPrice = completeSale["Data"]["GrossPrice"].Value<decimal>(),
                        TotalPrice = completeSale["Data"]["TotalPrice"].Value<decimal>(),

                    
                    });
                    OverPay.UserController.CompleteSaleUC completeSaleUC = new OverPay.UserController.CompleteSaleUC();
                    completeSaleUC.DataContext = this.Sale;
                    CallContentData.AddUserController(grid, completeSaleUC);
                }
                else
                {
                    this.CompleteSaleBtn.IsEnabled = true;// ?? bu kisimin analize ihtiyaci var
                    this.Sale = new Sale();
                }

            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.CompleteSaleBtn.IsEnabled = true;
                this.Sale = new Sale();

            }


        }

        private async Task AddProduct()
        {
            CartItem cartItem = await initCartItem();
            cartItems.Add(cartItem);
            this.productList.Items.Add(cartItem);
            this.Btn.Items.Add(cartItem.addbtn);
            this.Btn.Items.Add(cartItem.QuantityLabel);
            this.Btn.Items.Add(cartItem.minusbtn);
            this.PriceList.Items.Add(cartItem.PriceLabel);
            this.SalePrice += cartItem.TotalPrice;
            this.TotalPriceLabel.Content ="Toplam Fiyat: "+this.SalePrice + " TRY";
            SetVisibility(Visibility.Visible);
        }

        private Payment createPayment()
        {
            Payment Payment = new Payment();
            Payment.SaleId = this.Sale.Id;
            Payment.MerchantId = CurrentMerchantInformation.merchant.Id;
            //Payment.PaymentType = (PaymentType)PaymentTypeCmb.SelectedItem;
            Payment.DirectionType = "S";
            Payment.PaymentAmount = this.SalePrice;
            Payment.PaymentMediatorId = 1;
            Payment.PaymentTypeId = 1;
            return Payment;
        }

        private void CalculateChange(object sender, RoutedEventArgs e)
        {
            
            Decimal.TryParse((sender as TextBox).Text.Replace(',','.'),out givingAmount);
        }

        private void initSaleItem()
        {
            foreach (var item in cartItems)
            {
                this.saleItem = new SaleItem();
                saleItem.ItemQuantity = item.Quantitiy;
                saleItem.GrossPriceAmount = item.TotalPrice;
                saleItem.UnitPriceAmount = item.Product.ProductPrice.Price;
                saleItem.TotalPriceAmount = item.TotalPrice;
                saleItem.UnitName = item.Product.Unit.Name;
                saleItem.UBLCode = item.Product.Unit.UBLCode;
                saleItem.Name = item.Product.Name;
                saleItem.ProductId = item.ProductId;
                saleItem.TotalPriceAmount = item.TotalPrice;
                saleItem.Product = item.Product;
                saleItem.TaxGroup = item.Product.TaxGroup;
                saleItem.UnitId = item.Product.UnitId;
                saleItem.UnitName = item.Product.Unit.Name;
                saleItem.UnitPriceAmount = item.Product.ProductPrice.Price;
                saleItem.CreateDate = DateTime.Now;
                saleItem.InsertTime = DateTime.Now;
                this.Sale.AddedSaleItems.Add(saleItem);
            }
            this.Sale.TotalPrice = this.SalePrice;
        }

        private async Task<CartItem> initCartItem()
        {
            CartItem cartItem = new CartItem();
            cartItem.Product = product;
            cartItem.ProductId = product.Id;
            cartItem.Quantitiy = 1;
            cartItem.minusbtn.Style = (Style)FindResource("SaleMinusbtn");
            cartItem.addbtn.Style = (Style)FindResource("SaleAddbtn");
            cartItem.QuantityLabel.Content = cartItem.Quantitiy;
            var productPrice = await productPriceService.GetProductPrice(product.Id);
            cartItem.Product.ProductPrice = productPrice;
            cartItem.TotalPrice = Math.Round(productPrice.Price, 2);
            cartItem.GrossPrice = Math.Round(product.PriceAmount, 2);
            cartItem.addbtn.Command = addCommand;
            cartItem.addbtn.CommandParameter = cartItem;
            cartItem.minusbtn.Command = minusCommand;
            cartItem.minusbtn.CommandParameter = cartItem;
            cartItem.PriceLabel.Content = $"{cartItem.TotalPrice} TRY";

            return cartItem;
        }

        private async void CancelSaleBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Sale.SendPhoneNotification = (bool)SendPhoneNotification.IsChecked;
                this.Sale.SendEMailNotification = (bool)SendEMailNotification.IsChecked;
                this.Sale.NotificationPhone = Phone.Text;
                this.Sale.NotificationEMail = Email.Text;

                this.CancelSaleBtn.IsEnabled = false;
                this.initSaleItem();

                string result = await this.saleService.AbondedlSale(this.Sale);
                var cancelSale = (JObject)JsonConvert.DeserializeObject(result);
                bool hasError = cancelSale["HasError"].Value<bool>();
                MessageBox.Show(result);

                if (!hasError)
                {
                    OverPay.UserController.CancelSaleUC cancelSaleUC = new OverPay.UserController.CancelSaleUC();
                    cancelSaleUC.DataContext = this.Sale;
                    CallContentData.AddUserController(grid, cancelSaleUC);
                }
                else
                {
                    //MessageBox.Show("Basarisiz Satis");
                    this.Sale = new Sale();
                    this.CancelSaleBtn.IsEnabled = true;// ?? bu kisimin analize ihtiyaci var
                }
            } 
            catch(Exception ex)
            {
                this.Sale = new Sale();
                MessageBox.Show(ex.ToString());
                this.CancelSaleBtn.IsEnabled = true;
            }
        }

        private void customerName_GotFocus(object sender, RoutedEventArgs e)
        {
            customerName.Text = "";
        }

        private async void customerName_KeyUp(object sender, KeyEventArgs e)
        {
            string query = (sender as TextBox).Text;
            if (query.Length > 2)
            {
                bool found = false;
                var data = await customerService.SearchCustomer(query);
                // Clear the list   
                CustomerStack.Children.Clear();
                // Add the result   
                foreach (var obj in data)
                {
                    if (obj.InvoiceTitle.ToLower().Contains(query.ToLower()))
                    {
                        addCustomer(obj);
                        found = true;
                    }
                }
                if (!found)
                {
                    CustomerStack.Children.Add(new TextBlock() { Text = "No results found." });
                }
            }
        }

        private void addCustomer(Customer customer)
        {
            TextBlock block = new TextBlock();
            // Add the text   
            block.Text = customer.InvoiceTitle;
            // A little style...   
            block.Cursor = Cursors.Hand;
            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                customerName.Text = (sender as TextBlock).Text;
                this.Sale.Customer = customer;
                this.Sale.CustomerId = customer.Id;
                CustomerStack.Children.Clear();
            };
            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Gray;
            };
            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };
            // Add to the panel   
            CustomerStack.Children.Add(block);
        }

        private void GivingAmountControl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex rgx = new Regex("^[0-9]+([,]{0,1}[0-9]{1,2})?$");
            TextBox textBox = sender as TextBox;
            var input = textBox.Text + e.Text;
            if (e.Text.Equals(",") && !isDoteNoticed && !textBox.Text.Equals("")) // nokta girilmesi problem yaratiyordu
            {                                                                     // suan icin boyle bir cozum buldum.          
                isDoteNoticed = true;
            }
            if(!isDoteNoticed || textBox.Text.Contains(','))
            {
                e.Handled = !rgx.IsMatch(input);
            }

            
        }

        private void Parent_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Parent.Text = "";
        }

        private async void  ParingBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ParingBtn.IsEnabled = false;
                var result = await IntegrationOperations.Paring();
                MessageBox.Show(JsonConvert.SerializeObject(result));
                ParingBtn.IsEnabled = true;
            } 
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
                ParingBtn.IsEnabled = true;

            }
        }
        //private void AddExternalPaymentBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    ExternalPaymentEdit _exPayment = new ExternalPaymentEdit(this.externalPaymentsGrid, null, "Create");
        //    _exPayment.ShowDialog();
        //}

        private void SetVisibility(Visibility visibility)
        {
            Sepet.Visibility = visibility;
            Miktar.Visibility = visibility;
            Fiyat.Visibility = visibility;
            //PaymentComponent.Visibility = visibility;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var currentRowIndex = this.externalPaymentsGrid.Items.IndexOf(this.externalPaymentsGrid.CurrentItem);
        //    ExternalPaymentEdit _exPayment = new ExternalPaymentEdit(this.externalPaymentsGrid, currentRowIndex, "Update");
        //    _exPayment.ShowDialog();
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    var currentRowIndex = this.externalPaymentsGrid.Items.IndexOf(this.externalPaymentsGrid.CurrentItem);
        //    ExternalPaymentEdit _exPayment = new ExternalPaymentEdit(this.externalPaymentsGrid, currentRowIndex, "Delete");
        //    _exPayment.ShowDialog();
        //}

        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void setCurrencies()
        {
            foreach (var item in currencyCodes)
            {
                this.currencyCmb.Items.Add(item);
            }
        }
    }
}
