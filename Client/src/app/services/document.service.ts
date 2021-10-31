import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  private path = environment.endPoint;
  constructor(
    private http: HttpClient
  ) { }

  getSuggestedDocs(keyword: string): Observable<any> {
    let apiURL = `${this.path}/document/getSuggested/${keyword}`;
    return this.http.get(apiURL).pipe(map((x: any) => {
        return x.map((r: any) => ({
            documentId: r.documentId,
            documentName: r.documentName,
            checked: false
        }));
    }));
  }

  getByKeyword(keyword: string): Observable<any> {
      return this.http.get(`${this.path}/document/getByKeyword/${keyword}`);
  }
  
}
