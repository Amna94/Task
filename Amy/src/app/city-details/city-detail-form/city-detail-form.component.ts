import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CityDetail } from 'src/app/shared/city-detail.model';
import { CityDetailService } from 'src/app/shared/city-detail.service';

@Component({
  selector: 'app-city-detail-form',
  templateUrl: './city-detail-form.component.html',
  styleUrls: ['./city-detail-form.component.css']
})
export class CityDetailFormComponent implements OnInit {

  constructor(public service: CityDetailService,
    private toastr:ToastrService,
    private route:ActivatedRoute) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
      if(this.service.formData.Id == 0)
      this.insertRecord(form);
      else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){

    this.service.postCityDetail().subscribe(
      res=> {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Submitted Successfully', 'City Detail')
      },
      err=> { console.log(err); }
    );
  }

  updateRecord(form:NgForm){

    this.service.putCityDetail(this.route.snapshot.params.id).subscribe(
      res=> {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.info('Updated Successfully', 'City Detail')
      },
      err=> { console.log(err); }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new CityDetail();
  }

}
