import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ForecastComponent } from '../app/forecast/forecast.component';
import { LoginComponent } from '../app/login/login.component';
import { AuthCheck } from '../app/authorization/auth-check';

const routes: Routes = [
    { path: '', component: ForecastComponent, canActivate: [AuthCheck] },
    { path: 'login', component: LoginComponent },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }