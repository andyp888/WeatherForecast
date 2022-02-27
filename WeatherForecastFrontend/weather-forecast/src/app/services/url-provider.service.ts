import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class URLProviderService {
    getAPIBaseURL(){
        return 'https://weatherforecast20220221075525.azurewebsites.net';
    }
}