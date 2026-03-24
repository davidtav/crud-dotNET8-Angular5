import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Colaborador } from '../models/colaborador';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable()
export class ColaboradorService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getColaboradores(): Observable<Colaborador[]> {
    return this.http.get<Colaborador[]>(this.apiUrl);
  }

  addColaborador(colaborador: Colaborador): Observable<Colaborador> {
    return this.http.post<Colaborador>(this.apiUrl, colaborador);
  }

  updateColaborador(colaborador: Colaborador): Observable<any> {
    return this.http.put(`${this.apiUrl}/${colaborador.id}`, colaborador);
  }

  deleteColaborador(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}