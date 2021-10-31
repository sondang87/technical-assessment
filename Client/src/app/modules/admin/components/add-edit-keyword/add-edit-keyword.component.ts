import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DocumentService } from 'app/services/document.service';
import { KeywordService } from 'app/services/keyword.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-edit-keyword',
  templateUrl: './add-edit-keyword.component.html',
  styleUrls: ['./add-edit-keyword.component.scss']
})
export class AddEditKeywordComponent implements OnInit, OnDestroy {
  allChecked = false;
  indeterminate = false;
  displayData: any[] = [];
  documents: any[] = [];
  getDocSub?: Subscription;
  getKeywordSub?: Subscription;
  form!: FormGroup;
  invalidKeyword = false;
  @Input() keywordId?: string | null;
  @Output() onCancel = new EventEmitter();
  @Output() onSave = new EventEmitter();
  constructor(
    private docService: DocumentService,
    private keywordService: KeywordService,
    private fb: FormBuilder
  ) { }

  ngOnDestroy(): void {
    this.getDocSub?.unsubscribe();
    this.getKeywordSub?.unsubscribe();
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      value: ['', Validators.required],
      documentIds: []
    });
  }

  ngAfterViewChecked() {
    if(this.keywordId) {
      this.getKeywordById();
    }
  }

  currentPageDataChange($event: any): void {
    this.displayData = $event;
    this.refreshStatus();
  }

  refreshStatus(): void {
    const allChecked = this.displayData.every(value => value.checked === true);
    const allUnChecked = this.displayData.every(value => !value.checked);
    this.allChecked = allChecked;
    this.indeterminate = (!allChecked) && (!allUnChecked);
    const selected = this.documents.filter(value => value.checked === true);
    const documentIds = new Array();
    selected.forEach(e => {
      documentIds.push(e.documentId)
    })
    this.form.controls['documentIds'].setValue(documentIds);
  }

  checkAll(value: boolean): void {
    this.displayData.forEach(data => {
      data.checked = value;
    });
    this.refreshStatus();
  }

  cancel() {
    this.onCancel.emit();
  }

  saveChanges() {
    for(const c in this.form.controls) {
      this.form.controls[c].markAsDirty();
      this.form.controls[c].updateValueAndValidity();
    }
    if(this.form.valid) {
      this.onSave.emit(this.form.value);
    }
  }

  validateKeyword() {
    this.invalidKeyword = false;
    this.getDocSub = this.docService.getSuggestedDocs(this.form.controls['value'].value).subscribe(res => {
      this.documents = res;
    });
  }

  getKeywordById() {
    if(this.keywordId) {
      this.getKeywordSub = this.keywordService.get(this.keywordId).subscribe(res => {
        if(res) {
          this.form.patchValue(res);
          this.documents.forEach(data => {
            if(res.documentIds && res.documentIds.includes(data.documentId))
              data.checked = true;
          });
          this.refreshStatus();
        }
      });
    }
  }

}
