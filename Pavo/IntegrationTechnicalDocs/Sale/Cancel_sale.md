# Cancel sale:

#### Servis Giriş Parametreleri:

| Alan                                                         | Tip        | Zorunlumu | Açıklama                                                     |
| ------------------------------------------------------------ | ---------- | --------- | ------------------------------------------------------------ |
| Sale                                                         | **object** | E         | yapılan veya başlatılan satış                                |
| &ensp;&ensp;Id                                               | int        | E         | satış idsi                                                   |
| &ensp;&ensp;ReceiptInformation                               | object     |           | Fiş ile ilgili bilgileri içerir.                             |
| &ensp;&ensp;&ensp;&ensp;ReceiptImageEnabled&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp; | boolean    |           | Satış sonrası oluşan müşteri nüshasını base64 formatında geri döner. Varsayılan değeri false |
| &ensp;&ensp;&ensp;&ensp;ReceiptWidth                         | string     |           | Dönülecek olan bilgi fişinin kaç milimetre olduğu bilgisini içerir. Varsayılan değeri '58mm' dir. Bir diğer değer olarak 80mm'yi de kabul eder. Bu iki değerden başka değer desteklenmemektedir. Farklı 58 ve 80 dışındaki inputlar için 58 varsayılan değerini alır. |
| &ensp;&ensp;&ensp;&ensp;PrintCustomerReceipt                 | boolean    |           | Müşteri nüshasının opsiyonel olarak yazdırılması. Varsayılan değeri true |
| &ensp;&ensp;&ensp;&ensp;PrintMerchantReceipt                 | boolean    |           | İşyeri nüshasının opsiyonel olarak yazdırılması. Varsayılan değeri true |

**Örnek JSON İsteği**

```json
{
	"Sale": {
		"Id": 59449,
        "ReceiptInformation":{
    		"ReceiptImageEnabled":false,
    		"ReceiptWidth":"80mm"
		}
	}
}
```



### Başarılı Servis Çıkış Parametreleri

| Alan                 | Tip    | Açıklama                               |
| -------------------- | ------ | -------------------------------------- |
| RelatedPaymentId     | int    | iptal edilmeye çalışılan ödemenin idsi |
| CustomerReceiptImage | string | base64 formatında müşteri nüshası      |

```json
{
	"HasError": false,
	"Message": null,
	"Data": {
		"Id": 59881,
		"MerchantId": 5,
		"ApplicationId": 28,
		"TypeId": 1,
		"StatusId": 12,
		"TerminalId": 1000,
		"GrossPrice": 2.0,
		"TotalPrice": 2.0,
		"TotalVATAmount": 0.02,
		"RawDocumentId": 308368,
		"SignedDocumentId": 308369,
		"MultiPayment": true,
		"MultiDocument": false,
        "InqueryHash": "MA0061000226498",
		"OrderNo": "59881",
        "GMUVersion": "1.0.0",
		"SaleNumber": "MA0061000226498",
		"AddedPriceEffects": [],
		"IsOffline": false,
		"NotificationPhone": "",
		"SendPhoneNotification": false,
		"NotificationEMail": "",
		"SendEMailNotification": false,
		"RefererApp": "Harici Uygulama",
		"RefererAppVersion": "1",
		"AddedSaleItems": [
			{
				"Id": 42821,
				"SaleId": 59881,
				"StatusId": 1,
				"Name": "Gofret",
				"ItemQuantity": 1.0,
				"UnitPriceAmount": 2.0,
				"GrossPriceAmount": 2.0,
				"TotalPriceAmount": 2.0,
				"VATAmount": 0.02,
				"VATRate": 1.0,
				"UnitName": "KG",
				"IsGeneric": false
			}
		],
		"AddedPayments": [
			{
				"Id": 36218,
				"SaleId": 59881,
				"StatusId": 4,
				"MerchantId": 5,
				"PaymentAmount": 1.0,
				"PaymentTypeId": 2,
				"PaymentMediatorId": 9,
				"OperationTypeId": 1,
				"IsExternal": true,
				"ExternalPayment": {
					"Id": 202,
					"PaymentId": 36218,
					"PaymentMediatorId": 9,
					"AuthorizationCode": "123",
					"CardNo": "123456******3456",
					"PaymentProviderBrandId": 6,
					"SaleId": 59881
				}
			},
			{
				"Id": 36219,
				"SaleId": 59881,
				"StatusId": 4,
				"MerchantId": 5,
				"PaymentAmount": 1.0,
				"PaymentTypeId": 1,
				"PaymentMediatorId": 1,
				"CashPayment": {
					"Id": 24027,
					"PaymentId": 36219,
					"SaleId": 59881,
					"GivenAmount": 1.0,
					"ChangeAmount": 0.0
				},
				"OperationTypeId": 1,
				"IsExternal": false
			},
			{
				"Id": 36231,
				"SaleId": 59881,
				"StatusId": 2,
				"MerchantId": 5,
				"PaymentAmount": 1.0,
				"PaymentTypeId": 2,
				"RelatedPaymentId": 36218,
				"PaymentMediatorId": 9,
				"OperationTypeId": 2,
				"IsExternal": true,
				"ExternalPayment": {
					"Id": 0,
					"PaymentId": 0,
					"PaymentMediatorId": 9,
					"AuthorizationCode": "123",
					"PaymentProviderBrandId": 6,
					"SaleId": 59881
				}
			},
			{
				"Id": 36232,
				"SaleId": 59881,
				"StatusId": 2,
				"MerchantId": 5,
				"PaymentAmount": 1.0,
				"PaymentTypeId": 1,
				"RelatedPaymentId": 36219,
				"PaymentMediatorId": 1,
				"CashPayment": {
					"Id": 0,
					"PaymentId": 0,
					"SaleId": 59881,
					"GivenAmount": 1.0,
					"ChangeAmount": 0.0
				},
				"OperationTypeId": 2,
				"IsExternal": false
			}
		]
	}
}
```



### Başarısız Servis Çıkış Parametreleri

```json
{
	"HasError": true,
	"Message": "Satış iptal edilemiyor. Satış durum kodu: 16",
	"Data": {
		"Id": 59449,
		"CreateUserId": 1484,
		"MerchantId": 5,
		"ApplicationId": 28,
		"TypeId": 1,
		"StatusId": 16,
		"TerminalId": 1000,
		"GrossPrice": 4.0,
		"TotalPrice": 4.0,
		"TotalVATAmount": 0.04,
		"RawDocumentId": 308078,
		"SignedDocumentId": 308079,
		"MultiPayment": true,
		"MultiDocument": false,
        "InqueryHash": "BN0041000226484",
		"OrderNo": "59449",
        "GMUVersion": "1.0.0",
		"SaleNumber": "BN0041000226484",
		"AddedPriceEffects": [],
		"IsOffline": false,
		"NotificationPhone": "",
		"SendPhoneNotification": false,
		"NotificationEMail": "",
		"SendEMailNotification": false,
		"RefererApp": "Harici Uygulama",
		"RefererAppVersion": "1",
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
				"IsGeneric": false
			}
		],
		"AddedPayments": [
			{
				"Id": 35659,
				"SaleId": 59449,
				"StatusId": 4,
				"MerchantId": 5,
				"PaymentAmount": 2.0,
				"PaymentTypeId": 2,
				"PaymentMediatorId": 9,
				"OperationTypeId": 1,
				"IsExternal": true,
				"ExternalPayment": {
					"Id": 186,
					"PaymentId": 35659,
					"PaymentMediatorId": 9,
					"AuthorizationCode": "123",
					"CardNo": "123456******3456",
					"PaymentProviderBrandId": 6,
					"SaleId": 59449
				}
			},
			{
				"Id": 35660,
				"SaleId": 59449,
				"StatusId": 4,
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
			},
			{
				"Id": 35661,
				"SaleId": 59449,
				"StatusId": 2,
				"MerchantId": 5,
				"PaymentAmount": 2.0,
				"PaymentTypeId": 2,
				"RelatedPaymentId": 35659,
				"PaymentMediatorId": 9,
				"OperationTypeId": 2,
				"IsExternal": true,
				"ExternalPayment": {
					"Id": 0,
					"PaymentId": 0,
					"PaymentMediatorId": 9,
					"AuthorizationCode": "123",
					"PaymentProviderBrandId": 6,
					"SaleId": 59449
				}
			},
			{
				"Id": 35662,
				"SaleId": 59449,
				"StatusId": 2,
				"MerchantId": 5,
				"PaymentAmount": 2.0,
				"PaymentTypeId": 1,
				"RelatedPaymentId": 35660,
				"PaymentMediatorId": 1,
				"CashPayment": {
					"Id": 0,
					"PaymentId": 0,
					"SaleId": 59449,
					"GivenAmount": 2.0,
					"ChangeAmount": 0.0
				},
				"OperationTypeId": 2,
				"IsExternal": false
			}
		],
	}
}
```

