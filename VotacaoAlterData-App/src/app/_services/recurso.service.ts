import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Recurso } from '../_models/Recurso';
import { HttpClient } from '@angular/common/http';
import { Votar } from '../_models/Votar';

@Injectable({
  providedIn: 'root'
})
export class RecursoService {

  constructor(private http: HttpClient) { }
  baseURL = environment.apiUrl + 'api/recurso/';

  get(): Observable<Recurso[]> {
    return this.http.get<Recurso[]>(`${this.baseURL}GetAll`);
  }


  adicionar(model: Recurso) {
    return this.http.post(this.baseURL, model);
  }

  adicionarVoto(model: any) {
    return this.http.put(`${this.baseURL}AdicionarVoto`, model);
  }
}
