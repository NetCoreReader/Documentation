# **Satışı Tamamla**

### **Servis Giriş Parametreleri:**

| Alan                                                         | Tip        | Zorunlu mu                               | Açıklama                                                     |
| ------------------------------------------------------------ | ---------- | ---------------------------------------- | ------------------------------------------------------------ |
| Sale                                                         | **object** | E                                        | Ödemesi yapılacak satış                                      |
| &ensp;&ensp;RefererApp                                       | string     | E                                        | Satış yapılan harici uygulamanın adıdır.                     |
| &ensp;&ensp;RefererAppVersion                                | string     |                                          | Satış yapılan harici uygulamanın versiyon bilgisidir         |
| &ensp;&ensp;MainDocumentType                                 | int        | E                                        | Satış yapılacak döküman tipini belirtir.  <br/>&ensp;&ensp;&ensp;E-Fatura : 1 |
| &ensp;&ensp;GrossPrice                                       | decimal    | E                                        | Sepetin brüt tutarı                                          |
| &ensp;&ensp;TotalPrice                                       | decimal    | E                                        | Sepetin net tutarı                                           |
| &ensp;&ensp;SendPhoneNotification&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp; | boolean    | E                                        | SMS bilgilendirmesi yapılsın mı                              |
| &ensp;&ensp;SendEMailNotification                            | boolean    | E                                        | E-Mail bilgilendirmesi yapılsın mı                           |
| &ensp;&ensp;NotificationPhone                                | string     | sms bilgilendirmesi isteniyorsa zorunlu  | Bilgilendirme telefon numarası.                              |
| &ensp;&ensp;NotificationEMail                                | string     | Mail bilgilendirmesi isteniyorsa zorunlu | Bilgilendirme mail adresi.                                   |
| &ensp;&ensp;CancelPaymentLater                               | boolean    |                                          | Ödeme iptalini sonraya bırak bilgisi                                           Varsayılan değeri : true |
| &ensp;&ensp;CurrencyCode                                     | string     |                                          | Dövizli ödeme için döviz kodu [Financial_currency_code.md]() |
| &ensp;&ensp;ExchangeRate                                     | double     |                                          | Dövizli ödeme için döviz kuru                                |
| &ensp;&ensp;AddedSaleItems                                   | **array**  | E                                        | Sepetteki ürün listesi                                       |
| &ensp;&ensp;&ensp;&ensp;Name                                 | string     | E                                        | Ürünün adı                                                   |
| &ensp;&ensp;&ensp;&ensp;IsGeneric                            | boolean    | E                                        | Ürünün generik ürün olup olmadığı                            |
| &ensp;&ensp;&ensp;&ensp;UnitCode                             | string     | E                                        | Ürünün biriminin kodu.  **Bkz: GİB birim kodları**           |
| &ensp;&ensp;&ensp;&ensp;TaxGroupCode                         | string     | E                                        | Ürünün ait olduğu vergi grubunun kodu [Tax_group_code.md](Tax_group_code.md) |
| &ensp;&ensp;&ensp;&ensp;ItemQuantity                         | double     | E                                        | Ürünün miktarı                                               |
| &ensp;&ensp;&ensp;&ensp;UnitPriceAmount                      | decimal    | E                                        | Ürünün birim fiyatı                                          |
| &ensp;&ensp;&ensp;&ensp;GrossPriceAmount                     | decimal    | E                                        | Ürünün brüt fiyatı                                           |
| &ensp;&ensp;&ensp;&ensp;TotalPriceAmount                     | decimal    | E                                        | Ürünün net fiyatı                                            |
| &ensp;&ensp;CustomerParty                                    | **object** | Nihai tüketici değilse zorunl            | Nihai tüketici değilse müşteri bilgileri bu alanda girilir   |
| &ensp;&ensp;&ensp;&ensp;CustomerType                         | int        | E                                        | Müşterinin tüzel mi yoksa gerçek kişi mi olduğunu belirtir.<br/>&ensp;&ensp;1.Gerçek<br/>&ensp;&ensp;2.Tüzel |
| &ensp;&ensp;&ensp;&ensp;FirstName                            | string     | Eğer gerçek kişi ise zorunlu             | Gerçek müşterinin adı                                        |
| &ensp;&ensp;&ensp;&ensp;MiddleName                           | string     |                                          | Gerçek müşterinin ikinci bir ismi varsa                      |
| &ensp;&ensp;&ensp;&ensp;FamilyName                           | string     | Gerçek kişi ise zorunlu                  | Gerçek müşterinin soyadı                                     |
| &ensp;&ensp;&ensp;&ensp;CompanyName                          | string     | Tüzel ise zorunlu                        | Tüzel müşteri şirket adı                                     |
| &ensp;&ensp;&ensp;&ensp;TaxOfficeCode                        | string     | Tüzel ise zorunlu                        | GİB tarafından yayınlanan dökümandaki vergi dairesi kodları  |
| &ensp;&ensp;&ensp;&ensp;TaxNumber                            | string     | E                                        | vergi numarası                                               |
| &ensp;&ensp;&ensp;&ensp;Phone                                | string     |                                          | Müşteri telefon numarası                                     |
| &ensp;&ensp;&ensp;&ensp;EMail                                | string     |                                          | Müşteri mail adresi                                          |
| &ensp;&ensp;&ensp;&ensp;Country                              | string     | E                                        | Müşterinin ülkesi                                            |
| &ensp;&ensp;&ensp;&ensp;City                                 | string     | E                                        | Müşterinin şehri                                             |
| &ensp;&ensp;&ensp;&ensp;District                             | string     | E                                        | Müşterinin ilçesi                                            |
| &ensp;&ensp;&ensp;&ensp;Neighborhood                         | string     |                                          | Müşterinin mahallesi                                         |
| &ensp;&ensp;&ensp;&ensp;Address                              | string     |                                          | Müşterinin daha ayrıntılı adress bilgisi varsa               |
| &ensp;&ensp;ExternalPayments                                 | **array**  |                                          | Harici satış uygulaması tarafından doğrudan yapılan tahsilat bilgisini içerir. Payment Mediators servisinden dönülen mediatorler içinde **ISEXTERNAL_FL** true olanlar seçilebilir. |
| &ensp;&ensp;&ensp;&ensp;Type                                 | int        | E                                        | Ödeme tipi [Payment_types.md](Payment_types.md)              |
| &ensp;&ensp;&ensp;&ensp;Mediator                             | int        | E                                        | Ödeme aracısı  => Kullanılabilir ödeme aracıları bilgisi endpoint üzerinden alınır.[PaymentMediators.md]() |
| &ensp;&ensp;&ensp;&ensp;Brand                                | int        | E                                        | Ödeme sağlayıcısı [Payment_provider_brand.md](Payment_provider_brand.md) |
| &ensp;&ensp;&ensp;&ensp;Amount                               | decimal    | E                                        | Alınan ödeme miktarı                                         |
| &ensp;&ensp;&ensp;&ensp;CardNo                               | string     |                                          | kartın numarası                                              |
| &ensp;&ensp;&ensp;&ensp;AuthorizationCode                    | string     |                                          | otorizasyon kodu                                             |
| PaymentInformations                                          | array      |                                          | Ödemenin nasıl alınacağı bilgisini içerir. E.g. 40 TL tutarlı bir satışın ödemesini 20 TL nakit, 20 TL kredi kartı ya da hepsini kredi kartı alabilirsiniz. Bu sayede uygulamadan ödeme yöntemi seçilmeden dışardan alınan bu bilgiler ile otomatik ödeme gerçekleştirilir. |
| &ensp;&ensp;&ensp;&ensp;&ensp;Mediator                       | int        | E                                        | Ödeme aracısı  => Kullanılabilir ödeme aracıları bilgisi endpoint üzerinden alınır.[PaymentMediators.md]() |
| &ensp;&ensp;&ensp;&ensp;&ensp;Amount                         | decimal    | E                                        | Alınan ödeme miktarı                                         |
| PriceEffect                                                  | object     |                                          | Satış bazlı indirim, artırım bilgisini içerir.               |
| &ensp;&ensp;&ensp;&ensp;&ensp;Type                           | int        | E                                        | [Price_effect_type.md]()                                     |
| &ensp;&ensp;&ensp;&ensp;&ensp;Rate                           | double     | E                                        | Yapılacak indirim ya da artırım oran bilgisini içerir.       |
| ReceiptInformation                                           | object     |                                          | Fiş ile ilgili bilgileri içerir.                             |
| &ensp;&ensp;&ensp;ReceiptImageEnabled&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp; | boolean    |                                          | Satış sonrası oluşan müşteri nüshasını base64 formatında geri döner. Varsayılan değeri false |
| &ensp;&ensp;&ensp;&ensp;ReceiptWidth                         | string     |                                          | Dönülecek olan bilgi fişinin kaç milimetre olduğu bilgisini içerir. Varsayılan değeri '58mm' dir.  80mm ekstra kullanılabilir. |
| &ensp;&ensp;&ensp;&ensp;PrintCustomerReceipt                 | boolean    |                                          | Müşteri nüshasının opsiyonel olarak yazdırılması. Varsayılan değeri true |
| &ensp;&ensp;&ensp;&ensp;PrintMerchantReceipt                 | boolean    |                                          | İşyeri nüshasının opsiyonel olarak yazdırılması. Varsayılan değeri true |
| ShowCreditCardMenu                                           | boolean    |                                          | Değeri false set edilirse kredi kartı ödemelerinde menü kısmını atlayarak direkt kart okuma alanını açar. |
| AskCustomer                                                  | boolean    |                                          | Değeri true set edilirse ödeme ekranından önce müşteri ekranını açar ve burada kayıtlı müşteri varsa seçilebilir ya da yeni müşteri eklenebilir. |
| AdditionalInfo                                               | array      |                                          | Harici uygulamadan gönderilen, fişe yazdırılacak ve sisteme kaydedilecek bilgileri içerir. |
| &ensp;&ensp;&ensp;&ensp;Key                                  | string     | E                                        | Json olarak kaydedilebilmesi için gönderilecek key değeri.   |
| &ensp;&ensp;&ensp;&ensp;Value                                | dynamic    |                                          | Key değerine karşılık gelen value değeri.                    |
| &ensp;&ensp;&ensp;&ensp;Print                                | boolean    |                                          | Bu bilginin fişe yazdırılıp yazdırılmayacağı bilgisini içerir. |



**Örnek JSON İsteği**

```json
{
	"Sale": {
		"RefererApp": "Intent Harici Uygulama",
        "RefererAppVersion": "1",
        "MainDocumentType": 1,
		"GrossPrice": 10.0,
		"TotalPrice": 10.0,
        "SendPhoneNotification": false,
		"SendEMailNotification": true,
		"NotificationPhone": "",
		"NotificationEMail":  "meinfo@myinfo.dev",
		"AddedSaleItems": [
			{
				"Name": "Gofret",
				"IsGeneric": false,
				"UnitCode": "KGM",
				"TaxGroupCode": "KDV1",
				"ItemQuantity": 2.0,
				"UnitPriceAmount": 5.0,
				"GrossPriceAmount": 10.0,
				"TotalPriceAmount": 10.0
			}
		],
		"CustomerParty": {
			"CustomerType": 2,
			"FirstName": null,
			"MiddleName": null,
			"FamilyName": null,
			"CompanyName": "ABC A.Ş.",
			"TaxOfficeCode": "001103",
			"TaxNumber": "9220036550",
			"Phone": null,
			"EMail": null,
			"Country": "Türkiye",
			"City": "İstanbul",
			"District": "Başakşehir",
			"Neighborhood": null,
			"Address": null
		},
        "ReceiptInformation":{
    		"ReceiptImageEnabled":true,
    		"ReceiptWidth":"58mm"
		},
        "PriceEffect":{
            "Type":2, "Rate":50
        },
		"ExternalPayments": [
			{
				"Type": 2,
				"Mediator": 9,
				"Brand": 6,
				"Amount": 1.0,
				"CardNo": "1234567890123456",
				"AuthorizationCode": "123"
			}
		],
        "PaymentInformations": [
			{
				"Mediator": 1,
				"Amount": 2.0
			},
            {
				"Mediator": 2,
				"Amount": 2.0
			}
		]
	}
}

```



#### Başarılı Servis Çıkış Parametreleri

| Alan                                      | Tip        | Açıklama                                                     |
| ----------------------------------------- | ---------- | ------------------------------------------------------------ |
| HasError                                  | boolean    | Yapılan işlemde hata var mı                                  |
| Message                                   | string     | Hata varsa hata mesajı                                       |
| Data                                      | **object** |                                                              |
| &ensp;&ensp;Id                            | int        | satış idsi                                                   |
| &ensp;&ensp;SaleNumber                    | string     | satış numarası                                               |
| &ensp;&ensp;IsOffline                     | boolean    | Offline satış olup olmadığı bilgisi                          |
| &ensp;&ensp;MerchantId                    | int        | satışın yapan                                                |
| &ensp;&ensp;ApplicationId                 | int        | satışın yapılduğı satış uygulaması                           |
| &ensp;&ensp;TypeId                        | int        | satışın tipi<br/>&ensp;&ensp;1. Sales<br/>                   |
| &ensp;&ensp;StatusId                      | int        | Satışın statüsü. [Status.md](Status.md) den bakılabilir      |
| &ensp;&ensp;TerminalId                    | int        | satışın yapıldığı cihazın terminali                          |
| &ensp;&ensp;GrossPrice                    | decimal    | satışın brüt fiyatı                                          |
| &ensp;&ensp;TotalPrice                    | decimal    | satışın net fiyatı                                           |
| &ensp;&ensp;TotalVATAmount                | decimal    | uygulanan toplam kdv                                         |
| &ensp;&ensp;MultiPayment                  | boolean    | parçalı ödememi                                              |
| &ensp;&ensp;MultiDocument                 | boolean    | çoklu dökümanmı                                              |
| &ensp;&ensp;InqueryHash                   | string     |                                                              |
| &ensp;&ensp;OrderNo                       |            |                                                              |
| &ensp;&ensp;GMUVersion                    |            |                                                              |
| &ensp;&ensp;SendPhoneNotification         | boolean    | Telefon bilgilendirmesi yapılsınmı                           |
| &ensp;&ensp;SendEMailNotification         | boolean    | Mail bilgilendirmesi yapılsınmı                              |
| &ensp;&ensp;NotificationPhone             | string     | telefon numarası                                             |
| &ensp;&ensp;NotificationEMail             | string     | mail adresi                                                  |
| &ensp;&ensp;RefererApp                    | string     | harici uygulamanın adı                                       |
| &ensp;&ensp;RefererAppVersion             | string     | harici uygulamanın versiyonnu                                |
| &ensp;&ensp;AddedSaleItems                | **array**  | oluşturulan sepet kalemleri                                  |
| &ensp;&ensp;&ensp;&ensp;Id                | int        | oluşan kalemin idsi                                          |
| &ensp;&ensp;&ensp;&ensp;SaleId            | int        | satışın idsi                                                 |
| &ensp;&ensp;&ensp;&ensp;StatusId          | int        | satış kalemin statusu [Status.md](Status.md)                 |
| &ensp;&ensp;&ensp;&ensp;Name              | string     | satış kaleminin adı                                          |
| &ensp;&ensp;&ensp;&ensp;ItemQuantity      | double     | satış kaleminin miktarı                                      |
| &ensp;&ensp;&ensp;&ensp;UnitPriceAmount   | decimal    | satış kaleminin birim fiyatı                                 |
| &ensp;&ensp;&ensp;&ensp;GrossPriceAmount  | decimal    | satış kaleminin brüt fiyatı                                  |
| &ensp;&ensp;&ensp;&ensp;TotalPriceAmount  | decimal    | satış kaleminin net fiyatı                                   |
| &ensp;&ensp;&ensp;&ensp;VATAmount         | decimal    | satış kaleminin vergi miktarı                                |
| &ensp;&ensp;&ensp;&ensp;VATRate           | double     | satış kaleminin vergi oranı                                  |
| &ensp;&ensp;&ensp;&ensp;UnitName          | string     | satış kaleminin birim adı                                    |
| &ensp;&ensp;&ensp;&ensp;IsGeneric         | boolean    | satış kalemi generikmi bilgisi                               |
| &ensp;&ensp;AddedPayments                 | **array**  |                                                              |
| &ensp;&ensp;&ensp;&ensp;Id                | int        | oluşan ödemenin idsi                                         |
| &ensp;&ensp;&ensp;&ensp;SaleId            | int        | satışın ıdsi                                                 |
| &ensp;&ensp;&ensp;&ensp;StatusId          | int        | ödemenin statüsü.  [Status.md](Status.md) den bakılabilir    |
| &ensp;&ensp;&ensp;&ensp;MerchantId        | int        | satışı yapan                                                 |
| &ensp;&ensp;&ensp;&ensp;PaymentAmount     | decimal    | ödemenin miktarı                                             |
| &ensp;&ensp;&ensp;&ensp;PaymentTypeId     | int        | ödeminin tipi                                                |
| &ensp;&ensp;&ensp;&ensp;PaymentMediatorId | int        | ödeme aracı                                                  |
| &ensp;&ensp;&ensp;&ensp;OperationTypeId   | int        | 1. Payment  ->  Alınan Ödemedir<br/>2. Void -> Alınan Ödemenin Aynı Kanaldan İptali<br/>3. Refund -> Geri Ödeme İşlemidir |
| &ensp;&ensp;&ensp;&ensp;IsExternal        | boolean    | Harici ödememi                                               |
| &ensp;&ensp;CustomerParty                 | **object** | Varsa müşteri bilgileri                                      |
| &ensp;&ensp;Errors                        | **array**  | Varsa hata listesi                                           |
| &ensp;&ensp;AddedPriceEffects             | **object** | Uygulanan indirim, artırım bilgileri                         |
| &ensp;&ensp;CustomerReceiptImage          | string     | base64 formatında müşteri nüshası                            |
| &ensp;&ensp;Taxes                         | array      | Kdv oranı ve kdv tutarlarının listesi                        |
| &ensp;&ensp;&ensp;&ensp;TaxRate           | double     | Kdv oranı e.g(1,8,18)                                        |
| &ensp;&ensp;&ensp;&ensp;TotalTaxAmount    | double     | Kdv tutarı                                                   |
| &ensp;&ensp;&ensp;&ensp;TotalAmount       | double     | Toplam tutar                                                 |



```json
{
    "HasError": false,
    "Message": null,
    "TransactionHandle": {
        "SerialNumber": "N500Z000028",
        "Fingerprint": "XGD/la0920/la0920:7.1.2/N2G47H/102:user/dev-keys",
        "TransactionSequence": 15,
        "TransactionDate": "2022-08-02T14:46:03.435377"
    },
    "Data": {
        "Id": 81939,
        "SaleNumber": "PQ2131000222834",
        "IsOffline": false,
        "OrderNo": "81939",
        "TypeId": 1,
        "StatusId": 4,
        "GrossPrice": 10.0,
        "TotalPrice": 5.0,
        "TotalVATAmount": 0.05,
        "MerchantId": 5,
        "TerminalId": 1000,
        "ApplicationId": 28,
        "MultiPayment": true,
        "MultiDocument": false,
        "GMUVersion": "1.0.0",
        "RefererApp": "Intent Harici Uygulama",
        "RefererAppVersion": "1",
        "NotificationPhone": "",
        "SendPhoneNotification": false,
        "NotificationEMail": "meinfo@myinfo.dev",
        "SendEMailNotification": true,
        "AddedSaleItems": [
            {
                "Id": 63043,
                "SaleId": 81939,
                "StatusId": 1,
                "Name": "Gofret",
                "ItemQuantity": 2.0,
                "UnitPriceAmount": 5.0,
                "GrossPriceAmount": 10.0,
                "TotalPriceAmount": 5.0,
                "VATAmount": 0.05,
                "VATRate": 1.0,
                "UnitName": "KG",
                "TaxGroupId": 50,
                "IsGeneric": false
            }
        ],
        "CustomerReceiptImage":"XXX", // uzun bir veri oldugundan bu sekilde gosterildi.
        "AddedPriceEffects": [
            {
                "Id": 0,
                "SaleId": 81939,
                "StatusId": 1,
                "PriceEffectTypeId": 2,
                "PriceEffectAmount": 5.0,
                "PriceEffectRate": 50.0
            }
        ],
        "AddedPayments": [
            {
                "Id": 59129,
                "SaleId": 81939,
                "StatusId": 2,
                "MerchantId": 5,
                "PaymentAmount": 1.0,
                "PaymentTypeId": 2,
                "PaymentMediatorId": 9,
                "AuthorizationIdResponse": "123",
                "OperationTypeId": 1,
                "IsExternal": true,
                "ExternalPayment": {
                    "Id": 811,
                    "PaymentId": 59129,
                    "PaymentMediatorId": 9,
                    "AuthorizationCode": "123",
                    "CardNo": "encv2:/1h+0tKmYuIO0ZlNzyHbusi2vr4VESuBVI3dqyytMzkE=",
                    "PaymentProviderBrandId": 6,
                    "SaleId": 81939
                }
            },
            {
                "Id": 59130,
                "SaleId": 81939,
                "StatusId": 2,
                "MerchantId": 5,
                "PaymentAmount": 2.0,
                "PaymentTypeId": 1,
                "PaymentMediatorId": 1,
                "OperationTypeId": 1,
                "IsExternal": false,
                "CashPayment": {
                    "Id": 0,
                    "PaymentId": 59130,
                    "SaleId": 81939,
                    "GivenAmount": 2.0,
                    "ChangeAmount": 0.0
                }
            },
            {
                "Id": 59131,
                "SaleId": 81939,
                "StatusId": 2,
                "MerchantId": 5,
                "PaymentAmount": 2.0,
                "ReservedText": "000026",
                "PaymentTypeId": 2,
                "PaymentMediatorId": 2,
                "AuthorizationIdResponse": "000026",
                "OperationTypeId": 1,
                "IsExternal": false,
                "OnlinePayment": {
                    "Id": 20504,
                    "PaymentId": 59131,
                    "SaleId": 81939,
                    "PaymentMediatorId": 2,
                    "CardNo": "5345********3423",
                    "TransactionNo": "2",
                    "BatchNo": "130",
                    "AuthorizationCode": "000026",
                    "Online": "221414559264",
                    "AcquirerTransaction": "0000221414559264",
                    "AcquirerName":"Test Bankası"
                }
            }
        ],
        "CustomerParty": {
            "Id": 21,
            "CustomerTypeId": 2,
            "TaxNumber": "9220036550",
            "CompanyName": "ABC A.Ş.",
            "Country": "Türkiye",
            "City": "İstanbul",
            "District": "Başakşehir"
        },
       "FinancialDocuments": [
            {
                "Id": 49746,
                "InvoiceNo": "EFT2022000000055"
            }
        ],
        "Taxes": [
            {
                "TaxRate": 1.0,
                "TotalTaxAmount": 0.05,
                "TotalAmount": 5.0
            }
        ]
    }
}
```



**Başarısız JSON Output:**

```json
{
	"HasError": true,
	"Message": "Satış Başlatılamadı.",
	"Data": {
		"Errors": [
			"Doküman tipi 11 ve generik satışı false olan tanımlı satış uygulaması bulunmamaktadır"
		]
	}
}
```

