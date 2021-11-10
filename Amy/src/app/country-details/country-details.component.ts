import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CountryDetail } from '../shared/country-detail.model';
import { CountryDetailService } from '../shared/country-detail.service';

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrls: ['./country-details.component.css']
})
export class CountryDetailsComponent implements OnInit {

  constructor(public service: CountryDetailService,
    private toastr: ToastrService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: CountryDetail){
      this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?'))
    {
    this.service.deleteCountryDetail(id)
    .subscribe(
      res=>{
        this.service.refreshList();
        this.toastr.error("Deleted successfully", 'Country Detail');
      },
      err=>{console.log(err)}
    )
    }
  }
}
