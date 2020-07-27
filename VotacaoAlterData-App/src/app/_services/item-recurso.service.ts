import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ItemRecurso } from '../_models/ItemRecurso';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemRecursoService {

  constructor(private http: HttpClient) { }
  baseURL = environment.apiUrl + 'api/recurso/';

  get(): Observable<ItemRecurso[]> {
    return this.http.get<ItemRecurso[]>(`${this.baseURL}`);
  }

  getById(id: number): Observable<ItemRecurso[]> {
    return this.http.get<ItemRecurso[]>(`${this.baseURL}/${id}`);
  }

}
