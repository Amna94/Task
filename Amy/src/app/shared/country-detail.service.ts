import { Injectable } from '@angular/core';
import { CountryDetail } from './country-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CountryDetailService {

  constructor(private http:HttpClient) { }

  readonly baseUrl = 'https://localhost:44314/api/countries'
  formData: CountryDetail = new CountryDetail(); 
  list: CountryDetail[];

  postCountryDetail(){
     return this.http.post(this.baseUrl, this.formData);
  }

  putCountryDetail(id:number){
    return this.http.put(`${this.baseUrl}/${id}`, this.formData);
 }

 deleteCountryDetail(id: number){
   console.log(id);
  return this.http.delete(`${this.baseUrl}/${id}`);
 }

  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res=> this.list = res as CountryDetail[]);
  }
}
