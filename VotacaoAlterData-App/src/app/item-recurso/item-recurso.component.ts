import { Component, OnInit } from '@angular/core';
import { ItemRecurso } from '../_models/ItemRecurso';
import { ItemRecursoService } from '../_services/item-recurso.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-item-recurso',
  templateUrl: './item-recurso.component.html',
  styleUrls: ['./item-recurso.component.css']
})
export class ItemRecursoComponent implements OnInit {

  constructor(public itemRecursoService: ItemRecursoService
    , public router: ActivatedRoute
    , public fb: FormBuilder
    , public toastr: ToastrService ) {
      this.recursoId = this.router.snapshot.params.id;
    }
    titulo = 'Tarefas';
    itemRecurso: ItemRecurso = new ItemRecurso();
    itensRecursos: ItemRecurso[];

    recursoId: string;

    ngOnInit() {
      this.get(this.recursoId);
    }

    get(id: any) {
      this.itemRecursoService.getById(id).subscribe(
        (_itemRecurso: ItemRecurso[]) => {
          this.itensRecursos = _itemRecurso;
          console.log(this.itensRecursos);
        }, error => {
          this.toastr.error(`Erro ao tentar Carregar: ${error}`);
        });
      }

    }
