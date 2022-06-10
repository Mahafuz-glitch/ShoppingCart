import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthApiService } from 'src/app/services/auth-api.service';


@Component({
  selector: 'app-loging',
  templateUrl: './loging.component.html',
  styleUrls: ['./loging.component.css']
})
export class LogingComponent implements OnInit {

  constructor(private loginAuth: AuthApiService, private router: Router) { }

  ngOnInit(): void {
  }
  loginForm = new FormGroup({
    email: new FormControl("",[Validators.required, Validators.email]),
    pwd: new FormControl("",[
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(10),
    ]),

  });
   isUservalid: boolean = false;

  loginSubmited(){
    this.loginAuth.loginUser([this.loginForm.value.email,this.loginForm.value.pwd]).subscribe(
      res =>{
        if (res == 'Failure'){
          this.isUservalid = false;
          alert('login unsuccessful');
        } else{
          this.isUservalid = true;
          alert('login successful');
          this.router.navigateByUrl('products')
        }
      }
    );
  }
  get emailId(): FormControl {
    return this.loginForm.get('email') as FormControl;
  }
  get profilePassword(): FormControl {
    return this.loginForm.get('pwd') as FormControl;
  }

}
