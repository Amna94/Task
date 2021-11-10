import { Injectable } from '@angular/core';
import { PermissionDetail } from './permission-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PermissionDetailService {

  constructor(private http: HttpClient) { }

  readonly baseURL= 'https://localhost:44314/api/permission'
  formData : PermissionDetail = new PermissionDetail();
  list : PermissionDetail[];

  postPermissionDetail(){
   return this.http.post(this.baseURL, this.formData);
  }

  putPermissionDetail(id:string){
    return this.http.put(`${this.baseURL}/${id}`, this.formData);
   }

   deletePermissionDetail(id:string){
     console.log(id);
    return this.http.delete(`${this.baseURL}/${id}`);
   }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as PermissionDetail[]);
  }
}

