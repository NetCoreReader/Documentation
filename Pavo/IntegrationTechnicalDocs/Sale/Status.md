### Sale Status

| StatusId | Name                  | Descriprion                        |
| -------- | --------------------- | ---------------------------------- |
| 1        | Suspended             | Satış askıya alındı                |
| 2        | PaymentWaiting        | Ödeme bakliyor                     |
| 3        | DocumentCreating      | Döküman oluşturuluyor              |
| 4        | DocumentPending       | Döküman bekleniyor                 |
| 5        | DocumentCreated       | Döküman oluşturuldu                |
| 6        | Completed             | Tamamlandı                         |
| 7        | Abandoned             | Satıştan vazgeçildi                |
| 8        | DocumentFailed        | Döküman oluştırulamadı             |
| 9        | Signing               | İmzalanıyor                        |
| 10       | SigningFailed         | İmzalama işlemi başarısız          |
| 11       | Cancalled             | İptal edildi                       |
| 12       | PaymentCancelling     | Ödemeler iptal ediliyor            |
| 13       | PaymentCancelled      | Ödemeler iptal edildi              |
| 14       | PaymentCancelFailed   | Ödeme iptali geerçekleştirilemedi  |
| 15       | DocumentCancelling    | Döküman iptal ediliyor             |
| 16       | DocumentCancelFailed  | Döküman iptlai gerçekleştirilemedi |
| 17       | DocumentCancelPending | Döküman iptali bekleniyor          |
| 18       | Signed                | İmzalandı                          |
| 19       | ERPProcessing         | ERP operasyonlarında               |
| 20       | DocumentApproved      | Döküman onaylandı                  |
| 21       | DocumentNotApproved   | Döküman onaylanmadı.               |

#### Sale Item Status

| StatusId | Name    | Description                                   |
| -------- | ------- | --------------------------------------------- |
| 1        | Added   | Sepete yeni bir kalem eklendiği zamanki statu |
| 2        | Removed | Eğer satış kalemi sepetten çıkarıldıysa       |



#### Payment Status

| StatusId | Name               | Description                       |
| -------- | ------------------ | --------------------------------- |
| 1        | WaitingPayment     | Ödeme bekleniyor                  |
| 2        | Completed          | Ödeme işlemi tamamlandı           |
| 3        | Failed             | Ödeme işlemi tamamlanamadı.       |
| 4        | WaitingCancel      | Ödeme iptali bekleniyor           |
| 5        | Cancelled          | Ödeme iptal edildi                |
| 6        | CancelFailed       | İptal işlemi yapılamadı           |
| 7        | Abandoned          | Ödeme terk edildi                 |
| 8        | CancelAbandoned    | Ödeme iptali terk edildi          |
| 9        | InProgress         | Ödeme işleminde                   |
| 10       | CompletePayment    | Ödeme alındı                      |
| 11       | FailPayment        | Ödeme başarısız                   |
| 12       | CompleteCancel     | Ödeme iptali tamamlandı           |
| 13       | FailCancel         | Ödeme iptali başarısız            |
| 14       | Abandon            | Ödeme terk ediliyor               |
| 15       | WaitingForReversal | Reversal işlemler için bekleniyor |
| 16       | CancelPending      | Ödeme iptali bekleniyor           |

