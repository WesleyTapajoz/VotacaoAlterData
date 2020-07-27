import { Component, OnInit } from '@angular/core';
import { ItemRecurso } from '../_models/ItemRecurso';
import { ItemRecursoService } from '../_services/item-recurso.service';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-item-recurso',
  templateUrl: './item-recurso.component.html',
  styleUrls: ['./item-recurso.component.css']
})
export class ItemRecursoComponent implements OnInit {

  constructor(public itemRecursoService: ItemRecursoService
    , public router: Router
    , public fb: FormBuilder
    , public toastr: ToastrService ) { }
    titulo = 'Tarefas';
    itemRecurso: ItemRecurso = new ItemRecurso();
    itensRecursos: ItemRecurso[];
    ngOnInit() {
    }

    get() {
      this.itemRecursoService.get().subscribe(
        (_itemRecurso: ItemRecurso[]) => {
          this.itensRecursos = _itemRecurso;
        }, error => {
          this.toastr.error(`Erro ao tentar Carregar: ${error}`);
        });
      }

    }
