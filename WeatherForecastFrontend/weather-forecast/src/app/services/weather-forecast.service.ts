import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { WeatherForecastDetails } from "../models/forecast";
import { AuthorizationService } from "./authorization.service";
import { URLProviderService } from "./url-provider.service";

@Injectable({providedIn: 'root'})
export class WeatherForecastService {

    constructor(private http: HttpClient, private urlProviderService: URLProviderService, private authorizationService: AuthorizationService) {
        
    }

    getWeatherForecastByLocation(location: string): Observable<WeatherForecastDetails>{
        const headers = new HttpHeaders().set('Authorization', `Bearer ${this.authorizationService.currentUserValue.token}`)
        return this.http.get<WeatherForecastDetails>(`${this.urlProviderService.getAPIBaseURL()}/Weatherforecast?cityName=${location}`, {headers: headers});
        }
    }