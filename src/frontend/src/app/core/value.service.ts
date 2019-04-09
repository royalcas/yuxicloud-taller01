import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Value } from './models/value.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ValueService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<Value[]> {
    return this.http.get<Value[]>(`${environment.baseApiUrl}values`);
  }

  get(value: string): Observable<Value> {
    return this.http.get<Value>(
      `${environment.baseApiUrl}values/${encodeURIComponent(value)}`
    );
  }

  post(value: string): Observable<any> {
    return this.http.post(
      `${environment.baseApiUrl}values`,
      JSON.stringify(value)
    );
  }

  put(value: Value): Observable<any> {
    return this.http.put(
      `${environment.baseApiUrl}values/${value.id}`,
      JSON.stringify(value.value)
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${environment.baseApiUrl}values/${id}`);
  }
}
