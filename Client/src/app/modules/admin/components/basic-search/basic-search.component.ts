import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-basic-search',
  templateUrl: './basic-search.component.html',
  styleUrls: ['./basic-search.component.scss']
})
export class BasicSearchComponent implements OnInit {
  @Output()
  onSearch = new EventEmitter();
  
  searchKeyword = "";

  constructor() { }

  ngOnInit(): void {
    this._search();
  }

  _search(): void{
    this.onSearch.emit(this.searchKeyword);
  }
}
