import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartapiService {
  cartDataList:any =[];
  productList= new BehaviorSubject<any>([]);


  constructor(private http:HttpClient) { }
  getProductData(){
    return this.productList.asObservable();
  }
  setProduct(product:any){
    this.cartDataList.push(...product);
    this.productList.next(product)
  }
  addToCart(product:any){
    this.cartDataList.push(product);
    this.productList.next(this.cartDataList);
    this.getTotalAmount();
    console.log(this.cartDataList)
  }
  getTotalAmount():number{
    let grandTotal =0;
    this.cartDataList.map((a:any)=>{
      grandTotal += a.productPrice;
    })
    return grandTotal
  }
  removeCartData(product:any){
    this.cartDataList.map((a:any, index:any)=>{
      if(product.id === a.id){
        this.cartDataList.splice(index,1)
      }
    })
    this.productList.next(this.cartDataList)
      
    
  }
  removeAllCart(){
    this.cartDataList =[]
    this.productList.next(this.cartDataList)
  }
}
