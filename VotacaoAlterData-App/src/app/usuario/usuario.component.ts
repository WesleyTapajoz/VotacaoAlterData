import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../_models/User';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from '../_services/usuario.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  constructor( public router: Router
    , public fb: FormBuilder
    , private toastr: ToastrService
    , private modalService: BsModalService
    , private usuarioService: UsuarioService) { }

    titulo = 'Usuários';
    registerForm: FormGroup;

    user: User;
    users: User[];
    modalRef: BsModalRef;


    ngOnInit() {
      this.validation();
      this.getAllUser();
    }

    getAllUser() {
      this.usuarioService.getAllUser().subscribe(
        (_user: User[]) => {
          this.users = _user;
          console.log(_user);
        }, error => {
          this.toastr.error(`Erro ao tentar Carregar: ${error}`);
        });
      }


      validation() {
        this.registerForm = this.fb.group({
          fullName: ['', Validators.required],
          email: ['', [Validators.required, Validators.email]],
          password: ['', [Validators.required, Validators.minLength(4)]]
        });
      }

      openModal(template: any) {
        this.registerForm.reset();
        template.show();
      }


      cadastrarUsuario() {
        if (this.registerForm.valid) {
          this.user = Object.assign(this.registerForm.value);
          this.usuarioService.register(this.user).subscribe(
            () => {
              this.router.navigate(['/user/login']);
              this.toastr.success('Cadastro Realizado');
            }, error => {
              const erro = error.error;
              erro.forEach(element => {
                switch (element.code) {
                  case 'DuplicateUserName':
                    this.toastr.error('Cadastro Duplicado!');
                    break;
                  default:
                    this.toastr.error(`Erro no Cadatro! CODE: ${element.code}`);
                    break;
                }
              });
            }

          );
        }
      }
      }
