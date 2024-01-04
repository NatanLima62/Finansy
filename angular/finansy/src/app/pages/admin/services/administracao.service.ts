import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {CadastrarViewModel} from "../models/administrador";

@Injectable({
  providedIn: 'root'
})
export class AdministracaoService {
  api = 'http://localhost:7082/';
  constructor(private http: HttpClient) { }

  cadastrarAdmin(admin: CadastrarViewModel): Observable<any>{
    return this.http.post<any>(`${this.api}v1/auth/administracao/login`, admin);
  }
}
