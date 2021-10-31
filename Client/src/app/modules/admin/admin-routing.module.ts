import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './pages/keyword/create/create.component';
import { EditComponent } from './pages/keyword/edit/edit.component';
import { KeywordComponent } from './pages/keyword/keyword.component';
import { SearchComponent } from './pages/search/search.component';

const routes: Routes = [
  { path: '', redirectTo: 'search'},
  {
    path: 'keyword', component: KeywordComponent
  },
  {
    path: 'keyword/create', component: CreateComponent
  },
  {
    path: 'keyword/edit/:keywordId', component: EditComponent
  },
  {
    path: 'search', component: SearchComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AdminRoutingModule { }
