import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from '../models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
private readonly API = 'http://localhost:5000/api/clientes'

  constructor(private http: HttpClient) { }

  selecionarTodos(){
    return this.http.get<Cliente[]>(this.API);
  }
}
