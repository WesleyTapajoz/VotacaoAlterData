import { Component, OnInit, TemplateRef } from '@angular/core';
import { Recurso } from '../_models/Recurso';
import { ItemRecurso } from '../_models/ItemRecurso';
import { FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ActivatedRoute  } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RecursoService } from '../_services/recurso.service';


@Component({
  selector: 'app-recurso',
  templateUrl: './recurso.component.html',
  styleUrls: ['./recurso.component.css']
})
export class RecursoComponent implements OnInit {
  titulo = 'Recurso';
  recurso: Recurso = new Recurso();
  recursos: Recurso[];
  itemRecurso = new ItemRecurso();
  registerForm: FormGroup;

  modalRef: BsModalRef;

  get itensRecurso(): FormArray {
    return <FormArray>this.registerForm.get('itensRecurso');
  }

  constructor( public router: ActivatedRoute
    , public fb: FormBuilder
    , private toastr: ToastrService
    , private modalService: BsModalService
    , private recursoService: RecursoService
    ) { }

    ngOnInit() {
      this.validation();
      this.get();
    }


    openModal(template: TemplateRef<any>){
      this.registerForm.patchValue(new ItemRecurso());
      this.modalRef = this.modalService.show(template);
    }

    get() {
      this.recursoService.get().subscribe(
        (_recurso: Recurso[]) => {
          this.recursos = _recurso;
          if(this.recurso.itensRecurso !== undefined){
            this.recurso.itensRecurso.forEach(item => {
              this.itensRecurso.push(this.criaItemRecurso(item));
            });
          }

        }, error => {
          this.toastr.error(`Erro ao tentar Carregar: ${error}`);
        });
      }

      validation() {
        this.registerForm = this.fb.group({
          descricao: ['', Validators.required],
          itensRecurso: this.fb.array([]),
        });
      }


      criaItemRecurso(itemRecurso: any): FormGroup {
        return this.fb.group({
          recursoId: [itemRecurso.recursoId],
          descricao: [itemRecurso.descricao, Validators.required]
        });
      }

      adicionarItemRecruso() {
        this.itensRecurso.push(this.criaItemRecurso({ recursoId: 0 }));
      }

      removerItemRecurso(recursoId: number) {
        this.itensRecurso.removeAt(recursoId);
      }

      salvar() {
        this.recurso = Object.assign( this.registerForm.value);
        console.log(this.recurso);

        this.recursoService.adicionar(this.recurso).subscribe(
          () => {
            this.modalRef.hide();
            this.get();
            this.toastr.success('Sucesso!');
          }, error => {
            this.toastr.error(`Erro:  ${error}`);
          }
          );
        }

      }
