import { Injectable } from '@angular/core';
import { CityDetail } from './city-detail.model';
import {HttpClient} from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class CityDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44314/api/cities'
  formData: CityDetail = new CityDetail();
  list : CityDetail[];

  postCityDetail(){
   return this.http.post(this.baseURL, this.formData);
  }

  putCityDetail(id:number){
    return this.http.put(`${this.baseURL}/${id}`, this.formData);
   }

   deleteCityDetail(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
   }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res=> this.list = res as CityDetail[]);
  }
}
