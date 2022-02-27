import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthorizationService } from '../app/services/authorization.service';
import { User } from '../app/models/user';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent {
    currentUser: User;

    constructor(
        private router: Router,
        private authenticationService: AuthorizationService
    ) {
        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }
  }