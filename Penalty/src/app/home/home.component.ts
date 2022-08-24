import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
    //initializing
    myForm: FormGroup;
    input: FormInput;
    countryList: Country[];
    formOutput: FormOutput;
    constructor(private fb: FormBuilder, private PenaltyService: PenaltyService) { }

    ngOnInit(): void {

        this.myForm = this.fb.group({

            startDate: ['', [Validators.required]], // using validations
            endDate: ['', [Validators.required]],
            country: ['Please Select Country', [Validators.required]]
        })

        this.PenaltyService.GetCountries().pipe(map((data: Country[]) => {
            if (data != null && data != undefined) {
                this.countryList = data;
            }
        })).subscribe();// subscribing to service
    }
}