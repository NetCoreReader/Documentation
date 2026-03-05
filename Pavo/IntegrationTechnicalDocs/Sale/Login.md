# Login:

#### Servis Giriş Parametreleri:

| Alan                         | Tip     | Zorunlu mu | Açıklama                              |
| ---------------------------- | ------- | ---------- | ------------------------------------- |
| LoginInfo                    | Object  |            | Giriş bilgilerini içeren model        |
| &ensp;UserName               | string  | E          | Kullanıcı adı                         |
| &ensp;Password               | string  | E          | Kullanıcı şifresi                     |
| &ensp;EnabledOTPVerification | boolean |            | OTP doğrulama aktif ya da pasif seçme |

#### Örnek Servis İsteği:

```json
{
    "LoginInfo":{
        "UserName":"xxx",
        "Password":"xxx",
        "EnabledOTPVerification":false
    }
}
```

Not: Rest isteklerinde transaction handle gereklidir.

#### Başarılı Servis Cevabı:

```json
{
    "HasError": false,
    "ErrorCode": null,
    "Message": null,
    "Data": {
        "LoginResult": "Giriş Başarılı"
    }
}
```



#### Başarısız Servis Cevabı:

```json
{
    "HasError": true,
    "ErrorCode": 83, // UnAuthorized User Error Code
    "Message": "Kullanıcı yetkisiz",
    "Data": null
}
```

#### Login Hata Kodları:

```json
  invalidUserName, //79
  invalidPassword, //80
  loginfailed, //81
  userAlreadyAuthenticated, //82
  userUnAuthorized, //83
```













