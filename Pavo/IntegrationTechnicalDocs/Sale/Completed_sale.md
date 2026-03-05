# Completed sale:

#### Servis Giriş Parametreleri:

| Alan                   | Tip        | Zorunlumu | Açıklama                      |
| ---------------------- | ---------- | --------- | ----------------------------- |
| Sale                   | **object** | E         | yapılan veya başlatılan satış |
| &ensp;&ensp;Id         | int        |           | satış idsi                    |
| &ensp;&ensp;SaleNumber | string     |           | satış numarası                |

**Örnek JSON İsteği**

```json
{
	"Sale": {
		"Id": 59449,
		"SaleNumber": "BN0041000226484",
	}
}
//İki alandan birisi muhakkak zorunludur.
```



### Başarılı Servis Çıkış Parametreleri

```json
{
    "HasError": false,
    "Message": null,
    "Data": {
        "Id": 81931,
        "SaleNumber": "SU2121000225533",
        "IsOffline": false,
        "OrderNo": "81931",
        "TypeId": 1,
        "StatusId": 6,
        "GrossPrice": 28.0,
        "TotalPrice": 14.0,
        "TotalVATAmount": 1.66,
        "MerchantId": 5,
        "TerminalId": 1000,
        "ApplicationId": 28,
        "RawDocumentId": 329657,
        "SignedDocumentId": 329658,
        "MultiPayment": false,
        "MultiDocument": false,
        "GMUVersion": "1.0.0",
        "RefererApp": "Harici Referer App",
        "RefererAppVersion": "1",
        "SendPhoneNotification": false,
        "SendEMailNotification": false,
        "AddedSaleItems": [
            {
                "Id": 63037,
                "SaleId": 81931,
                "StatusId": 1,
                "Name": "Dondurma",
                "ItemQuantity": 1.0,
                "UnitPriceAmount": 16.0,
                "GrossPriceAmount": 16.0,
                "TotalPriceAmount": 8.0,
                "VATAmount": 1.22,
                "VATRate": 18.0,
                "UnitName": "Adet",
                "TaxGroupId": 48,
                "IsGeneric": false
            },
            {
                "Id": 63038,
                "SaleId": 81931,
                "StatusId": 1,
                "Name": "Ekmek",
                "ItemQuantity": 1.0,
                "UnitPriceAmount": 12.0,
                "GrossPriceAmount": 12.0,
                "TotalPriceAmount": 6.0,
                "VATAmount": 0.44,
                "VATRate": 8.0,
                "UnitName": "Adet",
                "TaxGroupId": 49,
                "IsGeneric": false
            }
        ],
        "AddedPriceEffects": [
            {
                "Id": 12948,
                "SaleId": 81931,
                "StatusId": 1,
                "PriceEffectTypeId": 2,
                "PriceEffectAmount": 14.0,
                "PriceEffectRate": 50.0
            }
        ],
        "AddedPayments": [
            {
                "Id": 59122,
                "SaleId": 81931,
                "StatusId": 2,
                "MerchantId": 5,
                "PaymentAmount": 14.0,
                "CardNo": "1234********3456",
                "PaymentTypeId": 2,
                "PaymentMediatorId": 9,
                "OperationTypeId": 1,
                "IsExternal": true,
                "ExternalPayment": {
                    "Id": 810,
                    "PaymentId": 59122,
                    "PaymentMediatorId": 9,
                    "AuthorizationCode": "123",
                    "CardNo": "1234********3456",
                    "PaymentProviderBrandId": 6,
                    "SaleId": 81931
                }
            }
        ],
        "FinancialDocuments": [
            {
                "Id": 38936,
                "Deleted": false,
                "TypeId": 2,
                "StatusId": 5,
                "SaleId": 81931,
                "DocumentNo": "XXXXXXXXXXXXXXXXX",
                "InvoiceNo": "XXXXXXXXXXXXX",
                "DocumentAmount": 14.0,
                "InquiryLink": "XXXXXXXXXXX"
            }
        ]
    }
}
```



### Satış statü bilgileri için => [Status.md](Status.md)

### Başarısız Servis Çıkış Parametreleri

```json
{
	"HasError": true,
	"Message": "Satış Hatası",
	"Data": {
        Status:"4"  // satışın güncel statü bilgisidir. 4 numara doküman bekleniyor, 6 numara başarılı cevap 						olup satışın tamamlandığı bilgisini verir.
	}
}
```

