import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/User';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/_services/usuario.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;
  user: User;

  constructor(private authService: AuthService
    , public router: Router
    , public fb: FormBuilder
    , private toastr: ToastrService
    , private usuarioService: UsuarioService) {
  }

  ngOnInit() {
    this.validation();
  }

  validation() {
    this.registerForm = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4)]],
    });
  }

  cadastrarUsuario() {
    if (this.registerForm.valid) {
      this.user = Object.assign(
        { password: this.registerForm.get('password').value },
        this.registerForm.value);
      this.usuarioService.register(this.user).subscribe(
        () => {
          this.router.navigate(['/usuarios']);
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
