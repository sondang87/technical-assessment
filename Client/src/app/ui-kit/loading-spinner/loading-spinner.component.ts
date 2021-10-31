import { Component, OnInit } from '@angular/core';
import { LoadingService } from 'app/services/loading.service';

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrls: ['./loading-spinner.component.scss']
})
export class LoadingSpinnerComponent implements OnInit {

  constructor(public loading: LoadingService) { }

  ngOnInit(): void {
  }

}
