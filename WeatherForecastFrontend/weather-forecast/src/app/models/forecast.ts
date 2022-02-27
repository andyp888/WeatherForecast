export class WeatherForecastDetails
{
    coord: any;
    weather: WeatherInfo[];
    main: MainDetails 
    visiblity: number
    clouds: CloudinessDetails;
}

export class WeatherInfo
{
    id: number
    main: string
    description: string
    icon: string
}

export class MainDetails
{
    temp: number;
    feels_Like: number;
    temp_Min: number;
    temp_Max: number;
    pressure: number;
    humidity: number;
}

export class CloudinessDetails
{
    all: number;
}