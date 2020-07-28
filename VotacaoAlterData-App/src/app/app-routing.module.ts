import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { AuthGuard } from './auth/auth.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { VotarComponent } from './votar/votar.component';
import { ItemRecursoComponent } from './item-recurso/item-recurso.component';
import { RecursoComponent } from './recurso/recurso.component';

const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent }
    ]
  },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'usuarios', component: UsuarioComponent, canActivate: [AuthGuard] },
  { path: 'votar', component: VotarComponent, canActivate: [AuthGuard] },
  { path: 'votar/:id', component: VotarComponent, canActivate: [AuthGuard] },
  { path: 'itemrecurso', component: ItemRecursoComponent},
  { path: 'itemrecurso/:id', component: ItemRecursoComponent},
  { path: 'recurso', component: RecursoComponent, canActivate: [AuthGuard] },
  { path: 'recurso/:id', component: RecursoComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
