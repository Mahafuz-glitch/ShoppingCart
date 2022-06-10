import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AuthApiService {
       

  constructor(private http: HttpClient) {}

  baseServerUrl = 'http://localhost:5000/api/Authentication/';

  loginUser(loginInfo: Array<String>){
    return this.http.post(
      this.baseServerUrl + 'Login',
      {
        emailId: loginInfo[0],
        profilePassword: loginInfo[1],
      },
      {
        responseType: 'text',
      }
    );
  }
  registerUser(register: Array<String>){
    return this.http.post(this.baseServerUrl + 'Register',
    {
      fullName:register[0],
      emailId:register[1],
      mobileNumber:register[2],
      dateOfBirth:register[3],
      gender:register[4],
      profileRole:register[5],
      profilePassword:register[6],

      responseType:'text',
    });
  }
  

}
