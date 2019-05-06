import { Component, OnInit } from '@angular/core';
import { Cliente } from '../..//models/cliente';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css'],
  preserveWhitespaces: true
})
export class ClientListComponent implements OnInit {
  clientes: Cliente[];

  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
    this.clienteService.selecionarTodos().subscribe(dados => this.clientes = dados);
  }

}
