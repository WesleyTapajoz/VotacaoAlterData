import { Component, OnInit, TemplateRef } from '@angular/core';
import { Voto } from '../_models/Voto';
import { ItemRecurso } from '../_models/ItemRecurso';
import { ItemRecursoService } from '../_services/item-recurso.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RecursoService } from '../_services/recurso.service';
import { Recurso } from '../_models/Recurso';
import { Votar } from '../_models/Votar';



@Component({
  selector: 'app-votar',
  templateUrl: './votar.component.html',
  styleUrls: ['./votar.component.css']
})
export class VotarComponent implements OnInit {


  constructor(
    public itemRecursoService: ItemRecursoService
    , public router: ActivatedRoute
    , public fb: FormBuilder
    , public toastr: ToastrService
    , public modalService: BsModalService
    , private recursoService: RecursoService
    ) {
      this.recursoId = this.router.snapshot.params.id;
    }
    titulo = 'Votar';
    voto: Voto;
    votos: Voto[];
    itemRecurso: ItemRecurso = new ItemRecurso();
    itensRecursos: ItemRecurso[];
    recurso: Recurso = new Recurso();
    disabled = true;
    registerForm: FormGroup;
    modalRef: BsModalRef;
    tituloModal = '';
    recursoId: string;
    votar: Votar = new Votar();

    ngOnInit() {
      this.validation();
      this.get(this.recursoId);
    }

    validation() {
      this.registerForm = this.fb.group({
        comentario: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      });
    }

    get(id: any) {
      this.itemRecursoService.getById(id).subscribe(
        (_itemRecurso: ItemRecurso[]) => {
          this.itensRecursos = _itemRecurso;
          _itemRecurso.sort((a: any) => { return a.votos });
          console.log(this.itensRecursos);
        }, error => {
          this.toastr.error(`Erro ao tentar Carregar: ${error}`);
        });
      }
      openModal(template: TemplateRef<any>, $event){
        this.tituloModal = $event.descricao;
        this.item = Object.assign( $event );
        this.modalRef = this.modalService.show(template);
      }

      item = new  ItemRecurso();
      active: boolean = true;

      salvar() {
        this.votar = Object.assign({
          recursoId: this.item.recursoId,
          itemRecursoId: this.item.itemRecursoId,
          comentario: this.registerForm.get('comentario').value } );
          console.log(this.votar );
          this.recursoService.adicionarVoto(this.votar).subscribe(
            () => {
              this.modalRef.hide();
              this.get(this.recursoId);
              this.item.active = !this.item.active;
              this.active = false;
              this.toastr.success('Sucesso!');
            }, error => {
              this.toastr.error(`Erro:  ${error}`);
            }
            );
          }
        }
