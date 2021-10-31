import { EventEmitter, Injectable } from "@angular/core";
import { NzTableFilterFn, NzTableFilterList, NzTableSortFn, NzTableSortOrder } from "ng-zorro-antd/table";
import { BehaviorSubject } from "rxjs";

export enum TableRowAction {
    View = 1,
    Open,
    Download,
    Note,
    Version,
    Replace,
    Delete
}

export enum AdminTableAction {
    View = 1,
    Edit,
    Delete
}

export interface TableHeaderColumnConfig extends HeaderColumnItem {
    isVisible?: boolean;
    isSortable?: boolean;
    name: string;
    orderIndex: number;
    bindingModel: string;
  }
  
export interface HeaderColumnItem {
    sortOrder: NzTableSortOrder;
    sortFn: NzTableSortFn;
    listOfFilter?: NzTableFilterList;
    filterFn?: NzTableFilterFn | null;
    filterMultiple?: boolean;
    sortDirections: NzTableSortOrder[];
}

export interface RowClickInfo {
    mode: any,
    data: any,
    row: number
}

@Injectable({
    providedIn: 'root'
})

export class DataTableService {
    //@ts-ignore
    public TableColumns: BehaviorSubject<Array<TableHeaderColumnConfig>> = new BehaviorSubject([]);
    //@ts-ignore
    public TableDataSource: BehaviorSubject<any[]> = new BehaviorSubject([]);
    public OnRowClick: EventEmitter<any> = new EventEmitter();
    public OnRowDblClick: EventEmitter<any> = new EventEmitter();
    //@ts-ignore
    public TableActions: BehaviorSubject<any[]> = new BehaviorSubject([]);
    /**
     *
     */
    constructor() {
    }

    dispatchData(data?: any[], columns?: TableHeaderColumnConfig[]) {
        if (data != undefined) {
            this.TableDataSource.next(data);
        }

        if (columns != undefined) {
            this.TableColumns.next(columns);
        }
    }
}