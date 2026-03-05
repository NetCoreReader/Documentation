## PrintOut (Harici olarak cihazdan fiş yazdırma)

| Alan         | Tip    | Zorunlu mu | Açıklama                                                     |
| ------------ | ------ | ---------- | ------------------------------------------------------------ |
| Print        | object | E          | Fiş bilgisi modeli                                           |
| &ensp;Image  | string |            | base64 formatında yazdırılacak olan png ya da jpeg resim     |
| &ensp;Sale   | object |            | ödeme almadan önce cihazdan ön adisyon yazdırmak için kullanılır. Satış yapmak için gönderdiğiniz modelin aynısını yollayabilirsiniz. |
| &ensp;SaleId | int    |            | tamamlanmış bir satışın fişinin basılması için kullanılır.   |

**NOT : 3 özellik aynı anda kullanılamaz. Kullanılma durumunda öncelik sırası olarak Image > Sale > SaleId olarak kabul edilir.**

**Image İçin Örnek Gönderilecek Json Model** (Rest için TransactionHandle gereklidir!!)

```json
{	
    "Print":{
    	"Image":"XXX..." 
	}
}
```

**Sale İçin Örnek Gönderilecek Json Model**(Rest için TransactionHandle gereklidir!!)

```json
{
  "Print": {
    "Sale": {
      "MainDocumentType": 1,
      "RefererApp": "Sistem Pos",
      "RefererAppVersion": "1",
      "GrossPrice": 5,
      "TotalPrice": 5,
      "SendPhoneNotification": false,
      "SendEMailNotification": false,
      "NotificationPhone": "",
      "NotificationEmail": "",
      "AddedSaleItems": [
        {
          "Name": "BÜYÜK ÇAY",
          "IsGeneric": false,
          "UnitCode": "KGM",
          "TaxGroupCode": "KDV1",
          "ItemQuantity": 1,
          "UnitPriceAmount": 5,
          "GrossPriceAmount": 5,
          "TotalPriceAmount": 5
        }
      ]
    }
  }
}
```

##### SaleId İçin Örnek Gönderilecek Json Model(Rest için TransactionHandle gereklidir!!)

```json
{	
    "Print":{
    	"SaleId":9999
	}
}
```

