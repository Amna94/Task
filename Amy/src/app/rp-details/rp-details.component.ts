import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RpDetail } from '../shared/rp-detail.model';
import { RpDetailService } from '../shared/rp-detail.service';

@Component({
  selector: 'app-rp-details',
  templateUrl: './rp-details.component.html',
  styleUrls: ['./rp-details.component.css']
})
export class RpDetailsComponent implements OnInit {

  constructor(public service: RpDetailService,
    private toastr: ToastrService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.service.refreshList();
  }
    
  populateForm(selectedRecord: RpDetail){
      this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:string){
    if(confirm('Are you sure to delete this record?'))
    {
     this.service.deleteRpDetail(id)
      .subscribe(
        res => {
            this.service.refreshList();
            this.toastr.error("Deleted Successfully", 'RolePermission detail')
        },
        err => {console.log(err);
        }
        
      )
    }
  }
}
