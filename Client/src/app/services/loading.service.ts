import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  private _remainingRequestChannel = new BehaviorSubject<number>(0);
  private _remainingRequests: string[] = [];

  constructor() { }

  getChannel() {
    return this._remainingRequestChannel;
  }

  pushRequest(key: string) {
    this._remainingRequests.push(key);
    this._remainingRequestChannel.next(this._remainingRequests.length);
  }

  removeRequest(key: string) {
    this._remainingRequests.splice(this._remainingRequests.indexOf(key), 1);
    this._remainingRequests.length === 0 && this._remainingRequestChannel.next(0);
  }
}
