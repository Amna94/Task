import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RoleDetail } from 'src/app/shared/role-detail.model';
import { RoleDetailService } from 'src/app/shared/role-detail.service';

@Component({
  selector: 'app-role-detail-form',
  templateUrl: './role-detail-form.component.html',
  styleUrls: ['./role-detail-form.component.css']
})
export class RoleDetailFormComponent implements OnInit {

  constructor(public service : RoleDetailService,
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
    this.service.postRoleDetail().subscribe(
      res => {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Submitted Successfully', 'Role detail')
      },
      err => {console.log(err);}
    );
  }

  updateRecord(form: NgForm){
    this.service.putRoleDetail(this.route.snapshot.params.id).subscribe(
      res => {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.info('Updated Successfully', 'Role detail')
      },
      err => {console.log(err);}
    );

  }

    resetForm(form: NgForm){
        form.form.reset();
        this.service.formData = new RoleDetail();
    }
}
