import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzMessageModule } from 'ng-zorro-antd/message';

import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzAutocompleteModule } from 'ng-zorro-antd/auto-complete';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { KeywordComponent } from './pages/keyword/keyword.component';
import { BasicTableComponent } from './components/basic-table/basic-table.component';
import { EditComponent } from './pages/keyword/edit/edit.component';
import { AddEditKeywordComponent } from './components/add-edit-keyword/add-edit-keyword.component';
import { CreateComponent } from './pages/keyword/create/create.component';
import { SearchComponent } from './pages/search/search.component';


@NgModule({
  declarations: [
    KeywordComponent,
    BasicTableComponent,
    EditComponent,
    AddEditKeywordComponent,
    CreateComponent,
    SearchComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NzFormModule,
    NzInputModule,
    FormsModule,
    ReactiveFormsModule,
    NzGridModule,
    NzSelectModule,
    NzDividerModule,
    NzIconModule,
    NzButtonModule,
    NzTableModule,
    NzDropDownModule,
    NzModalModule,
    NzCheckboxModule,
    NzRadioModule,
    NzMessageModule,
    NzDatePickerModule,
    NzInputNumberModule,
    NzAutocompleteModule,
    NzCardModule,
    NzCollapseModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AdminModule { }
