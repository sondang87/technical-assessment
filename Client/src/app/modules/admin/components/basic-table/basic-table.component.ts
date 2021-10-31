import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { AdminTableAction, DataTableService, TableHeaderColumnConfig } from 'app/components/data-table/dataTable.service';

@Component({
  selector: 'app-basic-table',
  templateUrl: './basic-table.component.html',
  styleUrls: ['./basic-table.component.scss']
})
export class BasicTableComponent implements OnInit {

  tableHeaderColumns: Array<TableHeaderColumnConfig> = [];
  listOfData: any[] = [];
  tableActions: any[] = [];
  tableAction = AdminTableAction;

  constructor(private tableService: DataTableService) { }
  
  ngOnInit(): void {
    this.tableService.TableColumns.subscribe(e => {
      this.tableHeaderColumns = e.filter(e => e.isVisible);
    });
    this.tableService.TableDataSource.subscribe(e => {
      this.listOfData = e;
    });
    this.tableService.TableActions.subscribe(e => {
      this.tableActions = e;
    });
  }

  onRowAction(mode: any, data: any){
    this.tableService.OnRowClick.emit({ mode: mode, data: data });
  }
  onRowDblClick(data: any){
    this.tableService.OnRowDblClick.emit({ data });
  }
}
