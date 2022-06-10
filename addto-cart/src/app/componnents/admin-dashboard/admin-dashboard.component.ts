import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AdminApiService } from 'src/app/services/admin-api.service';
import { AdminModel } from 'src/app/admin.model';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {

  formValue !:FormGroup;
  adminModelObj : AdminModel = new AdminModel();
  productData ! : any;
  showAdd! : boolean;
  showUpdate! : boolean;
  constructor(private formbuilder: FormBuilder,
    private api : AdminApiService) { }

  ngOnInit(): void {
    this.formValue=this.formbuilder.group({
      productId:[''],
      productName:[''],
      productImageLink:[''],
      productDescription:[''],
      productPrice:[''],
      productCategory:['']
    })
    this.getAllProducts();
  }

  clickAddProducts(){
    this.formValue.reset();
    this.showAdd=true;
    this.showUpdate=false;
  }

  postProductDetails(){
    this.adminModelObj.productName = this.formValue.value.productName;
    this.adminModelObj.productImageLink = this.formValue.value.productImageLink;
    this.adminModelObj.productDescription = this.formValue.value.productDescription;
    this.adminModelObj.productPrice = this.formValue.value.productPrice;
    this.adminModelObj.productCategory = this.formValue.value.productCategory;


    this.api.postEmployee(this.adminModelObj)
    .subscribe(res=>{
      console.log(res);
      alert("Product Added Successfully")
      let ref = document.getElementById('cancel')
      ref?.click();
      this.formValue.reset();
    },
    err=>{
      alert("Something went wrong")
    })
  }

  getAllProducts(){
    this.api.getEmployee()
    .subscribe(res=>{
      this.productData = res;
      this.getAllProducts();
    })
  }

  deleteproducts(row : any){
    this.api.deleteEmployee(row.id)
    .subscribe(res=>{
      alert("Product Deleted");
      this.getAllProducts();
    })
  }

  onEdit(row: any){
    this.showAdd=false;
    this.showUpdate=true;
    this.adminModelObj.productId = row.productId;
    this.formValue.controls['productName'].setValue(row.productName);
    this.formValue.controls['productImageLink'].setValue(row.productImageLink);
    this.formValue.controls['productDescription'].setValue(row.productDescription);
    this.formValue.controls['productPrice'].setValue(row.productPrice);
    this.formValue.controls['productCategory'].setValue(row.productCategory);
  }

  updateProductDetails(){
    this.adminModelObj.productName = this.formValue.value.productName;
    this.adminModelObj.productImageLink = this.formValue.value.productImageLink;
    this.adminModelObj.productDescription = this.formValue.value.productDescription;
    this.adminModelObj.productPrice = this.formValue.value.productPrice;
    this.adminModelObj.productCategory = this.formValue.value.productCategory;

    this.api.updateEmployee(this.adminModelObj,this.adminModelObj.productId)
    .subscribe(res=>{
      alert("Updated Successfully");
      let ref = document.getElementById("cancel")
      ref?.click();
      this.formValue.reset();
      this.getAllProducts();
    }) 
  }

}


