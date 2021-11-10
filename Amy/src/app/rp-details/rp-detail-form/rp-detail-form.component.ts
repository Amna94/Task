import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { from } from 'rxjs';
import { RpDetail } from 'src/app/shared/rp-detail.model';
import { RpDetailService } from 'src/app/shared/rp-detail.service';

@Component({
  selector: 'app-rp-detail-form',
  templateUrl: './rp-detail-form.component.html',
  styleUrls: ['./rp-detail-form.component.css']
})
export class RpDetailFormComponent implements OnInit {

  constructor(public service: RpDetailService,
    private toastr: ToastrService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
      if(this.service.formData.role_id)
      this.insertRecord(form);
      else
      if(this.service.formData.permission_id)
      this.updateRecord(form);
  }

  insertRecord(form: NgForm){
    this.service.postRpDetail().subscribe(
      res => {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Submitted Successfully', 'RolePermission detail');
      },
      err => {console.log(err);}
    );
  }

  updateRecord(form:NgForm){
    this.service.putRpDetail(this.route.snapshot.params.id).subscribe(
      res => {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.info('Updated Successfully', 'RolePermission detail');
      },
      err => {console.log(err);}
    );
  }

    resetForm(form: NgForm){
        form.form.reset();
        this.service.formData = new RpDetail();
    }
}
