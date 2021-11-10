import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CityDetail } from '../shared/city-detail.model';
import { CityDetailService } from '../shared/city-detail.service';

@Component({
  selector: 'app-city-details',
  templateUrl: './city-details.component.html',
  styleUrls: ['./city-details.component.css']
})
export class CityDetailsComponent implements OnInit {

  constructor(public service: CityDetailService,
    private toastr: ToastrService,
    private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: CityDetail){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?'))
    {
      this.service.deleteCityDetail(id)
      .subscribe(
        res=>{
          this.service.refreshList();
          this.toastr.error("Deleted Successfully", 'City Detail');
        },
        err=>{console.log(err)}
      )
    }
  }

}
