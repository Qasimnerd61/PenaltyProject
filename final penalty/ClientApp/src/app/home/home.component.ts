import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Country } from '../Models/Country';
import { FormInput } from '../Models/FormInput';
import { map } from 'rxjs/operators';
import { PenaltyService } from '../Services/penalty.service';
import { FormOutput } from '../Models/FormOutput';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
    myForm: FormGroup;
    input: FormInput;
    list: Country[];
    formOutput: FormOutput;
    constructor(private fb: FormBuilder, private PenaltyService: PenaltyService) { }

    ngOnInit(): void {

        this.myForm = this.fb.group({

            startDate: ['', [Validators.required]], //Adding Validation of not null
            endDate: ['', [Validators.required]],   //Adding Validation of not null
            country: ['Please Select Country', [Validators.required]]
        })

        this.PenaltyService.GetCountries().pipe(map((data: Country[]) => {
            if (data != null && data != undefined) {
                this.list = data;
                console.log(this.list);
            }
        })).subscribe();  //subscribing with services


       


    }
    onSubmit() {
        
        this.input = {
            startDate: this.myForm.get('startDate').value,          //taking values from myForm an storing
            endDate: this.myForm.get('endDate').value,
            id: (this.myForm.get('country').value).countryID
        }
        console.log(this.input)
        this.PenaltyService.GetPenalty(this.input).pipe(map((data: FormOutput) => {
            if (data != null && data != undefined) {
                this.formOutput = data;
            }



        })).subscribe();
        console.log(this.formOutput);
        this.myForm.patchValue({
            startDate: '',
            endData: '',
            country: 'Please Select Country'
        })

    }

}
