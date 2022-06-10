import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthApiService } from 'src/app/services/auth-api.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
repeatpass: string ='none';
displayMsg : string = '';
isAccountCreated: boolean = false;

  constructor(private authapiService:AuthApiService,private router: Router) { }

  ngOnInit(): void {
  }
  registerForm = new FormGroup({
    FullName: new FormControl("",[Validators.required,
      Validators.minLength(5),Validators.maxLength(25)]),
    email: new FormControl("",[Validators.required, Validators.email]),
    mobile: new FormControl("",[Validators.required,
      Validators.minLength(10),Validators.maxLength(10),Validators.pattern("[0-9]*")]),
    birthday: new FormControl("",[Validators.required]),
    gender: new FormControl("",[Validators.required]),
    pwd: new FormControl("",[Validators.required,
      Validators.minLength(6),Validators.maxLength(10)]),
    rpwd: new FormControl(""),
    role: new FormControl("",[Validators.required]),
  });
  registerSubmited(){
    if( this.pwd.value == this.rpwd.value){
      console.log(this.registerForm.valid);
      this.repeatpass = 'none'
      this.authapiService.registerUser([
        this.registerForm.value.FullName,
        this.registerForm.value.email,
        this.registerForm.value.mobile,
        this.registerForm.value.birthday,
        this.registerForm.value.gender,
        this.registerForm.value.role,
        this.registerForm.value.pwd,

      ])
      .subscribe(res =>{
        if (res == 'Undocumented'){
          this.displayMsg = 'Account created successful!';
          this.isAccountCreated = true;
          this.router.navigateByUrl('loging')
        }else{
          this.displayMsg= 'something went wrong';
          this.isAccountCreated = false;
          this.router.navigateByUrl('loging')
        }
      })

      
      
    }
    else {
      this.repeatpass = 'inline'
    }
  }
  get FullName():  FormControl{
    return this.registerForm.get("FullName") as FormControl;
  }
  get email():  FormControl{
   return this.registerForm.get("email") as FormControl;
  }
  get mobile():  FormControl{
    return this.registerForm.get("mobile") as FormControl;
  }
  get birthday():  FormControl{
    return this.registerForm.get("birthday") as FormControl;
  }
  get gender():  FormControl{
    return this.registerForm.get("gender") as FormControl;
  }
  get pwd():  FormControl{
    return this.registerForm.get("pwd") as FormControl;
  }
  get rpwd():  FormControl{
    return this.registerForm.get("rpwd") as FormControl;
  }
  get role():  FormControl{
    return this.registerForm.get("role") as FormControl;
  }
}