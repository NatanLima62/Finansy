import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {CadastroComponent} from "./pages/autenticacao/cadastro/cadastro.component";
import {LoginComponent} from "./pages/autenticacao/login/login.component";

const routes: Routes = [
  {path: 'cadastrar', component: CadastroComponent},
  {path: 'login', component: LoginComponent},
  {path: '**', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
