| Hata Kodu | Hata İsmi                                  | Hata Açıklaması                                              |
| --------- | ------------------------------------------ | ------------------------------------------------------------ |
| 0         | none                                       | Unknown                                                      |
| 1         | saleNotFound                               | Satış id($*arg*) olan bir satış bulunmamaktadır              |
| 2         | saleNotBelongsToIntegration                | İptal edilmek istenen satış harici uygulamadan yapılmamış    |
| 3         | saleNotCancellable                         | Satış iptal edilebilir değil                                 |
| 4         | cancelSaleException                        | Bilinmeyen satış iptal hatası                                |
| 5         | saleNoCannotBeEmpty                        | Satış id($*arg*) ya da satış numarası($*arg2*) boş olamaz    |
| 6         | saleNotCompleted                           | Satış statüsü tamamlanmış değil                              |
| 7         | completedSaleException                     | Bilinmeyen tamamlanmış satış hatası                          |
| 8         | printDataEmpty                             | Yazdırılacak veri boş gönderildi                             |
| 9         | incorrectModel                             | Hatalı model. Gönderilen modeli kontrol ediniz.              |
| 10        | printError                                 | Yazdırma başarısız                                           |
| 11        | unsupportedMediaType                       | Yalnızca png ve jpeg formatları desteklenmektedir            |
| 12        | printerBusy                                | Yazıcı meşgul.                                               |
| 13        | printerNotConnected                        | Yazıcı bağlı değil.                                          |
| 14        | printerOutOfPaper                          | Yazıcı kağıdı bitti.                                         |
| 15        | printerTooHot                              | Yazıcı aşırı ısındı.                                         |
| 16        | printerFailed                              | Yazdırma hatası                                              |
| 17        | mediatorNotOfflineAllowed                  | $*arg* nolu ödeme aracısı çevrimdışı satışa izin vermemektedir. |
| 18        | mediatorNotFound                           | Ödeme aracısı bulunamadı                                     |
| 19        | abandoneSaleException                      | Satışı terket hatası                                         |
| 20        | deviceBusy                                 | Cihaz meşgul                                                 |
| 21        | invalidCurrencyCode                        | Geçersiz döviz kodu, "CurrencyCode": $*arg*                  |
| 22        | invalidExchangeRate                        | Geçersiz kur değeri, "ExchangeRate": $*arg*                  |
| 23        | invalidGrossPriceAmount                    | Satış bürüt fiyatı boş veya negatif değer olamaz             |
| 24        | invalidTotalPriceAmount                    | Satış toplam ücreti boş veya negatif değer olamaz            |
| 25        | invalidDiscountRate                        | İndirim oranı 0\'dan büyük 100\'den küçük olmalıdır          |
| 26        | invalidInterestRate                        | Artırım oranı 0\'dan büyük olmalıdır                         |
| 27        | priceEffectTypeNotFound                    | İskonto tipi(PriceEffectType = $*arg*) bulunamadı            |
| 28        | saleItemsCannotBeEmpty                     | Sepet boş olamaz                                             |
| 29        | genericProductAnonymousCustomer            | Kısmi ürün yalnızca nihai tüketiciye satılabilir             |
| 30        | alreadyProcessingSale                      | Devam eden satış var                                         |
| 31        | documentTypeCannotBeEmpty                  | Doküman tipi boş olamaz                                      |
| 32        | documentTypeAndSaleAppUnMatch              | Doküman tipi $*arg* ve generik satışı ${false} olan tanımlı satış uygulaması bulunmamamktadır |
| 33        | externalAppNameCannotBeEmpty               | Harici uygulama ismi boş olamaz                              |
| 34        | externalAppVersionCannotBeEmpty            | Harici uygulama versiyonu boş olamaz                         |
| 35        | saleItemNameCannotBeEmpty                  | Sipariş kalem ismi boş olamaz. Detail: Sıra No $*arg*        |
| 36        | shouldSpecifySaleItemIsGeneric             | Sipariş kalemİnin generik olup olmadığı belirtilmelidir. Detail: Sıra No $*arg* |
| 37        | invalidSaleItemQuantity                    | Sipariş kalemi miktarı 0 dan büyük olmalıdır. Detail: Sıra No $*arg* |
| 38        | invalidSaleItemUnitPrice                   | Sipariş kalemi birim fiyatı 0 dan büyük olmalıdır. Detail: Sıra No $*arg* |
| 39        | invalidSaleItemGrossPrice                  | Sipariş kalemi brüt ücreti 0 dan büyük olmalıdır. Detail: Sıra No $*arg* |
| 40        | invalidSaleItemTotalPrice                  | Sipariş kalemi toplam ücreti 0 dan büyük olmalıdır. Detail: Sıra No $*arg* |
| 41        | invalidSaleItemTaxGroupCode                | Geçersiz vergi grubu kodu. Detail: Sıra No $*arg* Vergi grubu kodu $*arg2* |
| 42        | saleItemAmountMisMatch                     | Sipariş kalemi miktarı ve birim ücreti hesabı($*arg*) sipariş kalemi brüt($*arg2*) ücrete eşit olmalıdır |
| 43        | invalidSaleItemUnitCode                    | Geçersiz satış kalem birimi. Detail: Sıra No $*arg* Birim kodu $*arg2* |
| 44        | saleItemsTotalPriceMisMatch                | Sipariş kalemleri toplam  ücreti($*arg*) sipariş toplam ücretine(TotalPrice: $*arg2*) eşit olmalıdır |
| 45        | saleItemsGrossPriceMisMatch                | Sipariş kalemleri toplam brüt ücreti($*arg*) sipariş toplam brüt ücretine(GrossPrice: $*arg2*) eşit olmalıdır |
| 46        | invalidCustomerType                        | Geçersiz müşteri tipi. Detail:$*arg*                         |
| 47        | customerNameCannotBeEmpty                  | Müşteri adı boş olamaz.                                      |
| 48        | customerSurnameCannotBeEmpty               | Müşteri soyadı boş olamaz.                                   |
| 49        | invalidCustomerTCKN                        | Geçersiz müşteri tckn                                        |
| 50        | invalidTaxOfficeCode                       | Geçersiz vergi dairesi kodu                                  |
| 51        | customerCompanyNameCannotBeEmpty           | Fatura ünvanı boş olamaz                                     |
| 52        | invalidCustomerVKN                         | Geçersiz müşteri vkn                                         |
| 53        | customerCountryCannotBeEmpty               | Müşteri ülke bilgisi boş geçilemez                           |
| 54        | customerCityCannotBeEmpty                  | Müşteri şehir bilgisi boş geçilemez                          |
| 55        | customerDistrictCannotBeEmpty              | Müşteri ilçe bilgisi boş geçilemez                           |
| 56        | anonymousLimit                             | Nihai tüketici satışı $*arg* TL üzeri olamaz                 |
| 57        | invalidEMail                               | Geçersiz e-mail adresi                                       |
| 58        | invalidPhoneNumber                         | Geçersiz telefon numarası                                    |
| 59        | invalidPaymentType                         | Geçersiz ödeme tipi                                          |
| 60        | invalidPaymentMediator                     | Geçersiz ödeme aracısı                                       |
| 61        | invalidPaymentProviderBrand                | Geçersiz ödeme sağlayıcısı                                   |
| 62        | paymentTypeMisMatch                        | Ödeme tipi ve ödeme aracısı ödeme tipi uyuşmazlığı           |
| 63        | paymentMediatorMisMatch                    | Ödeme aracısı ve ödeme sağlayıcı ödeme aracısı uyuşmazlığı   |
| 64        | paymentMediatorIsNotExternal               | Ödeme aracısı harici değil                                   |
| 65        | invalidExternalPaymentAmount               | Harici ödeme 0 dan büyük olmalıdır                           |
| 66        | externalPaymentCannotBiggerThanTotalAmount | Harici ödemeler toplam ödemeden fazla olamaz                 |
| 67        | operationTypeNotFound                      | $*arg* nolu ödeme sağlayıcısının $*arg2* nolu operasyon tipi bulunamadı |
| 68        | paymentMediatorAmountLimit                 | $*arg* nolu ödeme sağlayıcısı ile ödeme limitiniz $*arg2* TL\'dir |
| 69        | paymentInformationAmountMisMatch           | Sepet toplam tutarı ($*arg*) harici ödenecek ($*arg2*) tutara eşit değildir |
| 70        | unKnownCheckSaleError                      | Bilinmeyen satış kontrol hatası                              |
| 71        | serialNumberMisMatch                       | Seri numarası uyuşmazlığı                                    |
| 72        | toleranceTimeRange                         | Pos ve harici cihaz zaman uyuşmazlığı. Tolerans aralığı 300 saniyedir |
| 73        | transactionSequenceError                   | İşlem sıra numarası hatası                                   |
| 74        | fingerPrintMisMatch                        | FingerPrint uyuşmazlığı                                      |
| 75        | startSaleException                         | Bilinmeyen satış başlatma hatası                             |
| 76        | completeSaleException                      | Bilinmeyen satış hatası                                      |
| 77        | systemError                                | Sistem Hatası                                                |
| 78        | transactionHandleException                 | Bilinmeyen işlem kontrol hatası                              |
| 79        | invalidUserName                            | Kullanıcı adı boş olamaz                                     |
| 80        | invalidPassword                            | Kullanıcı şifresi boş olamaz                                 |
| 81        | loginfailed                                | Kullanıcı girişi yapılamadı                                  |
| 82        | userAlreadyAuthenticated                   | Zaten kullanıcı girişi yapıldı                               |
| 83        | userUnAuthorized                           | Kullanıcı yetkisiz                                           |
| 84        | invalidKeyForAdditionalInfo                | Geçersiz ek bilgi key değeri                                 |

