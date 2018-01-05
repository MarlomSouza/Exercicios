import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import 'rxjs/add/operator/map';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { ListagemComponent } from './listagem/listagem.component';
import { HttpModule } from '@angular/http';
import { RepositorioComponent } from './repositorio/repositorio.component';
import { FormsModule } from "@angular/forms";
import { rounting } from './app.routes';
import { UsuarioRepositoriosComponent } from './usuario-repositorios/usuario-repositorios.component';

@NgModule({
  imports: [BrowserModule, HttpModule, FormsModule, rounting],
  declarations: [AppComponent, LoginComponent, UsuarioComponent, ListagemComponent, RepositorioComponent, UsuarioRepositoriosComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
