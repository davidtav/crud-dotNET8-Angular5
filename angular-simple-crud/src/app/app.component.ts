import { Component, OnInit } from '@angular/core';
import { Colaborador } from './models/colaborador';
import { ColaboradorService } from './services/colaborador.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  colaboradorArray: Colaborador[] = [];
  selectedColaborador: Colaborador = {
    id: 0,
    name: '',
    country: ''
  };

  constructor(private service: ColaboradorService) {}

  ngOnInit() {
    this.listarTodos();
  }

  listarTodos() {
    this.service.getColaboradores().subscribe({
      next: (data) => (this.colaboradorArray = data),
      error: (err) => console.error('Erro ao buscar colaboradores', err)
    });
  }

  salvarColaborador() {
    console.log('selectedColaborador:', this.selectedColaborador);

    const operacao$ =
      this.selectedColaborador.id === 0
        ? this.service.addColaborador(this.selectedColaborador)
        : this.service.updateColaborador(this.selectedColaborador);

    operacao$.subscribe({
      next: () => {
        this.listarTodos();
        this.selectedColaborador = {
          id: 0,
          name: '',
          country: ''
        };
      },
      error: (err) => console.error('Erro ao salvar colaborador', err)
    });
  }

  editarColaborador(colaborador: Colaborador) {
    this.selectedColaborador = { ...colaborador };
  }

  excluirColaborador(colaborador: Colaborador) {
    if (!confirm(`Deseja realmente excluir ${colaborador.name}?`)) {
      return;
    }

    this.service.deleteColaborador(colaborador.id).subscribe({
      next: () => {
        this.listarTodos();
        this.selectedColaborador = {
          id: 0,
          name: '',
          country: ''
        };
      },
      error: (err) => console.error('Erro ao excluir colaborador', err)
    });
  }

  limparColaborador() {
    this.selectedColaborador = {
      id: 0,
      name: '',
      country: ''
    };
  }
}