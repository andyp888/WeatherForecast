import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { WeatherForecastDetails } from '../models/forecast';
import { AuthorizationService } from '../services/authorization.service';
import { WeatherForecastService } from '../services/weather-forecast.service';

@Component({ templateUrl: 'forecast.component.html' })
export class ForecastComponent {
    loading = false;
    forecastForm: FormGroup;
    weatherDetails: WeatherForecastDetails | undefined;
    error;
    get location() { return this.forecastForm.controls.location.value; }
    get resetButtonDisabled() {return (this.location == "" || this.location == undefined) && this.weatherDetails == undefined}

    constructor(private router: Router, private authenticationService: AuthorizationService, private weatherForecastService: WeatherForecastService, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.forecastForm = this.formBuilder.group({
            location: ['', Validators.required]
        });
    }

    search() {
        if (this.forecastForm.invalid) {
            return;
        }
        this.error = null;
        this.loading = true;
        this.weatherForecastService.getWeatherForecastByLocation(this.location)
            .subscribe({
                next: (data) => {
                    this.weatherDetails = data
                },
                error: (error) => { this.error = error;},
            })

            this.loading = false;
    }

    reset(){
        this.error = null;
        this.weatherDetails = undefined;
        this.forecastForm.reset();
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
}