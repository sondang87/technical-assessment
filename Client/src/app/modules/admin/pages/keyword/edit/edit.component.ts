import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { KeywordService } from 'app/services/keyword.service';
import { NzModalService } from 'ng-zorro-antd/modal';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  keywordId?: string | null;
  constructor(
    private keywordService: KeywordService,
    private modal: NzModalService,
    private location: Location,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    if(route.snapshot.paramMap.get('keywordId')) {
      this.keywordId = route.snapshot.paramMap.get('keywordId');
    }
  }

  ngOnInit(): void {
  }

  save(data: any) {
    if(data) {
      this.keywordService.edit(this.keywordId, data).subscribe((res: any) => {
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
