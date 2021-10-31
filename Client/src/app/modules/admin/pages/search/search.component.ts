import { Component, OnInit } from '@angular/core';
import { DataTableService, TableHeaderColumnConfig } from 'app/components/data-table/dataTable.service';
import { DocumentService } from 'app/services/document.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  searchKeyword = "";
  constructor(
    private documentService: DocumentService,
    private tableService: DataTableService
  ) { }

  ngOnInit(): void {
    this.onRenderColumn();
    this.tableService.dispatchData([]);
    this.tableService.TableActions.next([]);
    //this._search();
  }

  _search() {
    if(this.searchKeyword) {
      this.documentService.getByKeyword(this.searchKeyword).subscribe(res => {
        this.tableService.dispatchData(res);
      });
    }
    
  }

  onRenderColumn(): void {
    const columns: TableHeaderColumnConfig[] = [
      {
        name: 'Document Name',
        sortOrder: null,
        isVisible: true,
        sortFn: (a: any, b: any) => a.name.localeCompare(b.name),
        sortDirections: ['ascend', 'descend', null],
        orderIndex: 0,
        bindingModel: 'documentName'
      }
    ];
    this.tableService.dispatchData(undefined, columns);
  }

}
