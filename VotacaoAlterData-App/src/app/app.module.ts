import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';
import { UserComponent } from './user/user.component';
import { TituloComponent } from './_shared/titulo/titulo.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { UsuarioComponent } from './usuario/usuario.component';
import { NgxMaskModule, IConfig  } from 'ngx-mask';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { UsuarioService } from './_services/usuario.service';
import { VotarComponent } from './votar/votar.component';
import { RecursoComponent } from './recurso/recurso.component';
import { ItemRecursoComponent } from './item-recurso/item-recurso.component';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};
@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      DateTimeFormatPipePipe,
      UserComponent,
      TituloComponent,
      LoginComponent,
      RegistrationComponent,
      DashboardComponent,
      UsuarioComponent,
      VotarComponent,
      RecursoComponent,
      ItemRecursoComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      NgxMaskModule.forRoot(options),
      ModalModule.forRoot(),
      ToastrModule.forRoot({
        timeOut: 3000,
        preventDuplicates: true,
        progressBar: true
     }),
    BsDatepickerModule.forRoot(),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TooltipModule.forRoot()
  ],
  providers: [
    UsuarioService, {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
