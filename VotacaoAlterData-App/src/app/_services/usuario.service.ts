import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { User } from '../_models/User';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

constructor(private http: HttpClient) { }
baseURL = environment.apiUrl + 'api/user/';
jwtHelper = new JwtHelperService();
decodedToken: any;


login(model: any) {
  return this.http
    .post(`${this.baseURL}login`, model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          sessionStorage.setItem('username', this.decodedToken.unique_name);
        }
      })
    );
}

register(model: any) {
  console.log('model', model);
  return this.http.post(`${this.baseURL}Register`, model);
}

adicionarUsuario(model: any) {
  console.log('model', model);
  return this.http.post(`${this.baseURL}AdicionarUsuario`, model);
}


userEdit(model: any) {
  return this.http.put(`${this.baseURL}UserEdit`, model);
}


userDisable(model: any) {
  return this.http.put(`${this.baseURL}UserDisable`, model);
}

getAllUser(): Observable<User[]> {
  return this.http.get<User[]>(`${this.baseURL}GetAllUser`);
}
}
