import { Injectable } from '@angular/core';
import { RpDetail } from './rp-detail.model';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class RpDetailService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:44314/api/RolePermission'
  formData : RpDetail = new RpDetail();
  list: RpDetail[];

  postRpDetail(){
   return this.http.post(this.baseURL, this.formData);
  }

  putRpDetail(id:string){
    return this.http.put(`${this.baseURL}/${id}`, this.formData);
   }

   deleteRpDetail(id:string){
     console.log(id);
    return this.http.delete(`${this.baseURL}/${id}`);
    
   }

    refreshList(){
      this.http.get(this.baseURL)
      .toPromise()
      .then(res => this.list = res as RpDetail[]);
    }
}
