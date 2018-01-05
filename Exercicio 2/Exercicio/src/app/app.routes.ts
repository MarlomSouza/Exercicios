import { RouterModule, Routes } from "@angular/router";
import { ListagemComponent } from "./listagem/listagem.component";
import { UsuarioRepositoriosComponent } from "./usuario-repositorios/usuario-repositorios.component";


const appRoutes: Routes = [

    {path: 'usuario_repositorio/:login', component: UsuarioRepositoriosComponent},
    {path: '**', component: ListagemComponent},

];

export const rounting = RouterModule.forRoot(appRoutes);
