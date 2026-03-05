import 'dart:async';
import 'dart:convert';
import 'dart:typed_data';

import 'package:flutter/material.dart' hide Intent;
import 'package:flutter/services.dart';
import 'package:receive_intent/receive_intent.dart';

import 'package:android_intent_plus/android_intent.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatefulWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  Intent? _initialIntent;
  // ignore: unused_field
  late StreamSubscription _intentSubscription;
  final package = 'tr.com.overtech.overpay_pos_demo';
  void _completeSale() async {
    final intent = AndroidIntent(
      action: 'pavopay.intent.action.complete.sale',
      type: 'application/json',
      package: package,
      flags: [0x10000000], //FLAG_ACTIVITY_NEW_TASK
      arguments: <String, dynamic>{
        "Sale": jsonEncode({
          "MainDocumentType": 1,
          "RefererApp": "Sistem Pos",
          "RefererAppVersion": "1",
          "GrossPrice": 41,
          "TotalPrice": 41,
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
              "ItemQuantity": 1.0,
              "UnitPriceAmount": 5,
              "GrossPriceAmount": 5,
              "TotalPriceAmount": 5
            },
            {
              "Name": "BURN ENERGY KUTU 250",
              "IsGeneric": false,
              "UnitCode": "KGM",
              "TaxGroupCode": "KDV1",
              "ItemQuantity": 1.0,
              "UnitPriceAmount": 16.5,
              "GrossPriceAmount": 16.5,
              "TotalPriceAmount": 16.5
            },
            {
              "Name": "BARDAK ÇAY",
              "IsGeneric": false,
              "UnitCode": "KGM",
              "TaxGroupCode": "KDV1",
              "ItemQuantity": 1.0,
              "UnitPriceAmount": 4.1,
              "GrossPriceAmount": 4.1,
              "TotalPriceAmount": 4.1
            },
            {
              "Name": "AYRAN",
              "IsGeneric": false,
              "UnitCode": "KGM",
              "TaxGroupCode": "KDV1",
              "ItemQuantity": 1.0,
              "UnitPriceAmount": 4.4,
              "GrossPriceAmount": 4.4,
              "TotalPriceAmount": 4.4
            },
            {
              "Name": " LİMONLU SODA",
              "IsGeneric": false,
              "UnitCode": "KGM",
              "TaxGroupCode": "KDV1",
              "ItemQuantity": 2.0,
              "UnitPriceAmount": 5.5,
              "GrossPriceAmount": 11.0,
              "TotalPriceAmount": 11.0
            }
          ],
        }),
      },
    );

    intent.launch();
  }

  void _cancelSale() async {
    final data = jsonDecode(_initialIntent?.extra?['Data']);
    final saleId = data['Id'];
    final saleNumber = data['SaleNumber'];
    final isOffline = data['IsOffline'];
    final intent = AndroidIntent(
      action: 'pavopay.intent.action.cancel.sale',
      type: 'application/json',
      package: package,
      flags: [0x10000000], //FLAG_ACTIVITY_NEW_TASK
      arguments: <String, dynamic>{
        'Sale': jsonEncode(
          {
            'Id': saleId,
            'SaleNumber': saleNumber,
            'IsOffline': isOffline,
          },
        ),
      },
    );

    intent.launch();
  }

  void _viewSale() async {
    final data = jsonDecode(_initialIntent?.extra?['Data']);
    final saleId = data['Id'];
    final saleNumber = data['SaleNumber'];
    final intent = AndroidIntent(
      action: 'pavopay.intent.action.completed.sale',
      type: 'application/json',
      package: package,
      flags: [0x10000000], //FLAG_ACTIVITY_NEW_TASK
      arguments: <String, dynamic>{
        'Sale': jsonEncode(
          {
            'Id': saleId,
            'SaleNumber': saleNumber,
          },
        ),
      },
    );

    intent.launch();
  }

  void _paymentMediators() async {
    final intent = AndroidIntent(
      action: 'pavopay.intent.action.get.mediators',
      type: 'application/json',
      package: package,
      flags: [0x10000000], //FLAG_ACTIVITY_NEW_TASK
    );

    intent.launch();
  }

  void _printOut() async {
    ByteData bytes = await rootBundle.load('assets/images/temp.png');
    var buffer = bytes.buffer;
    var image = base64.encode(Uint8List.view(buffer));
    final intent = AndroidIntent(
      action: 'pavopay.intent.action.print.out',
      type: 'application/json',
      package: package,
      flags: [0x10000000], //FLAG_ACTIVITY_NEW_TASK
      arguments: <String, dynamic>{
        'Print': jsonEncode(
          {
            'Image': image,
          },
        ),
      },
    );
    intent.launch();
  }

  Future<String> readJson() async {
    final String response = await rootBundle.loadString('assets/sample.json');
    return response;
  }

  @override
  void initState() {
    super.initState();
    _init();
  }

  Future<void> _init() async {
    // ignore: unused_local_variable
    final receivedIntent = await ReceiveIntent.getInitialIntent();

    _intentSubscription =
        ReceiveIntent.receivedIntentStream.listen((Intent? intent) {
      if (intent != null) {
        setState(() {
          _initialIntent = intent;
        });
      }
    }, onError: (err) {});
  }

  Widget _buildFromIntent(String label, Intent? intent) {
    return Center(
      child: Column(
        children: [
          SizedBox(
            height: 100,
            child: SingleChildScrollView(
              child: Text("${_initialIntent?.extra ?? 'Hoş Geldiniz!'}"),
            ),
          ),
          ElevatedButton(
            onPressed: _completeSale,
            child: const Text('Satış'),
          ),
          ElevatedButton(
            onPressed: _cancelSale,
            child: const Text('Satış İptal'),
          ),
          ElevatedButton(
            onPressed: _viewSale,
            child: const Text('Satış Görüntüle'),
          ),
          ElevatedButton(
            onPressed: _paymentMediators,
            child: const Text('Ödeme Aracıları'),
          ),
          ElevatedButton(
            onPressed: _printOut,
            child: const Text('Fiş Yazdır'),
          ),
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Plugin example app'),
        ),
        body: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 20),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              _buildFromIntent("INITIAL", _initialIntent),
            ],
          ),
        ),
      ),
    );
  }
}
