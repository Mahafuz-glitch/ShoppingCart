import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { map } from 'rxjs/operators' 

@Injectable({
  providedIn: 'root'
})
export class AdminApiService {

  constructor(private http : HttpClient) { }

  postEmployee(data : any){
    return this.http.post<any>("http://localhost:5000/api/Product", data)
    .pipe(map((res:any)=>{
      return res;
    }))
  }

  getEmployee(){
    return this.http.get<any>("http://localhost:5000/api/Product")
    .pipe(map((res:any)=>{
      return res;
    }))
  }

  updateEmployee(data :any,id: number){
    return this.http.put<any>("http://localhost:5000/api/Product" + id,data)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
  
  deleteEmployee(id : number){
    return this.http.delete<any>("http://localhost:5000/api/Product" + id)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
}


