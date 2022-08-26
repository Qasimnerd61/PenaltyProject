import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Country } from '../Models/Country';
import { FormOutput } from '../Models/FormOutput';
import { FormInput } from '../Models/FormInput';

@Injectable({
  providedIn: 'root'
})
export class PenaltyService {

    constructor(private http: HttpClient) { }

    GetCountries(): Observable<Country[]> {
        return this.http.get<Country[]>('api/PenaltyCalculator/GetCountry');
    }
    GetPenalty(input: FormInput): Observable<FormOutput> {
        return this.http.post<FormOutput>('api/PenaltyCalculator/GetPenalty', {
            startDate: input.startDate,
            endDate: input.endDate,
            id: input.id

        })
    }
 
}
