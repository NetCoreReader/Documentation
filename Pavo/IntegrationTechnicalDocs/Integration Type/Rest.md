# Rest Satış

Temel İstek Yapısı

https://192.168.85.67:4567/Pairing

https:// IP adresi : Port / method

#### Eşleştir

**Method:** Pairing

**Servis Giriş Parametreleri:**

| Alan                            | Tipi       | Zorunlu mu | Açıklama                                          |
| ------------------------------- | ---------- | ---------- | ------------------------------------------------- |
| TransactionHandle               | **object** | E          | Eşleştirme için gerekli parametreler              |
| &ensp;&ensp;SerialNumber        | string     | E          | Bağlanılacak cihazın(POS) seri numarası           |
| &ensp;&ensp;Fingerprint         | string     | E          | Bağlanmak istenen programın/cihazın finger printi |
| &ensp;&ensp;TransactionSequence | int        | E          | Başlatılmak istenen işlem sırası                  |
| &ensp;&ensp;TransactionDate     | string     | E          | Bağlanmak istenen zaman                           |



**Örnek JSON Örneği:**

```json
{
  "TransactionHandle":{
  	"SerialNumber":"N500Z000028",
	"Fingerprint":"test_fingerprint",
	"TransactionSequence":1,
	"TransactionDate":"2021-12-29T18:47:30"
  }
}
```



**Servis Çıkış Parametreleri:**

| Alan                            | Tipi       | Açıklama                                          |
| ------------------------------- | ---------- | ------------------------------------------------- |
| HasError                        | boolean    | Yapılan İşlemde hata var mı                       |
| Message                         | string     | Varsa hata mesajı                                 |
| TransactionHandle               | **object** | Eşleştirme için gerekli parametreler              |
| &ensp;&ensp;SerialNumber        | string     | Bağlanılacak cihazın(POS) seri numarası           |
| &ensp;&ensp;Fingerprint         | string     | Bağlanmak istenen programın/cihazın finger printi |
| &ensp;&ensp;TransactionSequence | int        | İşlem sıra numarası                               |
| &ensp;&ensp;TransactionDate     | string     | istek zamanı                                      |
| Errors                          | **array**  | Varsa hata listesi                                |



**Başarılı JSON Output:**

```json
{
  "HasError": false,
  "Message": "",
  "TransactionHandle": {
	"SerialNumber": "N500Z000028",
 	"Fingerprint": "XGD/la0920/la0920:7.1.2/N2G47H/102:user/dev-keys",
	"TransactionSequence": 1,
	"TransactionDate": "2022-01-08T13:46:11.143676"
  }
}
```



**Başarısız JSON Output:**

```json
{
  "HasError": true,
  "Message": "Transaction handle hatası",
  "TransactionHandle": {
    "SerialNumber": "N500Z000028",
    "Fingerprint": "XGD/la0920/la0920:7.1.2/N2G47H/102:user/dev-keys",
    "TransactionSequence": 5,
    "TransactionDate": "2022-01-08T13:56:21.218146"
  },
  "Errors": [
    "Pos ve harici cihaz zaman uyuşmazlığı. Tolerans aralığı 300 saniyedir.",
  ]
}
```



Başarılı bir şekilde eşleştirme yapıldıktan sonra artık istenilen satış işlemleri yapılabilir. Her istekte TransactionHandle bilgileride eklenmelidir. Eklenen TransactionHandle ile isteğin eşleşen cihazdan gelip gelmediği anlaşılır. Aynı şekilde dönen istek cevabında da satış uygulaması kendi TransactionHandle bilgilerini göndderir. Cevabı alanda cevabın doğru yerden gelip gelmediğini kontrol edebilir. **Eşleşmeden sonra yapılan her istekte TransactionSequence (işlem sıra numarası) arttırılmalıdır.** 

#### **Satışı Tamamla**

**Method:** CompleteSale

```json
{
  "TransactionHandle": {
    "SerialNumber":"N500Z000028",
    "Fingerprint":"test_fingerprint",
    "TransactionSequence": 24,
    "TransactionDate":"2022-12-16T18:26:30"
  },
  "Sale": {
		"RefererApp": "Intent Harici Uygulama",
        "RefererAppVersion": "1",
        "MainDocumentType": 1,
		"GrossPrice": 4.0,
		"TotalPrice": 4.0,
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
				"UnitPriceAmount": 2.0,
				"GrossPriceAmount": 4.0,
				"TotalPriceAmount": 4.0
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
		"ExternalPayments": [
			{
				"Type": 2,
				"Mediator": 9,
				"Brand": 6,
				"Amount": 2.0,
				"CardNo": "1234567890123456",
				"AuthorizationCode": "123"
			}
		]
	}
}
```

```json
{
	"HasError": false,
	"Message": null,
	"TransactionHandle": {
		"SerialNumber": "N500Z000028",
		"Fingerprint": "XGD/la0920/la0920:7.1.2/N2G47H/102:user/dev-keys",
		"TransactionSequence": 2,
		"TransactionDate": "2022-01-09T18:02:32.819115"
	},
	"Data": {
		"Id": 59449,
		"MerchantId": 5,
		"ApplicationId": 28,
		"TypeId": 1,
		"StatusId": 6,
		"TerminalId": 1000,
		"GrossPrice": 4.0,
		"TotalPrice": 4.0,
		"TotalVATAmount": 0.04,
		"MultiPayment": true,
		"MultiDocument": false,
        "InqueryHash": "BN0041000226484",
		"OrderNo": "59449",
        "GMUVersion": "1.0.0",
		"SaleNumber": "BN0041000226484",
		"IsOffline": false,
		"NotificationPhone": "",
		"SendPhoneNotification": false,
		"NotificationEMail":  "meinfo@myinfo.dev",
		"SendEMailNotification": true,
		"RefererApp": "Harici Uygulama",
        "RefererAppVersion": "1",
        "AddedPriceEffects": [],
		"AddedSaleItems": [
			{
				"Id": 42200,
				"SaleId": 59449,
				"StatusId": 1,
				"Name": "Gofret",
				"ItemQuantity": 2.0,
				"UnitPriceAmount": 2.0,
				"GrossPriceAmount": 4.0,
				"TotalPriceAmount": 4.0,
				"VATAmount": 0.04,
				"VATRate": 1.0,
				"UnitName": "KG",
                "TaxGroupId" : 48,
				"IsGeneric": false
			}
		],
		"AddedPayments": [
			{
				"Id": 35659,
				"SaleId": 59449,
				"StatusId": 2,
				"MerchantId": 5,
				"PaymentAmount": 2.0,
				"PaymentTypeId": 2,
				"PaymentMediatorId": 9,
				"OperationTypeId": 1,
				"IsExternal": true,
				"ExternalPayment": {
					"Id": 186,
					"CreateUserId": 1484,
					"PaymentId": 35659,
					"PaymentMediatorId": 9,
					"AuthorizationCode": "123",
					"CardNo": "1234567890123456",
					"PaymentProviderBrandId": 6,
					"SaleId": 59449
				}
			},
			{
				"Id": 35660,
				"SaleId": 59449,
				"StatusId": 2,
				"MerchantId": 5,
				"PaymentAmount": 2.0,
				"PaymentTypeId": 1,
				"PaymentMediatorId": 1,
				"CashPayment": {
					"Id": 23594,
					"PaymentId": 35660,
					"SaleId": 59449,
					"GivenAmount": 2.0,
					"ChangeAmount": 0.0
				},
				"OperationTypeId": 1,
				"IsExternal": false
			}
		],
		"CustomerParty": {
			"Id": 16,
			"CustomerTypeId": 2,
			"CompanyName": "ABC A.Ş.",
			"TaxNumber": "9220036550",
			"Country": "Türkiye",
			"City": "İstanbul",
			"District": "Başakşehir"
		}
	}
}
```



#### Satışı iptal Et

**Method:** CancelSale

 [Cancel_sale.md](Cancel_sale.md) 

#### **Sepeti Tamamla**

**Method:** CompleteSale

 [Complete_sale.md](Complete_sale.md) 

#### **Ödeme Aracılarını Getir**

**Method:** PaymentMediators

 [Payment_Mediators.md](Payment_Mediators.md)

#### **Tamamlanmış Satışı Getir**

**Method:** CompletedSale

 [Completed_sale.md](Completed_sale.md)

#### Fiş Yazdır

**Method:** PrintOut

 [Print_out.md](Print_out.md)

#### Giriş Yap

**Method:** Login

 [Login.md](Login.md)