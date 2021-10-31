import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { KeywordService } from 'app/services/keyword.service';
import { NzModalService } from 'ng-zorro-antd/modal';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  constructor(
    private location: Location,
    private keywordService: KeywordService,
    private modal: NzModalService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  save(data: any) {
    if(data) {
      this.keywordService.add(data).subscribe((res: any) => {
        if(res && res.code === 200) {
          this.modal.success({
            nzTitle: `Info`,
            nzContent: res.message
          });
          this.router.navigateByUrl('/admin/keyword');
        } else {
          this.modal.error({
            nzTitle: `Error`,
            nzContent: res.message
          });
        }
      },
      error => {
        this.modal.error({
          nzTitle: `Error`,
          nzContent: error.error
        });
      });
    }
  }

  cancel() {
    this.location.back();
  }

}
