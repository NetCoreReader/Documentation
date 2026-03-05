## Web Services

| Test Url                                                     | Canlı Url                                                    | Parametreler                                                 | Authentication Token | Açıklama                                                     |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | -------------------- | ------------------------------------------------------------ |
| https://overpaywsdemo.overtech.com.tr/api/ApiAuthentication/Authenticate | https://pavopayws.pavo.com.tr/api/ApiAuthentication/Authenticate | AppToken(string)                                                          ApiKey(string) | Hayır                | Diğer isteklerde kullanmanız gereken token bilgisini döner.  |
| https://overpaywsdemo.overtech.com.tr/api/ExternalSalesIntegration/GetCompletedSaleBySaleNumber | https://pavopayws.pavo.com.tr/api/ExternalSalesIntegration/GetCompletedSaleBySaleNumber | saleNumber(string)                                           | Evet                 | Satış durumunu sorgulamak ve satış ile alakalı gerekli verileri almak için kullanılır. Satış yok ise satış bulunamadı cevabı geri döner. Satışın bulunması durumunda ise dönen bilgiler arasında satışın statüsü(StatusId) [Status.md](Status.md) kontrol edilerek satışın durumu öğrenilir. |

**AppToken = "97b7a056881768d5a5eccac57402166b3024b798"** **sabit bir değerdir.**

**ApiKey = Satış portalı -> Ana Sayfa -> Sağ üstten kullanıcıya tıklanır -> Api Settings -> Yeni**

**Rastgele bir apikey oluşturulduktan sonra bu apikey güncelle diyerek aktif hale getirilir.** **Not: Yeni bir apikey oluşturduktan sonra bir yere kayıt ediniz aksi takdirde o apikeye tekrar ulaşamayacaksınız. Apikey'in unutulması ya da kaybolması durumunda yeni bir apikey oluşturarak devam edebilirsiniz.**
