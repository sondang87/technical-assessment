import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminTableAction, DataTableService, RowClickInfo, TableHeaderColumnConfig } from 'app/components/data-table/dataTable.service';
import { AppConstant } from 'app/constants/AppConstant';
import { KeywordService } from 'app/services/keyword.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-keyword',
  templateUrl: './keyword.component.html',
  styleUrls: ['./keyword.component.scss']
})
export class KeywordComponent implements OnInit {
  searchKeyword = "";
  onRowClickSub:Subscription | undefined;
  onRowDblClickSub:Subscription | undefined;
  getSub?: Subscription;
  constructor(
    private keywordService: KeywordService,
    private tableService: DataTableService,
    private router: Router,
    private modal: NzModalService
  ) { }

  ngOnInit(): void {
    this.onRenderColumn();
    this.onRowClickSub = this.tableService.OnRowClick.subscribe((e: RowClickInfo) => {
      this.doRowClickAction(e);
    });
    this.onRowDblClickSub = this.tableService.OnRowDblClick.subscribe((e: RowClickInfo) => {
      this.doRowDblClickAction(e);
    });

    this.getAll();
  }

  ngOnDestroy(): void {
    this.onRowClickSub?.unsubscribe();
    this.onRowDblClickSub?.unsubscribe();
    this.getSub?.unsubscribe();
  }

  getAll(): void {
    this.getSub = this.keywordService.getAll().subscribe(data => {
      this.tableService.dispatchData(data);
    });
  }

  delete(id: string): void {
    this.keywordService.delete(id).subscribe(res => {
      const resObj = res as any;
      if(resObj.code != 200){
        this.modal.error({
          nzTitle: `Error`,
          nzContent: resObj.message
        });
      }
      else{
        this.modal.success({
          nzTitle: `Info`,
          nzContent: resObj.message
        });
        this.getAll();
      }
    });
  }

  onRenderColumn(): void {
    const columns: TableHeaderColumnConfig[] = [
      {
        name: 'Keyword',
        sortOrder: null,
        isVisible: true,
        sortFn: (a: any, b: any) => a.name.localeCompare(b.name),
        sortDirections: ['ascend', 'descend', null],
        orderIndex: 0,
        bindingModel: 'value'
      },
      {
        name: 'Last Modified',
        sortOrder: null,
        isVisible: true,
        sortFn: (a: any, b: any) => a.name.localeCompare(b.name),
        sortDirections: ['ascend', 'descend', null],
        orderIndex: 4,
        bindingModel: 'updatedOn'
      }
    ];
    this.tableService.dispatchData(undefined, columns);
    this.tableService.TableActions.next([AdminTableAction.Edit, AdminTableAction.Delete]);
  }

  private doRowClickAction(eventInfo: RowClickInfo) {
    const id = eventInfo.data.keywordId;
    switch (eventInfo.mode) {
      case AdminTableAction.Edit:
        this.navigateEdit(id);
        break;
      case AdminTableAction.Delete:
        this.confirmDialog(id);
        break;
      default:
        break;
    }
  }

  private doRowDblClickAction(eventInfo: RowClickInfo){
    this.navigateEdit(eventInfo.data.keywordId);
  }

  private navigateEdit(id: any): void{
    this.router.navigateByUrl(`/admin/keyword/edit/${id}`)
  }

  private confirmDialog(id: any): void{
    this.modal.confirm({
      nzTitle: AppConstant.CONFIRM_TO_DELETE,
      nzContent: AppConstant.DELETE_SELECTED_ITEM,
      nzOnOk: () => {
        this.delete(id);
      }
    });
  }

}
