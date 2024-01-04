import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {CadastroAdminComponent} from "./pages/admin/autenticacao/cadastro-admin/cadastro-admin.component";
import {CadastroComponent} from "./pages/comum/cadastro/cadastro/cadastro.component";
import {LoginAdminComponent} from "./pages/admin/autenticacao/login-admin/login-admin.component";


const routes: Routes = [
  // Admin routes
  {path: 'cadastrar-admin', component: CadastroAdminComponent},
  {path: 'login-admin', component: LoginAdminComponent},

  // Default routes
  {path: 'cadastrar', component: CadastroComponent},

  // Redirect routes
  {path: '**', component: CadastroComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
