import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators, FormGroup} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import {Location} from 'src/app/models/Location';
import {TipoUbicacion} from 'src/app/models/TipoUbicacion';


@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {
  LocationForm: FormGroup;

  tipos: TipoUbicacion[] = [
    {ID: 1, Descripcion: 'Departamento'},
    {ID: 2, Descripcion: 'Casa Habitacion'},
    {ID: 3, Descripcion: 'Amenidad'}
  ];

  constructor() { 
    this.LocationForm =  new FormGroup({
      Ubicacion: new FormControl(),
      Tipo: new FormControl()
    });
  }

  ngOnInit(): void {
  }

  Create(){

  }

}
