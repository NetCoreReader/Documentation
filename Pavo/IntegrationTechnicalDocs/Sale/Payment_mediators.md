# Payment Mediators:

|                                   | Veri Tipi | Açıklama                                                     |
| --------------------------------- | --------- | ------------------------------------------------------------ |
| **Id**                            | int       | **Ödeme Aracısı No**                                         |
| **Name**                          | string    | **Ödeme Aracısı İsmi**                                       |
| **PaymentTypeId**                 | int       | **Ödeme Tipi** [Payment_types.md](Payment_types.md)          |
| **IsExternal**                    | bool      | **Harici mi**                                                |
| **IsOffline**                     | bool      | **Çevrimdışı satış yapabilir mi**                            |
| **PaymentMediatorOperationTypes** | array     | **Desteklediği operasyon türleri** [Operation_types.md](Operation_types.md) |
| **OperationTypeId**               | int       | **Operasyon tipi**                                           |
| **Amount**                        | decimal   | **Ödenebilecek tutar limit**                                 |



**Başarılı JSON Output:**

```json
{
    "HasError": false,
    "Message": null,
    "Data": {
        "PaymentMediators": [
            {
                "Id": 1,
                "Name": "Nakit",
                "PaymentTypeId": 1,
                "IsExternal": false,
                "IsOffline": true,
                "PaymentMediatorOperationTypes": [
                    {
                        "MediatorId": 1,
                        "OperationTypeId": 1,
                        "Amount": 5000.0
                    },
                    {
                        "MediatorId": 1,
                        "OperationTypeId": 2,
                        "Amount": 5000.0
                    },
                    {
                        "MediatorId": 1,
                        "OperationTypeId": 3,
                        "Amount": 100.0
                    }
                ]
            },
            {
                "Id": 2,
                "Name": "BKM TechPOS",
                "PaymentTypeId": 2,
                "IsExternal": false,
                "IsOffline": false,
                "PaymentMediatorOperationTypes": [
                    {
                        "MediatorId": 2,
                        "OperationTypeId": 1,
                        "Amount": 100.0
                    },
                    {
                        "MediatorId": 2,
                        "OperationTypeId": 2,
                        "Amount": 100.0
                    },
                    {
                        "MediatorId": 2,
                        "OperationTypeId": 3,
                        "Amount": 100.0
                    }
                ]
            }
        ]
    }
}
```

**Başarısız JSON Output:**

```json
{
    "HasError": true,
    "Message": "Ödeme aracısı bulunamadı",
    "Data": null
}
```

