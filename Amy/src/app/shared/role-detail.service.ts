import { Injectable } from '@angular/core';
import { RoleDetail } from './role-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RoleDetailService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:44314/api/roles'
  formData: RoleDetail = new RoleDetail();
  list : RoleDetail[];

  postRoleDetail(){
  return this.http.post(this.baseURL, this.formData);
  }

  putRoleDetail(id:string){
    return this.http.put(`${this.baseURL}/${id}`, this.formData);
    }

  deleteRoleDetail(id:string){
    console.log(id);
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as RoleDetail[]);
  }
}
