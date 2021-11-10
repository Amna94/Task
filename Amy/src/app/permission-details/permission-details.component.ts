import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PermissionDetail } from '../shared/permission-detail.model';
import { PermissionDetailService } from '../shared/permission-detail.service';

@Component({
  selector: 'app-permission-details',
  templateUrl: './permission-details.component.html',
  styleUrls: ['./permission-details.component.css']
})
export class PermissionDetailsComponent implements OnInit {

  constructor(public service: PermissionDetailService,
    private toastr: ToastrService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.service.refreshList();
  }

  populateForm(selectedRecord: PermissionDetail){
      this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:string){
    if(confirm('Are you sure to delete this record?'))
    {
      this.service.deletePermissionDetail(id)
      .subscribe(
        res => {
            this.service.refreshList();
            this.toastr.error("Deleted Successfully", 'Permission detail');
        },
        err => {console.log(err)}
      )
    }
  }
}
