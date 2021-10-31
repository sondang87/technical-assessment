import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class KeywordService {

  private path = environment.endPoint;
  constructor(
    private http: HttpClient
  ) { }

  getAll(): Observable<any> {
    return this.http.get(`${this.path}/keyword`);
  }

  get(id: string): Observable<any> {
      return this.http.get(`${this.path}/keyword/${id}`);
  }

  delete(id: string): Observable<any> {
      return this.http.delete(`${this.path}/keyword/${id}`);
  }

  add(model: any) {
      return this.http.post(`${this.path}/keyword/add`, model);
  }

  edit(id: string | null | undefined, model: any) {
      return this.http.put(`${this.path}/keyword/${id}`, model);
  }
  
}
