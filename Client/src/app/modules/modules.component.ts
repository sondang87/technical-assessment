import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppConstant } from 'app/constants/AppConstant';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzUploadChangeParam, NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.scss']
})
export class ModulesComponent implements OnInit {
  isCollapsed = false;
  isVisible = false;
  isSelectUpload = false;
  fileList: NzUploadFile[] = [];
  uploading = false;
  appName = '';
  logo = '';
  selectedMenu = {
    parent: '',
    name:'', 
    url:''
  };

  menus: any[] = [];

  constructor(
    private router: Router,
    private msg: NzMessageService
  ) { }

  ngOnInit(): void {
    this.onInitMenu();

    const selectedMenuStr = localStorage.getItem(AppConstant.CACHED_MENU);
    if(selectedMenuStr){
      this.selectedMenu = JSON.parse(selectedMenuStr);

      if(this.selectedMenu.url != this.router.url){
        this.selectedMenu = {
          parent: '',
          name:'', 
          url:''
        };
      }
    }
  }

  onInitMenu(): void {

    this.menus = [
      {
        icon: 'tool',
        title: 'Administration',
        items:[
          {
            name: 'Keywords',
            url:'/admin/keyword',
            icon: 'unordered-list'
          },
          {
            name: 'Search',
            url:'/admin/search',
            icon: 'folder'
          }
        ]
      }
    ];
  }

  onMenuClick(item: any, parent: any){
    this.selectedMenu = {
      parent: parent.title,
      url: item.url,
      name: item.name
    }
    localStorage.setItem(AppConstant.CACHED_MENU, JSON.stringify(this.selectedMenu));
    this.router.navigateByUrl(item.url);
    
  }

  logout(): void {
    
  }

}
