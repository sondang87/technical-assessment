import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditKeywordComponent } from './add-edit-keyword.component';

describe('AddEditKeywordComponent', () => {
  let component: AddEditKeywordComponent;
  let fixture: ComponentFixture<AddEditKeywordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditKeywordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditKeywordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
