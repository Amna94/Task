import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UsersDetail } from 'src/app/shared/users-detail.model';
import { UsersDetailService } from 'src/app/shared/users-detail.service';

@Component({
  selector: 'app-users-detail-form',
  templateUrl: './users-detail-form.component.html',
  styleUrls: ['./users-detail-form.component.css']
})
export class UsersDetailFormComponent implements OnInit {

  constructor(public service: UsersDetailService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
      if(this.service.formData.id==0)
      
      this.insertRecord(form);
      else
      this.updateRecord(form);
      
  }

  insertRecord(form: NgForm){
    this.service.postUsersDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted successfully', 'Users details');
      },
      err => {console.log(err);}
    );
  }

  updateRecord(form: NgForm){
    this.service.putUsersDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated successfully', 'Users details');
      },
      err => {console.log(err);}
    );
  }

    resetForm(form: NgForm){
        form.form.reset();
        this.service.formData = new UsersDetail();
    }
}
