import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RoleDetail } from '../shared/role-detail.model';
import { RoleDetailService } from '../shared/role-detail.service';

@Component({
  selector: 'app-role-details',
  templateUrl: './role-details.component.html',
  styleUrls: ['./role-details.component.css']
})
export class RoleDetailsComponent implements OnInit {

  constructor(public service: RoleDetailService,
    private toastr: ToastrService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: RoleDetail){
      this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:string) {
    if(confirm('Are you sure to delete this record?'))
    {
      this.service.deleteRoleDetail(id)
        .subscribe(
          res=> {
              this.service.refreshList();
              this.toastr.error("Deleted Successfully", 'Role details');
          },
          err=> {console.log(err)}
      )
      }
  }

}

