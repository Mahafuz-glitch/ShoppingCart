import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  buttonColor = "black";
  buttonType = "buy";
  isCustomsize = 250;
  buttonHeight = 50;
  isTop = window === window.top;


  paymentRequest: google.payments.api.PaymentDataRequest ={
    apiVersion: 2,
    apiVersionMinor: 0,
    allowedPaymentMethods: [
      {
        type: 'CARD',
        parameters: {
          allowedAuthMethods: ['PAN_ONLY', 'CRYPTOGRAM_3DS'],
          allowedCardNetworks: ['AMEX', 'VISA', 'MASTERCARD']
        },
        tokenizationSpecification: {
          type: 'PAYMENT_GATEWAY',
          parameters: {
            gateway: 'example',
            gatewayMerchantI: "exampleGatewayMerchantId"
          }
        }
      }
    ],
    merchantInfo: {
      merchantId: '1234567890123456789',
      merchantName: 'Demo Merchant'
    },
    transactionInfo: {
      totalPriceStatus: 'FINAL',
      totalPriceLabel: 'Total',
      totalPrice: '200',
      currencyCode: 'INR',
      countryCode: 'IN'
    },
    callbackIntents:['PAYMENT_AUTHORIZATION']
  };
  onLoadPaymentData = (
    event: Event
  ): void => {
    const eventDetail = event as CustomEvent<google.payments.api.PaymentData>;
    console.log('load payment data',eventDetail.detail);
  }
   onPaymentDataAuthorized: google.payments.api.PaymentAuthorizedHandler = (
     paymentData
   ) => {
     console.log('payment authorized',paymentData);
     return {
       transactionState: 'SUCCESS'
     };
   }
   onError = (event: ErrorEvent): void =>
   {
     console.error('error',event.error);
   }

  constructor() { }

  ngOnInit(): void {
    
  }

}
