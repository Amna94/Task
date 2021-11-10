import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PermissionDetail } from 'src/app/shared/permission-detail.model';
import { PermissionDetailService } from 'src/app/shared/permission-detail.service';

@Component({
  selector: 'app-permission-detail-form',
  templateUrl: './permission-detail-form.component.html',
  styleUrls: ['./permission-detail-form.component.css']
})
export class PermissionDetailFormComponent implements OnInit {

  constructor(public service: PermissionDetailService,
    private toastr: ToastrService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
      if(this.service.formData.Id)
      this.insertRecord(form);
      else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm){

    this.service.postPermissionDetail().subscribe(
      res => {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Submitted successfully', 'Permission detail')
      },
      err => {console.log(err);}
    );
  }

  updateRecord(form: NgForm){

    this.service.putPermissionDetail(this.route.snapshot.params.id).subscribe(
      res => {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.info('Updated successfully', 'Permission detail')
      },
      err => {console.log(err);}
    );
  }

  resetForm(form: NgForm){
    form.form.reset();
    this.service.formData = new PermissionDetail();
  }
}
