import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { UsersDetail } from '../shared/users-detail.model';
import { UsersDetailService } from '../shared/users-detail.service';

@Component({
  selector: 'app-users-details',
  templateUrl: './users-details.component.html',
  styleUrls: ['./users-details.component.css']
})
export class UsersDetailsComponent implements OnInit {

  constructor(public service: UsersDetailService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: UsersDetail){
      this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(UserId:number){
    if(confirm('Are you sure to delete this record?'))
    {
      this.service.deleteUsersDetail(UserId)
      .subscribe(
        res => {
            this.service.refreshList();
            this.toastr.error("Deleted successfully", 'Users detail');
        },
        err => {console.log(err)}
      )
    }
  }
}
