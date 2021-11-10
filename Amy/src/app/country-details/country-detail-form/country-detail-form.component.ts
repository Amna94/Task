import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CountryDetail } from 'src/app/shared/country-detail.model';
import { CountryDetailService } from 'src/app/shared/country-detail.service';

@Component({
  selector: 'app-country-detail-form',
  templateUrl: './country-detail-form.component.html',
  styleUrls: ['./country-detail-form.component.css']
})
export class CountryDetailFormComponent implements OnInit {

  constructor(public service: CountryDetailService,
    private toastr: ToastrService,
    private route:ActivatedRoute) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
      if(this.service.formData.Id==0)
      this.insertRecord(form);
      else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postCountryDetail().subscribe(
      res=>{
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Submitted Successfully', 'Country detail')
      },
      err=>{console.log(err);}
    );
  }

  updateRecord(form:NgForm){
    this.service.putCountryDetail(this.route.snapshot.params.id).subscribe(
      res=>{
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.info('Updated Successfully', 'Country detail')
      },
      err=>{console.log(err);}
    );
  }

  resetForm(form: NgForm){
    form.form.reset();
    this.service.formData = new CountryDetail();

  }

}
